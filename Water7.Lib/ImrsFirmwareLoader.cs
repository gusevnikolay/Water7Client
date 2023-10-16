using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waviot
{
    public class ImrsFirmwareLoader
    {
        ulong _deviceId;
        byte[] _firmware;
        UInt32 _memoryStartAddress;

        WaviotAPI.API.WaviotAPI _api;

        List<byte[]> _messages = new List<byte[]>();
        public ImrsFirmwareLoader(WaviotAPI.API.WaviotAPI api, ulong deviceId, byte[] firmware, UInt32 memoryStartAddress)
        {
            _deviceId = deviceId;
            _firmware = firmware;
            _memoryStartAddress = memoryStartAddress;
            _api = api;
        }

        private void PrepareMessages()
        {  
            _messages.Add(new byte[] { 213 });//reset counter
            _messages.Add(new byte[] { 212, 0, 1, 32 });//erase memory segment
            _messages.Add(GetHeaderCmd());//erase memory segment
            UInt32 offset = 0;
            UInt16 msgCouneter = 3;
            while (offset < _firmware.Length)
            {
                int part = (int)(_firmware.Length - offset);
                if (part > 8) part = 8;
                byte[] subarray = new byte[part + 6];
                subarray[0] = 212;
                subarray[1] = (byte)((msgCouneter >> 8) & 0xFF);
                subarray[2] = (byte)((msgCouneter >> 0) & 0xFF);
                subarray[3] = (byte)(96 + (byte)(offset >> 16));
                subarray[4] = (byte)(offset >> 8);
                subarray[5] = (byte)(offset >> 0);
                Array.Copy(_firmware, offset, subarray, 6, part);
                _messages.Add(subarray);
                offset += (UInt32)part;
                msgCouneter++;
            }
            UInt32 startAddress = 0x17814;
            UInt32 endAddress = (UInt32)(0x17814 + _firmware.Length);
            _messages.Add(new byte[] { 0xD4, (byte)(msgCouneter >> 8), (byte)(msgCouneter & 0xFF), 0x80,
            (byte)(startAddress>>16),
            (byte)(startAddress>>8),
            (byte)(startAddress>>0),
            (byte)(endAddress>>16),
            (byte)(endAddress>>8),
            (byte)(endAddress>>0)
            }) ;
        }

        private byte[] GetHeaderCmd()
        {
            var list = new List<byte>();
            list.AddRange(new byte[] { 212, 0, 2, 64 });
            list.AddRange(Firmware.GetHeaderArray(_memoryStartAddress, _firmware));
            return list.ToArray();
        }
        public void Run()
        {
            var th = new System.Threading.Thread(process);
            th.IsBackground = true;
            th.Start();
        }

        private void process()
        {
            PrepareMessages();
            foreach (var cmd in _messages)
            {
                var msgId = _api.TelecomSendDownlinkMessage(_deviceId, cmd);
                while (true)
                {
                    try
                    {
                        var status = _api.TelecomGetDownlinkMessageStatus(msgId).Status;
                        if (status == DownlinkMessageStatus.StatusType.Delivered)
                        {
                            break;
                        }
                        else if (status == DownlinkMessageStatus.StatusType.Lost)
                        {
                            return;
                        }
                        else
                        {
                            System.Threading.Thread.Sleep(500);
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Threading.Thread.Sleep(500);
                    }
                }
            }
        }
    }
}
