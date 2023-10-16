using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FirmwareUpdateCmdSequence
{
    public static List<byte[]> Create(byte[] fw, UInt32 mainAppStartAddress, UInt32 storageUpdateAddress)
    {
        List<byte[]> cmds = new List<byte[]>();
        cmds.Add(new byte[] { 213 });//reset counter
        cmds.Add(new byte[] { 212, 0, 1, 32 });//erase memory segment
        cmds.Add(GetHeaderCmd(fw, mainAppStartAddress));//erase memory segment UInt32 offset = 0;
        UInt32 offset = 0;
        UInt16 msgCouneter = 3;
        while (offset < fw.Length)
        {
            int part = (int)(fw.Length - offset);
            if (part > 8) part = 8;
            byte[] subarray = new byte[part + 6];
            subarray[0] = 212;
            subarray[1] = (byte)((msgCouneter >> 8) & 0xFF);
            subarray[2] = (byte)((msgCouneter >> 0) & 0xFF);
            subarray[3] = (byte)(96 + (byte)(offset >> 16));
            subarray[4] = (byte)(offset >> 8);
            subarray[5] = (byte)(offset >> 0);
            Array.Copy(fw, offset, subarray, 6, part);
            cmds.Add(subarray);
            offset += (UInt32)part;
            msgCouneter++;
        }
        UInt32 startAddress = storageUpdateAddress + (UInt32)(cmds[2].Length - 4);
        UInt32 endAddress = (UInt32)(startAddress + fw.Length);
        cmds.Add(new byte[] { 0xD4, (byte)(msgCouneter >> 8), (byte)(msgCouneter & 0xFF), 0x80,
            (byte)(startAddress>>16),
            (byte)(startAddress>>8),
            (byte)(startAddress>>0),
            (byte)(endAddress>>16),
            (byte)(endAddress>>8),
            (byte)(endAddress>>0)
            });
        cmds.Add(new byte[] { 0xD8});
        return cmds;
    }

    private static byte[] GetHeaderCmd(byte[] fw, UInt32 memeoryStartAddress)
    {
        var list = new List<byte>();
        list.AddRange(new byte[] { 212, 0, 2, 64 });
        list.AddRange(Firmware.GetHeaderArray(memeoryStartAddress, fw));
        return list.ToArray();
    }

}

