using System;

public class DownlinkMessageStatus
{
    public int ACK = 1;
    public UInt32 BaseStationId = 0;
    public UInt32 ModemId = 0;
    public byte[] Payload;
    public int PHY = 0;
    public DateTime PostedTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
    public StatusType Status = StatusType.Unknown;
    public string TagId = "";

    public DownlinkMessageStatus(string json)
    {
        try
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var resp = serializer.Deserialize<dynamic>(json);
            ACK = resp["ACK"];
            BaseStationId = (UInt32)(resp["bs_id"]);
            ModemId = (UInt32)(resp["modem_id"]);
            PHY = resp["phy"];
            TagId = resp["tag_id"];
            Status = (StatusType)(resp["status"]);
            var seconds = (double)(resp["posted_time"]);
            PostedTime = PostedTime.AddSeconds(seconds).ToLocalTime();
            string hexPayload = resp["payload"];
            Payload = Tool.StringToByteArray(hexPayload);
        }
        catch (Exception e)
        {
            throw new Exception("Parser error. JSON = " + json);
        }
    }
    public enum StatusType
    {
        Unknown = 0,
        Queued = 1,
        InProcess = 2,
        Delivered = 4,
        Lost = 5
    }
}



