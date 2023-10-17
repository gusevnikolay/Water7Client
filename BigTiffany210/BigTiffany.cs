using System;
using System.Collections.Generic;
using System.IO.Ports;
using static BigTiffany210.LteConfig;

namespace BigTiffany210
{
    public class BigTiffany
    {
        public String PortName = String.Empty;
        private SerialPort _port;

        public event onConnect onConnectEvent;
        public delegate void onConnect(string port, string description);

        public event onLog onLogEvent;
        public delegate void onLog(string message);

        public event onLog onSerialLogEvent;
        public delegate void onSerialLog(string message);

        private Random _rnd = new Random();
        private WaviotAPI.API.WaviotAPI _api;

        private object locker = new object();

        public BigTiffany(string port, string waviotLogin, string waviotPassword)
        {
            _api = new WaviotAPI.API.WaviotAPI(waviotLogin, waviotPassword);
            PortName = port;
        }

        public void Open()
        {
            _port = new SerialPort(PortName, 115200);
            _port.ReadTimeout = 3000;
            _port.Open();

            _api.Open();
        }


        public static long GetCurrentUnixTimestampMillis()
        {
            DateTime localDateTime, univDateTime;
            DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            localDateTime = DateTime.Now;
            univDateTime = localDateTime.ToUniversalTime();
            return (long)(univDateTime - UnixEpoch).TotalMilliseconds/1000;
        }

        private string Request(SerialPort port, string request)
        {
            lock (locker)
            {
                try
                {
                    var lines = new List<string>();
                    port.DiscardInBuffer();
                    port.WriteLine(request);
                    onSerialLogEvent?.Invoke("[->] " + request);
                    while (true)
                    {
                        var responseLine = port.ReadLine();
                        onSerialLogEvent?.Invoke("[<-] " + responseLine);
                        responseLine = responseLine.Replace("\r", "");
                        if (responseLine == "OK") break;
                        if (responseLine == "AT_PARAM_ERROR") throw new Exception("AT_PARAM_ERROR");
                        if (responseLine == request) continue;
                        if (responseLine.Length > 0) lines.Add(responseLine);
                    }
                    if (lines.Count > 0) return lines[0];
                    return "";
                }
                catch(Exception ex) { 
                    return ""; 
                }
                
            }
        }
        public string Request(string request)
        {
            return Request(_port, request);
        }
        


        public void SendUpdateCmd(byte[] cmd)
        {
            string resonse = Request("AT+USER.10="+ BitConverter.ToString(cmd).Replace("-", string.Empty));
            Console.WriteLine(resonse);
        }
        public MemeoryInformation GetMemoryInformation()
        {
            MemeoryInformation info = new MemeoryInformation();
            string resonse = Request("AT+USER.10=DA");
            if (resonse.Length == 0) return info;
            info.MainAppStartAddress = Convert.ToUInt32(resonse.Substring(4,8), 16);
            info.MainAppEndAddress = Convert.ToUInt32(resonse.Substring(12,8), 16);
            info.UpdateStorageStartAddress = Convert.ToUInt32(resonse.Substring(20,8), 16);
            info.UpdateStorageEndAddress = Convert.ToUInt32(resonse.Substring(28,8), 16);
            return info;
        }

        public string GetApnSetting()
        {
            return Request("AT+USER.0=?").Replace("\"", "");
        }

        public void SetApnSetting(string apn)
        {
            Request("AT+USER.0=\"" + apn+"\"");
        }

        public AuthInformation GetModemAuthInfo()
        {
            AuthInformation info = new AuthInformation();
            var resp = Request("AT+USER.1=?");
            info.Login = resp.Replace("\"", "").Split(',')[0];
            info.Password = resp.Replace("\"", "").Split(',')[1];
            return info;
        }

        public void SetModemAuthInfo(AuthInformation info)
        {
            Request("AT+USER.1=\"" + info.Login + "\",\"" + info.Password + "\"");
        }
        public NbfiServerInformation GetNbfiServerInfo()
        {
            NbfiServerInformation info = new NbfiServerInformation();
            var resp = Request("AT+USER.2=?");
            info.Server = resp.Replace("\"", "").Split(',')[0].Replace("\"", "");
            info.Port = UInt16.Parse(resp.Replace("\"", "").Split(',')[1]);
            return info;
        }


        public void SetNbfiServerInfo(NbfiServerInformation info)
        {
            Request("AT+USER.2=\"" + info.Server + "\"," + info.Port);
        }

        public AuthType GetModemAuthType()
        {
            var resp = Request("AT+USER.3=?");
            if (resp.Contains("0"))
            {
                return AuthType.PAP;
            }
            else
            {
                return AuthType.CHAP;
            }
        }

        public void SetModemAuthType(AuthType info)
        {
            Request("AT+USER.3="+ (int)info);
        }

        public NetworkType GetModemNetworkType()
        {
            var resp = Request("AT+USER.4=?");
            if(resp.Contains("1"))return NetworkType.GSM;
            if(resp.Contains("2"))return NetworkType.LTE;
            return NetworkType.AUTO;
        }

        public void SetModemNetworkType(NetworkType info)
        {
            Request("AT+USER.4=" + (int)info);
        }

        public int GetNbfiHearbeatPeriodInMinutes()
        {
            return int.Parse(Request("AT+USER.5=?"));
        }

        public void SetNbfiHearbeatPeriodInMinutes(int period)
        {
            Request("AT+USER.5=" + period);
        }
        public void SaveCurrentSettings()
        {
            Request("AT+USER.6=1");
        }
        public void RecoverDefaultSettings()
        {
            Request("AT+USER.6=0");
        }

        public SimCard GetModemActiveSIM()
        {
            var resp = Request("AT+USER.7=?");
            if(resp.Contains("0")) return SimCard.SIM1;
            return SimCard.SIM2;
        }

        public void SetModemActiveSIM(SimCard sim)
        {
            Request("AT+USER.7=" + (int)sim);
        }

        public string GetFirmwareVersion()
        {
            string response = Request("AT+USER.9=?");
            return response;
        }

        public string GetNbfiId()
        {
            return Request("AT+USER.11=?");
        }

       
        public ModemState GetModemStateString()
        {
            ModemState state = new ModemState();
            var parts = Request("AT+USER.12=?").Replace("OK", "").Split('_');
            foreach (var part in parts)
            {
                if (part.Contains("+IPADDR: "))
                {
                    var ip = part.Replace("+IPADDR: ", "");
                    if (ip.Length > 5) state.IP = ip;
                }
                if (part.Contains("+ICCID: "))
                {
                    var id = part.Replace("+ICCID: ", "");
                    if (id.Length > 5) state.ICCID = id;
                }
            }
            return state;
        }
        public NbfiInterface GetNbfiInterface()
        {
            var response = Request("AT+USER.13=?");
            if (response == "0") return NbfiInterface.LTE;
            return NbfiInterface.WA1470;
        }
        public void SetNbfiInterface(NbfiInterface iface)
        {
            Request("AT+USER.13=" + (int)iface);
        }
        public void NbfiSend(String data)
        {
            Request("AT+USER.14=" + data);
        }

        public RollResponse[] GetMessageFromServer(string id, long timestamp)
        {
            var result = _api.DriverGetRoll(new string[] { id }, timestamp);
            return result;
        }

        internal void Close()
        {
            _port.Close();
        }
    }

    
}
