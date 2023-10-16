using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Waviot
{
    public class AquaFirmwareLoader
    {
        public event onFirmwareUpgrade onFirmwareUpgradeEvent;
        public delegate void onFirmwareUpgrade(int progess, string message);

        ulong _deviceId;
        byte[] _firmware;

        WaviotAPI.API.WaviotAPI _api;

        List<byte[]> _messages = new List<byte[]>();
        private const byte WATER7_RFL = 0x29;
        private const UInt32 AQUA_UPDATE_ADDRESS = 0x00010000;

        

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct soft_update_t
        {
            public UInt32 ver;
            public UInt32 ver_ext;
            public UInt32 start_add;
            public UInt32 end_add;
            public UInt32 crc;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public UInt32[] reserved;
            public UInt32 crc_of_this_struct;
        };
        enum RFL_CMD {
            RFL_CMD_WRITE_HEX_INDEX,
            WATER7_RFL_WRITE_HEX,
            RFL_CMD_READ_HEX,
            RFL_CMD_CLEAR_CACHE,
            RFL_CMD_CLEAR_INDEX,
            RFL_CMD_CHECK_UPDATE,
            RFL_CMD_GET_CRC,
            RFL_CMD_SOFT_RESET,
            RLF_CMD_MASS_ERASE,
            RFL_CMD_CPY_ACTUAL,
            RFL_CMD_GET_INDEX,
            RFL_CMD_GET_VERSION,
            RFL_CMD_EXEC_PATCH0,
            RFL_CMD_EXEC_PATCH1,
            RFL_CMD_EXEC_PATCH2,
        }


        public AquaFirmwareLoader(WaviotAPI.API.WaviotAPI api, ulong deviceId, byte[] firmware)
        {
            _deviceId = deviceId;
            _firmware = firmware;
            _api = api;
        }

        private List<byte[]> PrepareMessages()
        {
            List<byte[]> memWriteCmds = new List<byte[]>();
            for(int i=0;i<_firmware.Length;i+=120)
            {
                var buf = new List<byte>();
                for(int cursor = 0; (cursor<120) && (cursor+i< _firmware.Length); cursor++)
                {
                    buf.Add(_firmware[i + cursor]);
                }
                memWriteCmds.Add(CreateMemoryWriteCmd((uint)(AQUA_UPDATE_ADDRESS + 128 + i), buf.ToArray()));
            }
            return memWriteCmds;
        }

        public void Run()
        {
            var th = new System.Threading.Thread(process);
            th.IsBackground = true;
            th.Start();
        }

        private void ExecuteCommand(byte[] data)
        {
            var msgId = _api.TelecomSendDownlinkMessage(_deviceId, data);
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
                        msgId = _api.TelecomSendDownlinkMessage(_deviceId, data);
                    }
                    else
                    {
                        //System.Threading.Thread.Sleep(500);
                    }
                }
                catch (Exception ex)
                {
                    System.Threading.Thread.Sleep(500);
                }
            }
        }

        private byte[] CreateMemoryWriteCmd(UInt32 addr, byte[] data)
        {
            UInt16 len = (UInt16)data.Length;
            var bytes = new List<byte>(new byte[] { WATER7_RFL, (byte)RFL_CMD.WATER7_RFL_WRITE_HEX });
            bytes.Add((byte)((addr >> 24) & 0xFF));
            bytes.Add((byte)((addr >> 16) & 0xFF));
            bytes.Add((byte)((addr >> 8) & 0xFF));
            bytes.Add((byte)((addr >> 0) & 0xFF));
            bytes.Add((byte)((len >> 8) & 0xFF));
            bytes.Add((byte)((len >> 0) & 0xFF));
            bytes.AddRange(data);
            return bytes.ToArray();
        }
        private void MemoryWriteHex(UInt32 addr,  byte [] data)
        {
            ExecuteCommand(CreateMemoryWriteCmd(addr, data));
        }

        private void MemoryErase()
        {
            ExecuteCommand(new byte[] { WATER7_RFL, (byte)RFL_CMD.RLF_CMD_MASS_ERASE});
        }
        public void WriteUpdateHeader()
        {
            UInt32 len = (uint)_firmware.Length;
            soft_update_t su = new soft_update_t();
            su.start_add = AQUA_UPDATE_ADDRESS + 128;
            su.end_add = (uint)(AQUA_UPDATE_ADDRESS + 128 + _firmware.Length);
            su.ver = 1;
            su.ver_ext = 1;
            su.crc = FirmwareCRC32.FirmwareCRC16(_firmware, len);
            int size = Marshal.SizeOf(su);
            var buffer = new byte[size];
            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            Marshal.StructureToPtr(su, handle.AddrOfPinnedObject(), true);
            handle.Free();
            su.crc_of_this_struct = FirmwareCRC32.FirmwareCRC16(buffer, (uint)(size - 4));
            handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            Marshal.StructureToPtr(su, handle.AddrOfPinnedObject(), true);
            handle.Free();
            MemoryWriteHex(AQUA_UPDATE_ADDRESS, buffer);
        }
        private void process()
        {
            if (onFirmwareUpgradeEvent != null) onFirmwareUpgradeEvent(0, "Очистка памяти микроконтроллера");
            MemoryErase();
            if (onFirmwareUpgradeEvent != null) onFirmwareUpgradeEvent(0, "Запись заголовочных данных");
            WriteUpdateHeader();
            var messages = PrepareMessages();
            int count = 0;
            foreach (var cmd in messages)
            {
                count++;
                ExecuteCommand(cmd);
                if (onFirmwareUpgradeEvent != null) onFirmwareUpgradeEvent(count*100/messages.Count, "Запись прошивки " +count+"/"+ messages.Count);
            }
            ExecuteCommand(new byte[] { WATER7_RFL, (byte)RFL_CMD.RFL_CMD_CLEAR_CACHE });
            if (onFirmwareUpgradeEvent != null) onFirmwareUpgradeEvent(0, "Запись завершена");
        }
    }
}
