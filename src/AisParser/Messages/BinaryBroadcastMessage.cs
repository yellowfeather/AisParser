using MessagePack;
namespace AisParser.Messages
{
    [MessagePackObject]
    public class BinaryBroadcastMessage : AisMessage
    {
        [Key(3)]
        public uint Spare { get; set; }
        [Key(4)]
        public uint DesignatedAreaCode { get; set; }
        [Key(5)]
        public uint FunctionalId { get; set; }
        [Key(6)]
        public string Data { get; set; }

        public BinaryBroadcastMessage()
            : base(AisMessageType.BinaryBroadcastMessage)
        {

        }

        public BinaryBroadcastMessage(Payload payload)
            : base(AisMessageType.BinaryBroadcastMessage, payload)
        {
            Spare = payload.ReadUInt(38, 2);
            DesignatedAreaCode = payload.ReadUInt(40, 10);
            FunctionalId = payload.ReadUInt(50, 6);
            Data = payload.ReadString(56, 952);
        }
    }
}