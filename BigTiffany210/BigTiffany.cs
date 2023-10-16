using Bwl.Hardware.SimplSerial;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO.Ports;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Bwl.Hardware.SimplSerial.SimplSerialBus;

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

        public BigTiffany(string waviotLogin, string waviotPassword)
        {
            _api = new WaviotAPI.API.WaviotAPI(waviotLogin, waviotPassword);
        }

        public void Open()
        {
            var th = new Thread(ScanProcess);
            th.IsBackground = true;
            th.Start();
        }

        private void OnSeialPortConnectEventHandler(string serialPort)
        {
            if (IsModemPort(serialPort))
            {
                onLogEvent?.Invoke("Обнаружено устройство: " + serialPort); 
                try
                {
                    if (PortName.Length == 0)
                    {
                        PortName = serialPort;
                        _port = new SerialPort(PortName, 115200);
                        _port.ReadTimeout = 3000;
                        _port.Open();
                    }

                }
                catch (Exception ex)
                {
                    PortName = "";
                }
            }
        }

        private void ScanProcess()
        {          
            _api.Open();          
            while (true)
            {
                Thread.Sleep(1000);
                OnSeialPortConnectEventHandler(GetComPort());
            }
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
                catch(Exception ex) { return ""; }
                
            }
        }
        public string Request(string request)
        {
            return Request(_port, request);
        }
        public string GetFirmwareVersion()
        {
            string response = Request("AT+USER.9=?");
            return response;
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
            info.MainAppStartAddress = Convert.ToUInt32(resonse.Substring(4,8), 16);
            info.MainAppEndAddress = Convert.ToUInt32(resonse.Substring(12,8), 16);
            info.UpdateStorageStartAddress = Convert.ToUInt32(resonse.Substring(20,8), 16);
            info.UpdateStorageEndAddress = Convert.ToUInt32(resonse.Substring(28,8), 16);
            return info;
        }
      
        public string GetNbfiId()
        {
            return Request("AT+USER.11=?");
        }
       
        public ModemState GetModemStateString()
        {
            ModemState state = new ModemState();
            var parts = Request("AT+USER.12=?").Replace("OK","").Split('_');
            foreach(var part in parts)
            {
                if(part.Contains("+IPADDR: "))
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

        public enum Bt210NbfiInterface
        {
            WA1470 = 0, 
            GSM = 1
        } 
        public void SetNbfiInternet(Bt210NbfiInterface selection)
        {
            Request("AT+USER.13=" + selection);
        }
        public void GetNbfiInternet(Bt210NbfiInterface selection)
        {
            Request("AT+USER.13=" + selection);
        }
        private bool IsModemPort(string port)
        {
            bool isDetected = false;
            try
            {
                var serial = new SerialPort(port, 115200);
                serial.ReadTimeout = 1000;
                serial.Open();
                if (Request(serial, "AT+USER.9=?").Contains("BT210"))
                {
                    isDetected = true;
                    serial.Close();
                }
                serial.Close();
            }
            catch (Exception ex)
            {
               
            }
            return isDetected;
        }
       
        public void WriteGsmConfig(LteConfig сfg)
        {

        }
        public string GetComPort()
        {
            string comport = string.Empty;
            while(comport.Length == 0)
            {
                var ports = SerialPort.GetPortNames();
                foreach(var port in ports)
                {
                   // onLogEvent?.Invoke("Проверка порта " + port);
                    if (IsModemPort(port))
                    {
                        comport = port;
                        break;
                    }
                }
            }
            return comport;
        }
    }

    
}
