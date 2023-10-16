using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Water7Tool
{
    public static byte[] CreateFirmwareUpdateRequest(UInt32 address, byte[] payload, UInt16 partIndex)
    {
        byte[] water7fwPart = new byte[10 + payload.Length];
        water7fwPart[0] = 0x29;
        water7fwPart[1] = 0x0;
        water7fwPart[2] = (byte)(address >> 24);
        water7fwPart[3] = (byte)(address >> 16);
        water7fwPart[4] = (byte)(address >> 8);
        water7fwPart[5] = (byte)(address >> 0);
        water7fwPart[6] = (byte)((UInt16)(payload.Length) >> 8);
        water7fwPart[7] = (byte)((UInt16)(payload.Length) >> 0);
        water7fwPart[8] = (byte)((UInt16)(partIndex) >> 8);
        water7fwPart[9] = (byte)((UInt16)(partIndex) >> 0);
        Array.Copy(payload, 0, water7fwPart, 10, payload.Length);
        return water7fwPart;
    }
    public static byte[] CreateFirmwareUpdateRequestWithConfirmation(UInt32 address, byte[] payload, UInt16 partIndex)
    {
        byte[] water7fwPart = new byte[10 + payload.Length];
        water7fwPart[0] = 0x29;
        water7fwPart[1] = 0x1;
        water7fwPart[2] = (byte)(address >> 24);
        water7fwPart[3] = (byte)(address >> 16);
        water7fwPart[4] = (byte)(address >> 8);
        water7fwPart[5] = (byte)(address >> 0);
        water7fwPart[6] = (byte)((UInt16)(payload.Length) >> 8);
        water7fwPart[7] = (byte)((UInt16)(payload.Length) >> 0);
        water7fwPart[8] = (byte)((UInt16)(partIndex) >> 8);
        water7fwPart[9] = (byte)((UInt16)(partIndex) >> 0);
        Array.Copy(payload, 0, water7fwPart, 10, payload.Length);
        return water7fwPart;
    }

    public static byte[] CreateFirmwareReadRequest(UInt32 address, UInt16 length)
    {
        byte[] water7fwPart = new byte[8];
        water7fwPart[0] = 0x29;
        water7fwPart[1] = 0x2;
        water7fwPart[2] = (byte)(address >> 24);
        water7fwPart[3] = (byte)(address >> 16);
        water7fwPart[4] = (byte)(address >> 8);
        water7fwPart[5] = (byte)(address >> 0);
        water7fwPart[6] = (byte)(length >> 8);
        water7fwPart[7] = (byte)(length >> 0);
        return water7fwPart;
    }

    public static byte[] CreateFirmwarCRC32Request(UInt32 address, UInt32 length)
    {
        byte[] water7fwPart = new byte[10];
        water7fwPart[0] = 0x29;
        water7fwPart[1] = 0x6;
        water7fwPart[2] = (byte)(address >> 24);
        water7fwPart[3] = (byte)(address >> 16);
        water7fwPart[4] = (byte)(address >> 8);
        water7fwPart[5] = (byte)(address >> 0);
        water7fwPart[6] = (byte)(length >> 24);
        water7fwPart[7] = (byte)(length >> 16);
        water7fwPart[8] = (byte)(length >> 8);
        water7fwPart[9] = (byte)(length >> 0);
        return water7fwPart;
    }

    public static byte[] CreateFirmwarEraseRequest()
    {
        byte[] water7fwPart = new byte[2];
        water7fwPart[0] = 0x29;
        water7fwPart[1] = 0x8;
        return water7fwPart;
    }
}

