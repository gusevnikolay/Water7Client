using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaviotAPI.API
{
    public class Water7FirmwareUpdateTask
    {
        private WaviotAPI _api;
        private Water7 _water7;
        private ulong _modemAddress;
        private Firmware.MapItemInfo _function;
        private int _fwPartSize = 1;


        public Water7FirmwareUpdateTask(Water7 water, ulong modemAddress, Firmware.MapItemInfo function, int fwPartSize)
        {
            _api = water.GetApiInstance();
            _water7 = water;
            _modemAddress = modemAddress;
            _function = function;
            _fwPartSize = fwPartSize;
        }

        public void Run()
        {
            var th = new System.Threading.Thread(TaskThread);
            th.IsBackground = true;
            th.Start();
        }

        private void SendRequestAndWaitResult(ulong modemId, byte[] payload)
        {
            var tagId = _api.TelecomSendDownlinkMessage(_modemAddress, Water7Tool.CreateFirmwarEraseRequest());
            var result = _api.TelecomGetDownlinkMessageStatus(tagId);
            while(result.Status != DownlinkMessageStatus.StatusType.Delivered)
            {
                System.Threading.Thread.Sleep(1000);
                result = _api.TelecomGetDownlinkMessageStatus(tagId);
                if (result.Status == DownlinkMessageStatus.StatusType.Lost) throw new Exception("Downlink message not delivered. Tag " + tagId);
            }
        }
        private void TaskThread()
        {
            SendRequestAndWaitResult(_modemAddress, Water7Tool.CreateFirmwarEraseRequest());
            var packetsCount = Math.Ceiling(_function.Data.Length * 1.0 / _fwPartSize);
            int bytesCount = 0;
            for(UInt16 i = 0; i < packetsCount; i++)
            {
                int tail = _function.Data.Length - bytesCount;
                if (tail > _fwPartSize) tail = _fwPartSize;
                byte[] data = new byte[tail];
                Array.Copy(_function.Data, i * _fwPartSize, data, 0, data.Length);
                SendRequestAndWaitResult(_modemAddress, Water7Tool.CreateFirmwareUpdateRequest((UInt32)(_function.Address + i * _fwPartSize), data, i));
            }
        }

        public class FirmwareUpgradeSubtask
        {
            private int Index = 0;
            private byte[] Payload;
            private string Status = "";
        }
    }
}
