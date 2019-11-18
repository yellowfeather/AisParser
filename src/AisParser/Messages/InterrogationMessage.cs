using MessagePack;
namespace AisParser.Messages
{
    [MessagePackObject]
    public class InterrogationMessage: AisMessage
    {
        [Key(3)]
        public uint InterrogatedMmsi { get; set; }
        [Key(4)]
        public AisMessageType FirstMessageType { get; set; }
        [Key(5)]
        public uint FirstSlotOffset { get; set; }

        [Key(6)]
        public AisMessageType? SecondMessageType { get; set; }
        [Key(7)]
        public uint? SecondSlotOffset { get; set; }

        [Key(8)]
        public uint? SecondStationInterrogationMmsi { get; set; }
        [Key(9)]
        public AisMessageType? SecondStationFirstMessageType { get; set; }
        [Key(10)]
        public uint? SecondStationFirstSlotOffset { get; set; }


        public InterrogationMessage()
            : base(AisMessageType.AddressedSafetyRelatedMessage)
        {
        }
        
        public InterrogationMessage(Payload payload)
            : base(AisMessageType.Interrogation, payload)
        {
            // spare 38, 2
            InterrogatedMmsi = payload.ReadUInt(40, 30);
            FirstMessageType = payload.ReadEnum<AisMessageType>(70, 6);
            FirstSlotOffset = payload.ReadUInt(76, 12);

            var length = payload.RawValue.Length;
            if (length > 88)
            {
                // spare 88, 2
                SecondMessageType = payload.ReadNullableMessageType(90, 6);
                SecondSlotOffset = payload.ReadNullableUInt(96, 12);
                // spare 108, 2
            }

            if (length > 110)
            {
                SecondStationInterrogationMmsi = payload.ReadNullableUInt(110, 30);
                SecondStationFirstMessageType = payload.ReadNullableMessageType(140, 6);
                SecondStationFirstSlotOffset = payload.ReadNullableUInt(146, 12);
                // spare 158, 2
            }
        }
    }
}