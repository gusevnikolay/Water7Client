using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public class Firmware
{
    private string _pathHex = "";
    private List<MemorySector> _flashData = new List<MemorySector>();
    public Firmware(string pathHex)
    {
        _pathHex = pathHex;
    }

    [Serializable]
    public struct soft_update
    {
        [MarshalAsAttribute(UnmanagedType.U2)]
        public UInt16 ver;
        [MarshalAsAttribute(UnmanagedType.U2)]
        public UInt16 ver_ext;
        [MarshalAsAttribute(UnmanagedType.U4)]
        public UInt32 start_add;
        [MarshalAsAttribute(UnmanagedType.U4)]
        public UInt32 end_add;
        [MarshalAsAttribute(UnmanagedType.U2)]
        public UInt16 crc;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public UInt16[] reserved;
        [MarshalAsAttribute(UnmanagedType.U2)]
        public UInt16 crc_of_this_struct;
    }

   
    public static byte[] GetByteArrayFromHeader(soft_update sf)
    {
        int size = Marshal.SizeOf(sf);
        byte[] arr = new byte[size];

        IntPtr ptr = Marshal.AllocHGlobal(size);
        Marshal.StructureToPtr(sf, ptr, true);
        Marshal.Copy(ptr, arr, 0, size);
        Marshal.FreeHGlobal(ptr);
        return arr;
    }

    static UInt16 CRC_calc(byte[] data)
    {
        UInt16 crc = 0x0;
        foreach (var dataByte in data)
        {
            crc = (UInt16)((crc >> 8) | (crc << 8));
            crc ^= (UInt16)dataByte;
            crc ^= (UInt16)((crc & 0xff) >> 4);
            crc ^= (UInt16)(crc << 12);
            crc ^= (UInt16)((crc & 0xff) << 5);
        }
        return crc;
    }
    static UInt16 CRC_calc(byte[] data, int lenght)
    {
        UInt16 crc = 0x0;
        for(int i=0; i<lenght;i++)
        {
            byte dataByte = data[i];
            crc = (UInt16)((crc >> 8) | (crc << 8));
            crc ^= (UInt16)dataByte;
            crc ^= (UInt16)((crc & 0xff) >> 4);
            crc ^= (UInt16)(crc << 12);
            crc ^= (UInt16)((crc & 0xff) << 5);
        }
        return crc;
    }

    public static byte[] GetHeaderArray(UInt32 startAddress, byte[] data)
    {
        soft_update uh = new soft_update();
        uh.ver = 1;
        uh.ver_ext = 2;
        uh.start_add = startAddress;
        uh.end_add = (UInt32)(startAddress+data.Length);
        uh.crc = CRC_calc(data);
        uh.reserved = new ushort[2];
        uh.reserved[0] = 0;
        uh.reserved[1] = 0;
        uh.crc_of_this_struct = CRC_calc(GetByteArrayFromHeader(uh), 18);
        return GetByteArrayFromHeader(uh);
    }
    public void Load()
    {
        var lines = System.IO.File.ReadAllLines(_pathHex);
        UInt32 offset = 0;
        UInt16 i = 0;
        while (i < lines.Length - 1)
        {
            if ((lines[i].Length > 8))
            {
                var _sector = new MemorySector();
                UInt32 _sectorAddressCounter = 0;
                while (i < lines.Length - 1)
                {
                    var oneLine = hexLineDecode(lines[i].Replace(":", ""));
                    if (oneLine.HexType == 4)
                    {
                        i++;
                        offset = oneLine.HexAddress;
                        break;
                    }
                    if (oneLine.HexType == 0)
                    {
                        if (_sector.FlashAddress == 0)
                        {
                            _sector.FlashAddress = (offset << 16) | oneLine.HexAddress;
                            _sectorAddressCounter = oneLine.HexAddress;
                        }
                        if (_sectorAddressCounter == oneLine.HexAddress)
                        {
                            _sector.AppendData(oneLine.HexData);
                            _sectorAddressCounter += (UInt32)oneLine.HexData.Length;
                            i++;
                        }
                        else
                            break;
                    }
                    if (oneLine.HexType != 0 & oneLine.HexType != 4)
                    {
                        i++;
                        break;
                    }
                }
                if (_sector.FlashData.Count > 0)
                    _flashData.Add(_sector);
            }
            else
                i++;
        }
        _flashData.Sort(delegate (MemorySector x, MemorySector y)
        {
            if (x.FlashData == null && y.FlashData == null) return 0;
            else if (x.FlashData == null) return -1;
            else if (y.FlashData == null) return 1;
            else if (x.FlashAddress > y.FlashAddress) return 1;
            else if (x.FlashAddress < y.FlashAddress) return -1;
            return 0;
        });
    }

   
    private HexLineData hexLineDecode(string hex)
    {
        var _decoded = new HexLineData();
        UInt16 dataLength = Convert.ToUInt16(hex.Substring(0, 2), 16);
        _decoded.HexAddress = Convert.ToUInt16(hex.Substring(2, 4), 16);
        _decoded.HexType = Convert.ToUInt16(hex.Substring(6, 2), 16);
        if (_decoded.HexType == 0)
            _decoded.HexData = Tool.DecodeHexData(hex.Substring(8, dataLength * 2));
        if (_decoded.HexType == 4)
        {
            var temp = Tool.StringToByteArray(hex.Substring(8, 4));
            _decoded.HexAddress = (ushort)(temp[0] * 256 + temp[1]);
        }
        return _decoded;
    }

    public byte[] GetFirmwareData(UInt32 addressStart)
    {
        var list = new List<byte>();
        int index = -1;
        for (int i = _flashData.Count - 1; i >= 0; i--)
        {
            if (addressStart >= _flashData[i].FlashAddress)
            {
                index = i;
                break;
            }
        }
        if (index < 0) throw new Exception("Address sector not found");
        int offset = (int)(addressStart - _flashData[index].FlashAddress);

        for(int cursor = index; cursor< _flashData.Count; cursor++)
        {
            var sector = _flashData[cursor];
            while (sector.FlashAddress > (addressStart + list.Count)) list.Add(0xFF); //текущий адрес данных больше, чем было обработанно ранее
            for (int i = offset; i < sector.FlashData.Count; i++)
            {
                    list.Add(sector.FlashData[i]);
            }
            offset = 0;
        }
        return list.ToArray();
    }

    public byte[] GetFirmwareData(UInt32 addressStart, UInt32 addressEnd)
    {
        var list = new List<byte>();
        int index = -1;
        for(int i = _flashData.Count-1; i >= 0; i--)
        {
            if (addressStart >= _flashData[i].FlashAddress)
            {
                index = i;
                break;
            }
        }
        if (index < 0) throw new Exception("Address sector not found");
        int offset = (int)(addressStart - _flashData[index].FlashAddress);
        while (list.Count<(addressEnd- addressStart) && index < _flashData.Count)
        {
            var sector = _flashData[index];
            if (sector.FlashAddress > (addressStart + list.Count)) break;
            while (sector.FlashAddress > (addressStart + list.Count)) list.Add(0xFF);
            for (int i = offset; i < sector.FlashData.Count; i++)
            {
                if ((addressStart + list.Count) < addressEnd) { 
                    list.Add(sector.FlashData[i]); 
                }else
                {
                    break;
                }
            }
            offset = 0;
            index++;
        }
        return list.ToArray();
    }


    private class HexLineData
    {
        public UInt16 HexType = 0;
        public UInt16 HexAddress = 0;
        public byte[] HexData;
    }
    public class MapItemInfo
    {
        public string FunctionName = "";
        public string ObjectName = "";
        public UInt32 Address = 0;
        public UInt32 Length = 0;
        public byte[] Data;
    }

    public class MemorySector
    {
        public UInt32 FlashAddress { get; set; } = 0;
        public List<byte> FlashData { get; set; } = new List<byte>();

        public MemorySector()
        {
        }

        public void AppendData(byte[] data)
        {
            FlashData.AddRange(data);
        }
    }
}
