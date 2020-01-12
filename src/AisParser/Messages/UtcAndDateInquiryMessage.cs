using MessagePack;
namespace AisParser.Messages
{
    [MessagePackObject]
    public class UtcAndDateInquiryMessage : AisMessage
    {
        [Key(3)]
        public uint Spare1 { get; set; }
        [Key(4)]
        public uint DestinationMmsi { get; set; }
        [Key(5)]
        public uint Spare2 { get; set; }

        public UtcAndDateInquiryMessage()
            : base(AisMessageType.UtcAndDateInquiry)
        {
            
        }

        public UtcAndDateInquiryMessage(Payload payload)
            : base(AisMessageType.UtcAndDateInquiry, payload)
        {
            Spare1 = payload.ReadUInt(38, 2);
            DestinationMmsi = payload.ReadUInt(40, 30);
            Spare2 = payload.ReadUInt(70, 2);
        }
    }
}