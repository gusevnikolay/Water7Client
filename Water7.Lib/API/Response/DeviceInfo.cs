using System;

public class DeviceInfo
{
    public int modem_id = 0;
    public int dl_messages_per_ack = 0;
    public string dl_mode = "";
    public int nbfi_ver = 0;
    public int pin = 0;
    public string protocol = "";
    public UInt64 ul_base_freq = 0;
    public UInt64 dl_base_freq = 0;
    public string hw_type = "";

    public DeviceInfo() { }
    public override bool Equals(object obj)
    {
        return (obj is DeviceInfo) && ((DeviceInfo)obj).modem_id == modem_id &&
            ((DeviceInfo)obj).dl_messages_per_ack == dl_messages_per_ack &&
            ((DeviceInfo)obj).dl_mode == dl_mode &&
            ((DeviceInfo)obj).nbfi_ver == nbfi_ver &&
            ((DeviceInfo)obj).pin == pin &&
            ((DeviceInfo)obj).protocol == protocol &&
            ((DeviceInfo)obj).ul_base_freq == ul_base_freq &&
            ((DeviceInfo)obj).dl_base_freq == dl_base_freq;
    }
}

