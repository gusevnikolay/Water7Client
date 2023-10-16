using System;

public class Tool
{
    private static uint[] table;
    public  Tool()
    {
        uint poly = 0xEDB88320U;
        table = new uint[256];
        uint temp = 0;
        for (uint i = 0; i <= table.Length - 1; i++)
        {
            temp = i;
            for (int j = 8; j >= 1; j += -1)
            {
                if ((temp & 1) == 1)
                    temp = System.Convert.ToUInt32((temp >> 1) ^ poly);
                else
                    temp >>= 1;
            }
            table[i] = temp;
        }
    }

    public uint ComputeChecksum(byte[] bytes)
    {
        uint crc = 0xFFFFFFFFU;
        for (int i = 0; i <= bytes.Length - 1; i++)
        {
            byte index = System.Convert.ToByte(((crc) & 0xFF) ^ bytes[i]);
            crc = System.Convert.ToUInt32((crc >> 8) ^ table[index]);
        }
        return ~crc;
    }

    public static string ByteArrayToString(byte[] ba)
    {
        string hex = BitConverter.ToString(ba);
        return hex.Replace("-", "");
    }

    public static byte[] StringToByteArray(string hex)
    {
        int NumberChars = hex.Length;
        byte[] bytes = new byte[NumberChars /2];
        for (int i = 0; i <= NumberChars - 1; i += 2)
            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
        return bytes;
    }

    public static Int32 BigEndianByteArrayToInt32(byte[] array, int offset)
    {
        Int32 currentValue = 0;
        currentValue |= (Int32)array[offset] << 24;
        currentValue |= (Int32)array[offset + 1] << 16;
        currentValue |= (Int32)array[offset + 2] << 8;
        currentValue |= (Int32)array[offset + 3] << 0;
        return currentValue;
    }

    public static string GenerateRandomString(ref int len)
    {
        using (System.Security.Cryptography.MD5 hasher = System.Security.Cryptography.MD5.Create())
        {
            byte[] dbytes = hasher.ComputeHash(System.Text.Encoding.UTF8.GetBytes(System.Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds).ToString()));
            System.Text.StringBuilder sBuilder = new System.Text.StringBuilder();
            for (int n = 0; n <= dbytes.Length - 1; n++)
                sBuilder.Append(dbytes[n].ToString("X2"));
            var str = sBuilder.ToString();
            if (str.Length > len)
                str = str.Substring(0, len);
            return str;
        }
    }

    /// <summary>
    ///     ''' Переводим строку HEX в массив байт
    ///     ''' </summary>
    ///     ''' <param name="hex">Строка с HEX данными</param>
    ///     ''' <returns></returns>
    public static byte[] DecodeHexData(string hex)
    {
        byte[] data = new byte[hex.Length / 2];
        for (var i = 0; i <= data.Length - 1; i++)
            data[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        return data;
    }
}
