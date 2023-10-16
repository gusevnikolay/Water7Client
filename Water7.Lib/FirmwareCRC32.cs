using System;

public class FirmwareCRC32
{
    private static uint[] CrcTable = new uint[256];
    private uint crc = 0xFFFFFFFFU;
    private UInt32 _currentAddress = 0;
    private UInt32 _endAddress = 0;

    public static UInt16 FirmwareCRC16(byte[] data, UInt32 size)
    {
        UInt16 crc = 0x0;
        for(int i=0;i<size;i++)
        {
            crc = (UInt16)((crc >> 8) | (crc << 8));
            crc ^= data[i];
            crc ^= (UInt16)((crc & 0xff) >> 4);
            crc ^= (UInt16)(crc << 12);
            crc ^= (UInt16)((crc & 0xff) << 5);
        }
        return crc;
    }
    public FirmwareCRC32(UInt32 startAdress, UInt32 applicationLength)
    {
        _currentAddress = startAdress;
        _endAddress = startAdress + applicationLength;
        uint poly = 0xEDB88320U;
        CrcTable = new uint[256];
        uint temp = 0;
        for (uint i = 0; i <= CrcTable.Length - 1; i++)
        {
            temp = i;
            for (int j = 8; j >= 1; j += -1)
            {
                if ((temp & 1) == 1)
                    temp = System.Convert.ToUInt32((temp >> 1) ^ poly);
                else
                    temp >>= 1;
            }
            CrcTable[i] = temp;
        }
    }

    public void AppendFirmwareData(UInt32 address, byte[] dataBytes)
    {
        while (_currentAddress < address)
        {
            _currentAddress = _currentAddress + 1;
            AppendData(0xFF);
        }
        foreach (var dataByte in dataBytes)
        {
            _currentAddress = _currentAddress + 1;
            AppendData(dataByte);
        }
    }

    private void AppendData(UInt32 dataByte)
    {
        crc = System.Convert.ToUInt32((crc >> 8) ^ CrcTable[((crc) & 0xFF) ^ dataByte]);
    }
    public UInt32 GetCRC32()
    {
        while (_currentAddress < _endAddress - 4 | (~crc != 0xC771EDF2))
        {
            _currentAddress = _currentAddress + 1;
            AppendData(0xFF);
        }
        return ~crc;
    }
}
