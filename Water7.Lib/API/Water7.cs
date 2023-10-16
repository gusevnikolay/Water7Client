using System;
using System.Collections.Generic;
using System.Linq;

namespace WaviotAPI.API
{
    public class Water7
    {
        private WaviotAPI _api = null;
        private string _modem;
        public string HardwareType;

        public event onLogMessage onLogMessageEvent;
        public delegate void onLogMessage(string msg);

        public event onDeviceMessage onDeviceMessageEvent;
        public delegate void onDeviceMessage(DeviceMessage msg);

        public event onRollMessage onRollMessageEvent;
        public delegate void onRollMessage(RollResponse msg);

        public event onParametersMessage onParametersMessageEvent;
        public delegate void onParametersMessage(Water7Parameter p);

        public event onNewParametersMessage onNewParametersMessageEvent;
        public delegate void onNewParametersMessage(Water7Parameter p);

        public event onDownlinkMessage onDownlinkMessageEvent;
        public delegate void onDownlinkMessage(DownlinkMessage[] msg);

        public event onDeviceInfo onDeviceInfoEvent;
        public delegate void onDeviceInfo(DeviceInfo deviceInfo);
        private DeviceInfo _devicesInfo = null;

        private Dictionary<string, List<string>> _updateTask = new Dictionary<string, List<string>>();
        public Dictionary<string, Water7Parameter> DevicesParameters = new Dictionary<string, Water7Parameter>();
        private Dictionary<string, string> _deviceEvents = new Dictionary<string, string>();
        private object _updateTaskLocker = new object();
        private object _devicesParamsLocker = new object();
        private System.Threading.Thread _readerThread;
        private System.Threading.Thread _paramChecker;
        public Water7(string waviotLogin, string waviotPassword, string modemId)
        {
            _modem = modemId;
            _api = new WaviotAPI(waviotLogin, waviotPassword);
        }

        public WaviotAPI GetApiInstance()
        {
            return _api;
        }
        public void Run()
        {
            _api.Open();
            UpdateMetadata();
            _readerThread = new System.Threading.Thread(MessageReadThread);
            _readerThread.IsBackground = true;
            _readerThread.Start();
            _paramChecker = new System.Threading.Thread(ParametersChecker);
            _paramChecker.IsBackground = true;
            _paramChecker.Start();
        }

        public void Close()
        {
            _readerThread.Abort();
            _paramChecker.Abort();
    }
        public DeviceInfo GetDeviceInfo(string deviceId)
        {
            return _devicesInfo;
        }
        public long GetParameterValue(string name)
        {
            if (!DevicesParameters.ContainsKey(name)) return -1;
            return DevicesParameters[name].Value;
        }

        public void FirmwareUpdareRequest(uint Address, byte[] data)
        {

        }

        public void UpdateParameter(string name, int value)
        {
            //lock (_devicesParamsLocker)
            {
                onLogMessageEvent?.Invoke("updating cache with name=" + name + " by value=" + value);
                if (!DevicesParameters.ContainsKey(name)) throw new Exception("Свойство \"" + name + "\" отсутствует в " + HardwareType);
                if(DevicesParameters[name].Type == MetaParameter.MetaType.Parameter)
                {
                    if (DevicesParameters[name].IsReadOnly)
                    {
                        DevicesParameters[name].Value = DevicesParameters[name].MinValue;
                        throw new Exception("Свойство \"" + name + "\" не может быть изменено в  " + HardwareType);
                    }
                    if (DevicesParameters[name].MaxValue < value)
                    {
                        DevicesParameters[name].Value = DevicesParameters[name].MaxValue;
                        throw new Exception("Свойство \"" + name + "\" не может принимать значение больше " + DevicesParameters[name].MaxValue);
                    }
                    if (DevicesParameters[name].MinValue > value)
                    {
                        DevicesParameters[name].Value = DevicesParameters[name].MinValue;
                        throw new Exception("Свойство \"" + name + "\" не может принимать значение меньше " + DevicesParameters[name].MinValue);
                    }
                }

                DevicesParameters[name].Value = value;
                DevicesParameters[name].State = Water7Parameter.StateFlag.ModifiedByUser;
                if (DevicesParameters[name].Value == DevicesParameters[name].ValueSynchronizedWithServer)
                {
                    DevicesParameters[name].State = Water7Parameter.StateFlag.SynchronizedWithServer;
                }
                onLogMessageEvent?.Invoke("parameter with name=" + name + " was changed. Raise event onParametersMessageEvent");
            }

               onParametersMessageEvent?.Invoke(DevicesParameters[name]);
        }
        public void SendParameterGetRequest(bool primaryOnly)
        {
            List<Water7Parameter> changedParameters = new List<Water7Parameter>();
            onLogMessageEvent?.Invoke("SendParameterGetRequest: collecting parameters with primary=" + primaryOnly);
            //lock (_devicesParamsLocker)
            {
                foreach (var p in DevicesParameters)
                {
                    if(p.Value.Type == MetaParameter.MetaType.Parameter)
                    {
                        if (primaryOnly)
                        {
                            if (p.Value.IsPrimary)
                            {
                                changedParameters.Add(p.Value);
                            }
                        }
                        else
                        {
                            changedParameters.Add(p.Value);
                        }
                    }
                }
            }
            onLogMessageEvent?.Invoke("SendParameterGetRequest: sorting parameters by index");
            changedParameters.Sort(delegate (Water7Parameter x, Water7Parameter y)
            {
                if (x.Index == y.Index) return 0;
                if (x.Index > y.Index) return 1;
                return -1;
            });
            Dictionary<string, long> subArray = new Dictionary<string, long>();
            int lastIndex = 0;
            if (changedParameters.Count>0) lastIndex = changedParameters[0].Index - 1;
            for (int i = 0; i < changedParameters.Count; i++)
            {
                
                if (changedParameters[i].Index - lastIndex == 1 && subArray.Count < 15)
                {
                    subArray.Add(changedParameters[i].Name, changedParameters[i].Value);
                }
                else
                {
                    if (subArray.Count > 0)
                    {
                        onLogMessageEvent("Get request for subarray of parameters");
                        string tid = _api.SendSettingRequest(_modem, "get", subArray);
                        foreach (var item in subArray.Keys)
                        {
                            //lock (_devicesParamsLocker)
                            {
                                DevicesParameters[item].State = Water7Parameter.StateFlag.WaitingDeviceResponse;
                                 onParametersMessageEvent?.Invoke(DevicesParameters[item]);
                            }
                        }
                        _updateTask.Add(tid, subArray.Keys.ToList());
                        subArray.Clear();
                        subArray.Add(changedParameters[i].Name, changedParameters[i].Value);
                    }
                }
                lastIndex = changedParameters[i].Index;
            }
            if (subArray.Count > 0)
            {
                onLogMessageEvent?.Invoke("Get request for subarray of parameters");
                string tid = _api.SendSettingRequest(_modem, "get", subArray);
                foreach (var item in subArray.Keys)
                {
                    //lock (_devicesParamsLocker)
                    {
                        DevicesParameters[item].State = Water7Parameter.StateFlag.WaitingDeviceResponse;
                        onParametersMessageEvent?.Invoke(DevicesParameters[item]);
                    }
                }

                _updateTask.Add(tid, subArray.Keys.ToList());
                onLogMessageEvent?.Invoke("Wait EXECUTED status for " + _updateTask.Count + " requests");
            }
        }
        public void SendChangesToServer()
        {
            List<Water7Parameter> changedParameters = new List<Water7Parameter>();
            onLogMessageEvent?.Invoke("Sending local parameter changes to device");
            lock (_devicesParamsLocker)
            {
                foreach (var p in DevicesParameters)
                {
                    if (p.Value.State == Water7Parameter.StateFlag.ModifiedByUser)
                    {
                        if(!p.Value.IsReadOnly && p.Value.Type == MetaParameter.MetaType.Parameter)
                        {
                            changedParameters.Add(p.Value);
                        }
                        if(p.Value.Type == MetaParameter.MetaType.Control)
                        {
                            _api.SendControlRequest(_modem, p.Value.Name, p.Value.Value);
                            DevicesParameters[p.Value.Name].State = Water7Parameter.StateFlag.SentToServer;
                            onParametersMessageEvent?.Invoke(DevicesParameters[p.Value.Name]);
                        }
                    }
                }
            }
            onLogMessageEvent?.Invoke("Sorting parameters and grouping by index");
            changedParameters.Sort(delegate (Water7Parameter x, Water7Parameter y)
            {
                if (x.Index == y.Index) return 0;
                if (x.Index > y.Index) return 1;
                return -1;
            });
            Dictionary<string, long> subArray = new Dictionary<string, long>();
            int lastIndex = 0;
            for (int i = 0; i < changedParameters.Count; i++)
            {
                if (lastIndex == 0) lastIndex = changedParameters[0].Index - 1;
                if (changedParameters[i].Index - lastIndex == 1 && subArray.Count < 15)
                {
                    subArray.Add(changedParameters[i].Name, changedParameters[i].Value);
                }
                else
                {
                    if (subArray.Count > 0)
                    {
                        var tid = _api.SendSettingRequest(_modem, "set", subArray);
                        lock (_updateTaskLocker)
                        {
                            _updateTask.Add(tid, subArray.Keys.ToList());
                        }
                        subArray.Clear();
                        subArray.Add(changedParameters[i].Name, changedParameters[i].Value);
                    }
                }
                lastIndex = changedParameters[i].Index;
            }
            if (subArray.Count > 0)
            {
                var tid = _api.SendSettingRequest(_modem, "set", subArray);
                lock (_updateTaskLocker)
                {
                    _updateTask.Add(tid, subArray.Keys.ToList());
                }
            }
            onLogMessageEvent?.Invoke("Set SentToServer flag in local parameters cache");
            //если до этого не было ошибок, то обновляем статусы
            foreach (var p in changedParameters)
            {
                //lock (_devicesParamsLocker)
                {
                    DevicesParameters[p.Name].State = Water7Parameter.StateFlag.SentToServer;
                    onParametersMessageEvent?.Invoke(DevicesParameters[p.Name]);
                }
            }
        }
        private void CheckParametersFromServer()
        {
            onLogMessageEvent("Polling the status of parameters from the server");
            var response = _api.GetDeviceSettings(_modem);
            foreach (var pair in response)
            {
                lock (_devicesParamsLocker)
                {
                    string key = "";
                    if (DevicesParameters.ContainsKey(pair.Key))
                    {
                        key = pair.Key;
                    }
                    else
                    {
                        if (pair.Key.IndexOf("par") == 0)
                        {
                            var finded = DevicesParameters.Where(z => z.Value.Index == int.Parse(pair.Key.Substring(3))).FirstOrDefault();
                            if(finded.Key != null)
                            {
                                key = finded.Value.Name;
                                if (response.ContainsKey(key))
                                {
                                    key = "";
                                }
                            }
                        }
                    }
                    if (key.Length == 0) continue;
                    var selectedParameter = DevicesParameters[key];
                    if (selectedParameter.State == Water7Parameter.StateFlag.Undefined)
                    {
                        if (selectedParameter.Multiplier != 0) selectedParameter.Value = (int)(pair.Value / selectedParameter.Multiplier);
                        selectedParameter.ValueSynchronizedWithServer = selectedParameter.Value;
                        selectedParameter.State = Water7Parameter.StateFlag.SynchronizedWithServer;
                        onParametersMessageEvent?.Invoke(selectedParameter);
                    }
                    else if (selectedParameter.State == Water7Parameter.StateFlag.SentToServer)
                    {
                        if (selectedParameter.Multiplier != 0)
                        {
                            if (selectedParameter.Value == (int)(pair.Value / selectedParameter.Multiplier))
                            {
                                selectedParameter.State = Water7Parameter.StateFlag.SynchronizedWithServer;
                                onParametersMessageEvent?.Invoke(selectedParameter);
                            }
                        }
                    }
                    else if (selectedParameter.State != Water7Parameter.StateFlag.ModifiedByUser)
                    {
                        var valueFromServer = (int)(pair.Value / selectedParameter.Multiplier);
                        if (selectedParameter.Value != valueFromServer)
                        {
                            selectedParameter.Value = valueFromServer;
                            selectedParameter.State = Water7Parameter.StateFlag.SynchronizedWithServer;
                            selectedParameter.ValueSynchronizedWithServer = selectedParameter.Value;
                            onParametersMessageEvent?.Invoke(selectedParameter);
                        }
                    }
                    DevicesParameters[key] = selectedParameter;
                }
            }
        }
        private void ParametersChecker()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(1500);
                try
                {
                    lock (_updateTaskLocker)
                    {
                        if (_updateTask.Count > 0)
                        {
                            var resp = _api.GetDLStatus(_updateTask.Keys.ToArray());
                            foreach (var pair in resp)
                            {
                                if (pair.Value == "EXECUTED")
                                {
                                    var updatedParameters = _updateTask[pair.Key];
                                    _updateTask.Remove(pair.Key);
                                    foreach (var parameter in updatedParameters)
                                    {
                                        lock (_devicesParamsLocker)
                                        {
                                            DevicesParameters[parameter].State = Water7Parameter.StateFlag.SynchronizedWithServer;
                                            DevicesParameters[parameter].ValueSynchronizedWithServer = DevicesParameters[parameter].Value;
                                            if(onParametersMessageEvent!=null) onParametersMessageEvent(DevicesParameters[parameter]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    CheckParametersFromServer();
                }
                catch (Exception ex)
                {
                    onLogMessageEvent?.Invoke("ParametersChecker: " + ex.Message);
                }
            }
        }
        private void UpdateMetadata()
        {
            onLogMessageEvent?.Invoke("Запрашиваю информацию об устройстве #" + _modem);
            var device = GetDeviceInfo();
            HardwareType = device.hw_type;
            if (device.protocol.ToLower() != "water7") throw new Exception("Протокол " + device.protocol + " не поддерживается!");
            if (HardwareType.Length == 0) throw new Exception("Ошибка при запросе информации об устройстве #" + _modem);
            onLogMessageEvent?.Invoke(_modem + " hw_type = " + HardwareType);
            var meta = _api.GetMetadata(HardwareType, "water7");
            foreach (var metaItem in meta)
            {
                if (metaItem.Type == MetaParameter.MetaType.Parameter || metaItem.Type == MetaParameter.MetaType.Control)
                {

                    lock (_devicesParamsLocker)
                    {
                        if (!DevicesParameters.ContainsKey(metaItem.name))
                        {
                            var p = new Water7Parameter();
                            p.Type = metaItem.Type;
                            p.Name = metaItem.name;
                            p.Description = metaItem.comment;
                            p.Unit = metaItem.unit;
                            p.Value = metaItem.min_value;
                            p.MinValue = metaItem.min_value;
                            p.MaxValue = metaItem.max_value;
                            p.IsPrimary = metaItem.primary;
                            p.IsReadOnly = !metaItem.write;
                            p.Index = metaItem.parameterIndex;
                            p.Multiplier = metaItem.mul;
                            p.State = Water7Parameter.StateFlag.Undefined;
                            onNewParametersMessageEvent?.Invoke(p);
                            DevicesParameters.Add(metaItem.name, p);
                            onParametersMessageEvent?.Invoke(p);
                        }
                    }
                }

                if (metaItem.Type == MetaParameter.MetaType.Event)
                {
                    _deviceEvents.Add("event"+metaItem.parameterIndex, metaItem.comment);
                }
            }
        }
        public DeviceInfo GetDeviceInfo()
        {
                var response = _api.TelecomUpdateDevicesInfo(new string[] { _modem });
                onLogMessageEvent("Calling telecom device info API");
                if (response.Length == 0) throw new Exception("Can't request device information by ID=" + _modem);
                return response[0];                     
        }
        private void DeviceInfoChecker()
        {
            while (true)
            {
                try
                {
                    var response = GetDeviceInfo();

                    if (_devicesInfo == null)
                    {
                        onDeviceInfoEvent(response);
                        _devicesInfo = response;
                    }
                    else
                    {
                        if (!_devicesInfo.Equals(response))
                        {
                            onDeviceInfoEvent(response);
                            _devicesInfo = response;
                        }
                    }
                }
                catch (Exception ex)
                {
                    onLogMessageEvent("DeviceInfoChecker: " + ex.Message);
                }
                System.Threading.Thread.Sleep(3000);
            }
        }

        private void ParseRollMessage(RollResponse msg)
        {
            DeviceMessage dm = new DeviceMessage();
            dm.Payload = Tool.StringToByteArray(msg.payload);
            dm.BaseID = msg.station_id;
            dm.RSSI = msg.rssi;
            dm.Time = DateTime.Now;
            if (dm.Payload[0] == 0x80)
            {
                dm.Type = DeviceMessage.MessageType.Regular;
                dm.Value  = dm.Payload[3]   <<  24;
                dm.Value |= dm.Payload[4]   <<  16;
                dm.Value |= dm.Payload[5]   <<  8;
                dm.Value |= dm.Payload[6]   <<  0;
                dm.Description = "Регулярное сообщение [VAL=" + dm.Value+"]";
            }
            if (dm.Payload[0] == 0x20)
            {
                dm.Type = DeviceMessage.MessageType.Event;
                UInt16 evt = (UInt16)(dm.Payload[1] << 8 | dm.Payload[2] << 0);
                dm.Value = dm.Payload[3] << 16;
                dm.Value |= dm.Payload[4] << 0;
                dm.Description = _deviceEvents["event"+evt] + " [VAL="+ dm.Value + "]";
            }
            onDeviceMessageEvent?.Invoke(dm);
        }

        private void MessageReadThread()
        {
            DateTime localDateTime, univDateTime;
            DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            localDateTime = DateTime.Now;
            univDateTime = localDateTime.ToUniversalTime();
            long unixTimestamp = (long)(univDateTime - UnixEpoch).TotalMilliseconds / 1000;
            List<Int64> processedUids = new List<Int64>();
            while (true)
            {
                try
                {
                    var ulMessages = _api.DriverGetRoll(new string[] { _modem }, unixTimestamp);
                    foreach (var msg in ulMessages)
                    {
                        if (msg.timestamp >= unixTimestamp) unixTimestamp = msg.timestamp;
                        if (!processedUids.Contains(msg.unique_id))
                        {
                            ParseRollMessage(msg);
                            onRollMessageEvent?.Invoke(msg);
                        }
                    }
                    DateTime point = new DateTime(1970, 1, 1);
                    TimeSpan time = DateTime.UtcNow.Subtract(point);
                    var ts = (int)time.TotalSeconds * 1000;
                    var dlMesages = _api.TelecomGetDlMessages(new string[] { _modem }, ts);
                    onDownlinkMessageEvent?.Invoke(dlMesages);
                    System.Threading.Thread.Sleep(1000);
                    processedUids.Clear();
                    foreach (var msg in ulMessages) processedUids.Add(msg.unique_id);
                }
                catch (Exception ex)
                {
                    onLogMessageEvent?.Invoke("MessageReadThread: " + ex.Message);
                }
            }
        }

    }
}