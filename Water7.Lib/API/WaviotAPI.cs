using System;
using System.Net.Http;
using System.Text;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using System.Linq;

namespace WaviotAPI.API
{
    public class WaviotAPI
    {
        private string _login = "";
        private string _password = "";
        private string _cookie = "";
        private string _jwt = "";

        public event onLogMessage onLogMessageEvent;
        public delegate void onLogMessage(string msg);

        private List<string> dlMessagesInQueue = new List<string>();

        public WaviotAPI(string login, string password)
        {
            _login = login;
            _password = password;
            ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }

        private string PostRequest(string url, string content)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
            //httpClient.DefaultRequestHeaders.Add("Host", "auth.waviot.ru");
            httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json, text/javascript, */*; q=0.01");
            httpClient.DefaultRequestHeaders.Add("Cookie", _cookie);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + _jwt);
            StringContent queryString = new StringContent(content, Encoding.UTF8, "application/json");
            var task = httpClient.PostAsync(url, queryString);
            task.Wait(10000);
            try
            {
                byte[] responseText = task.Result.Content.ReadAsByteArrayAsync().Result;
                return Encoding.UTF8.GetString(responseText);
            }catch(Exception ex)
            {
                throw new Exception("http POST request failed: " + url);
            }
           
        }
        object locker = new object();
        private string GetRequest(string url)
        {
            lock (locker)
            {
                try
                {
                    HttpClient httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                    httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json, text/javascript, */*; q=0.01");
                    httpClient.DefaultRequestHeaders.Add("Cookie", _cookie);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + _jwt);
                    var task = httpClient.GetAsync(url);
                    string responseText = Encoding.UTF8.GetString(task.Result.Content.ReadAsByteArrayAsync().Result);
                    System.Threading.Thread.Sleep(500);
                    return responseText;
                }
                catch (Exception ex)
                {
                    throw new Exception("http GET request failed: " + url);
                }
            }
        }

        public void Open()
        {
            string post_data = "{\"login\":\"" + _login + "\",\"password\":\"" + _password + "\"}";
            var json = PostRequest("https://auth.waviot.ru/?action=user-login&true_api=1", post_data);
            var response = JsonConvert.DeserializeObject<AuthResponse>(json);
            if (response.status == "false") throw new Exception(response.message);
            _jwt = response.WAVIOT_JWT;
            _cookie = "ck=" + response.sc + ";rt=" + response.rt + ";sessid=" + response.sessid + ";";
        }

        public DeviceInfo[] TelecomUpdateDevicesInfo(string[] devicesList)
        {
            string modemList = "";
            for (int i = 0; i < devicesList.Length; i++)
            {
                if (i != 0) modemList += ",";
                modemList += devicesList[i];
            }
            var response = GetRequest("https://api.waviot.ru/telecom/api/device?dev_ids=" + modemList);
            var devices = JsonConvert.DeserializeObject<DeviceInfo[]>(response);
            return devices;
        }

        public string GetDeivceHwType(string modemId)
        {
            var response = GetRequest("https://api.waviot.ru/telecom/api/device?dev_ids=" + modemId);
            if (!response.Contains("hw_type")) throw new Exception("Can't request hardware type of device #" + modemId);
            var serializer = new JavaScriptSerializer();
            var resp = serializer.Deserialize<dynamic>(response);
            var type = resp[0]["hw_type"];
            return type;
        }
        public RollResponse[] DriverGetRoll(string[] modems, long timeFrom)
        {
            string modemList = "";
            for (int i = 0; i < modems.Length; i++)
            {
                if (i != 0) modemList += ",";
                modemList += modems[i];
            }
            List<RollResponse> results = new List<RollResponse>();
            var json = GetRequest("https://api.waviot.ru/api/roll?modem_id=" + modemList + "&from=" + timeFrom);
            var serializer = new JavaScriptSerializer();
            var resp = serializer.Deserialize<dynamic>(json);
            if (resp.Count == 0) return new RollResponse[] { };
            var e = resp.GetEnumerator();
            while (e.MoveNext())
            {
                var anElement = e.Current.Value;
                var cut = JsonConvert.SerializeObject(anElement);
                var messages = JsonConvert.DeserializeObject<RollResponse[]>(cut);
                foreach (var msg in messages)
                {
                    msg.device_id = e.Current.Key;
                    results.Add(msg);
                }
            }
            return results.ToArray();
        }
        public Dictionary<string, float> GetDeviceSettings(string deviceId)
        {
            Dictionary<string, float> result = new Dictionary<string, float>();
            var json = GetRequest("https://api.waviot.ru/api/setting?modem_id=" + deviceId);
            var serializer = new JavaScriptSerializer();
            var resp = serializer.Deserialize<dynamic>(json);
            var e = resp.GetEnumerator();
            e.MoveNext();
            json = JsonConvert.SerializeObject(e.Current.Value);
            resp = serializer.Deserialize<dynamic>(json);
            e = resp.GetEnumerator();
            while (e.MoveNext())
            {
                if (e.Current.Value.GetType().GetProperty("Count") == null)
                {
                    var t = e.Current.Value.GetType();
                    result.Add(e.Current.Key.ToString(), float.Parse(e.Current.Value.ToString()));
                }
            }
            return result;
        }
        public Dictionary<string, float> GetDeviceSettings(int deviceId)
        {
            return GetDeviceSettings(deviceId.ToString());
        }

        public MetaParameter[] GetMetadata(string deviceType, string protocol)
        {
            List<MetaParameter> parameters = new List<MetaParameter>();
            var json = GetRequest("https://api.waviot.ru/api/metadata?hw_type=" + deviceType + "&protocol=" + protocol);
            var serializer = new JavaScriptSerializer();
            var resp = serializer.Deserialize<dynamic>(json);
            if (resp.Count == 0) return GetMetadata("*", protocol);
            var e = resp.GetEnumerator();
            while (e.MoveNext())
            {
                MetaParameter p = new MetaParameter();
                string key = e.Current.Key;
                var anElement = e.Current.Value;
                var cut = JsonConvert.SerializeObject(anElement);
                var meta = JsonConvert.DeserializeObject<MetaParameter>(cut);
                if (key.ToLower().Substring(0, 3) == "par")
                {
                    meta.parameterIndex = int.Parse(key.Substring(3));
                    meta.Type = MetaParameter.MetaType.Parameter;
                    parameters.Add(meta);
                }
                if (key.ToLower().Substring(0, 3) == "eve")
                {
                    meta.parameterIndex = int.Parse(key.Substring(5));
                    meta.Type = MetaParameter.MetaType.Event;
                    parameters.Add(meta);
                }
                if (key.ToLower().Substring(0, 3) == "ctr")
                {
                    meta.parameterIndex = int.Parse(key.Substring(4));
                    meta.Type = MetaParameter.MetaType.Control;
                    parameters.Add(meta);
                }
            }
            return parameters.ToArray();
        }

        public string SendControlRequest(string deviceId, string control, Int64 value)
        {

            dynamic requestObject = new System.Dynamic.ExpandoObject();
            requestObject.cmd = "ctrl";
            requestObject.ctrl = control;
            requestObject.data = value;
            var json = JsonConvert.SerializeObject(requestObject);
            string response = PostRequest("https://api.waviot.ru/api/dl?timeout=3600&modem_id=" + deviceId, json);
            var serializer = new JavaScriptSerializer();
            var resp = serializer.Deserialize<dynamic>(response);
            if (response.Contains("what"))
            {
                throw new Exception(resp[deviceId]["what"]);
            }
            if (response.Contains("bd_id"))
            {
                return resp[deviceId]["bd_id"];
            }
            return null;
        }

        public string SendSettingRequest(string deviceId, string cmd, Dictionary<string, long> parameters)
        {
            dynamic requestObject = new System.Dynamic.ExpandoObject();
            requestObject.cmd = cmd;
            requestObject.data = parameters;
            var json = JsonConvert.SerializeObject(requestObject);
            string response = PostRequest("https://api.waviot.ru/api/dl?timeout=3600&modem_id=" + deviceId, json);
            var serializer = new JavaScriptSerializer();
            var resp = serializer.Deserialize<dynamic>(response);
            if (response.Contains("what"))
            {
                throw new Exception(resp[deviceId]["what"]);
            }
            if (response.Contains("bd_id"))
            {
                return resp[deviceId]["bd_id"];
            }
            return null;
        }

        public Dictionary<string, string> GetDLStatus(string[] db_id)
        {
            Dictionary<string, string> stat = new Dictionary<string, string>();
            string dlList = "";
            for (int i = 0; i < db_id.Length; i++)
            {
                if (i != 0) dlList += ",";
                dlList += db_id[i];
            }
            var json = GetRequest("https://api.waviot.ru/api/dl?db_id=" + dlList);
            var serializer = new JavaScriptSerializer();
            var resp = serializer.Deserialize<dynamic>(json);
            var e = resp.GetEnumerator();
            while (e.MoveNext())
            {
                stat.Add(e.Current.Key, e.Current.Value["dl_status"].ToString());
            }
            return stat;
        }
        public string TelecomSendDownlinkMessage(ulong device_id, byte[] data)
        {
            var response = GetRequest("https://api.waviot.ru/telecom/api/send_dl?modem_id=" + device_id + "&payload=" + BitConverter.ToString(data).Replace("-", string.Empty));
            var serializer = new JavaScriptSerializer();
            if (!response.Contains("tag_id")) throw new Exception(response);
            var resp = serializer.Deserialize<dynamic>(response);
            var tagId = resp["tag_id"];
            if(onLogMessageEvent!=null) onLogMessageEvent("Downlink message is queued to be sent. TagId: " + tagId);
            return tagId;
        }

        public DownlinkMessageStatus TelecomGetDownlinkMessageStatus(string tagId)
        {
            var response = GetRequest("https://api.waviot.ru/telecom/api/dl_message_status?tag_id=" + tagId);
            return new DownlinkMessageStatus(response);
        }
        public DownlinkMessage[] TelecomGetDlMessages(string[] modems, int timeFrom)
        {
            string modemList = "";
            for (int i = 0; i < modems.Length; i++)
            {
                if (i != 0) modemList += ",";
                modemList += modems[i];
            }
            var json = GetRequest("https://api.waviot.ru/telecom/api/dl_messages?devices=" + modemList + "&limit=10"/* "&from=" + timeFrom*/);
            var resp = JsonConvert.DeserializeObject<DownlinkMessage[]>(json);
            if (resp.Length == 0) return new DownlinkMessage[] { };
            return resp;
        }


        private static IEnumerable<JToken> AllChildren(JToken json)
        {
            foreach (var c in json.Children())
            {
                yield return c;
                foreach (var cc in AllChildren(c))
                {
                    yield return cc;
                }
            }
        }
        public static byte[] Int32ToBigEndianByteArray(int value)
        {
            var bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);
            return bytes;
        }

        public Electro5Data[] EncodeElectro5Packet(string hex)
        {
            var list = new List<Electro5Data>();
            var json = GetRequest("https://api.waviot.ru/api/custom?instance=electro5_*&parse=" + hex);
            var serializer = new JavaScriptSerializer();
            var resp = serializer.Deserialize<dynamic>(json);
            var e = resp.GetEnumerator();
            while (e.MoveNext())
            {
                if (e.Current.Key == "data")
                {
                    var data = e.Current.Value;
                    foreach (var item in data)
                    {
                        Electro5Data pack = new Electro5Data();
                        pack.OBIS = item.Key;
                        pack.Value = Double.Parse(item.Value.ToString().Replace(".", ","));
                        list.Add(pack);
                    }
                }
                //stat.Add(e.Current.Key, e.Current.Value["dl_status"].ToString());
            }
            return list.ToArray();
        }

        public static byte[] HexToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }

    public class TrustAllCertificatePolicy : ICertificatePolicy
    {
        public bool CheckValidationResult(ServicePoint sp,
            X509Certificate cert, WebRequest req, int problem)
        {
            return true;
        }
    }
}