namespace AisParser.Messages
{
    public class InterrogationMessage: AisMessage
    {
        public uint InterrogatedMmsi { get; set; }
        public AisMessageType FirstMessageType { get; set; }
        public uint FirstSlotOffset { get; set; }

        public AisMessageType? SecondMessageType { get; set; }
        public uint? SecondSlotOffset { get; set; }

        public uint? SecondStationInterrogationMmsi { get; set; }
        public AisMessageType? SecondStationFirstMessageType { get; set; }
        public uint? SecondStationFirstSlotOffset { get; set; }


        public InterrogationMessage()
            : base(AisMessageType.Interrogation)
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
