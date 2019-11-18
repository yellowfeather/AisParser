using MessagePack;
namespace AisParser.Messages
{
    [MessagePackObject]
    public class StaticDataReportPartAMessage : StaticDataReportMessage
    {
        [Key(4)]
        public string ShipName { get; set; }
        [Key(5)]
        public uint Spare { get; set; }

        public StaticDataReportPartAMessage()
            : base(0)
        {
        }

        public StaticDataReportPartAMessage(StaticDataReportMessage message, Payload payload)
            : base(message)
        {
            ShipName = payload.ReadString(40, 120);
            Spare = payload.ReadUInt(160, 8);
        }
    }
}