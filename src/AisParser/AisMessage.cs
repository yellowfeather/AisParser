namespace AisParser
{
    public abstract class AisMessage
    {
        public AisMessageType MessageType { get; }
        public uint Repeat { get; set; }
        public uint Mmsi { get; set; }

        protected AisMessage(AisMessageType messageType)
        {
            MessageType = messageType;
        }

        protected AisMessage(AisMessageType messageType, Payload payload)
            : this(messageType)
        {
            Repeat = payload.ReadUInt(6, 2);
            Mmsi = payload.ReadUInt(8, 30);
        }
    }
}