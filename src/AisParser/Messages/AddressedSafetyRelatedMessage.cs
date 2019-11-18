using MessagePack;

namespace AisParser.Messages
{
    [MessagePackObject]
    public class AddressedSafetyRelatedMessage : AisMessage
    {
        [Key(3)]
        public uint SequenceNumber { get; set; }
        [Key(4)]
        public uint DestinationMmsi { get; set; }
        [Key(5)]
        public bool RetransmitFlag { get; set; }
        [Key(6)]
        public uint Spare { get; set; }
        [Key(7)]
        public string Text { get; set; }

        public AddressedSafetyRelatedMessage()
            : base(AisMessageType.AddressedSafetyRelatedMessage)
        {
            
        }
        
        public AddressedSafetyRelatedMessage(Payload payload)
            : base(AisMessageType.AddressedSafetyRelatedMessage, payload)
        {
            SequenceNumber = payload.ReadUInt(38, 2);
            DestinationMmsi = payload.ReadUInt(40, 30);
            RetransmitFlag = payload.ReadBoolean(70, 1);
            Spare = payload.ReadUInt(71, 1);
            Text = payload.ReadString(72, 936);
        }
    }
}