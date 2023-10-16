using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DeviceMessage
{
    public Int32 Value;
    public byte[] Payload;
    public int RSSI = -1;
    public DateTime Time = DateTime.Now;
    public int BaseID = 1;
    public string Description = "Регулярное сообщение";
    public MessageType Type = MessageType.Event;

    public enum MessageType
    {
        Event,
        Regular
    }
}

