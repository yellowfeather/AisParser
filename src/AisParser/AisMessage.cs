using MessagePack;

namespace AisParser
{
    [MessagePackObject]
    public abstract class AisMessage
    {
        [Key(0)]
        public AisMessageType MessageType { get; }
        [Key(1)]
        public uint Repeat { get; set; }
        [Key(2)]
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
        public virtual void Encode(Payload payload)
        {
            payload.WriteUInt(Repeat, 2);
            payload.WriteUInt(Mmsi, 30);
        }
    }
}