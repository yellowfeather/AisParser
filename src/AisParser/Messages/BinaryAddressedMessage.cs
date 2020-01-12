using MessagePack;
namespace AisParser.Messages
{
    [MessagePackObject]
    public class BinaryAddressedMessage : AisMessage
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
        public uint DesignatedAreaCode { get; set; }
        [Key(8)]
        public uint FunctionalId { get; set; }
        [Key(9)]
        public string Data { get; set; }

        public BinaryAddressedMessage()
            : base(AisMessageType.BinaryAddressedMessage)
        {

        }

        public BinaryAddressedMessage(Payload payload)
            : base(AisMessageType.BinaryAddressedMessage, payload)
        {
            SequenceNumber = payload.ReadUInt(38, 2);
            DestinationMmsi = payload.ReadUInt(40, 30);
            RetransmitFlag = payload.ReadBoolean(70, 1);
            Spare = payload.ReadUInt(71, 1);
            DesignatedAreaCode = payload.ReadUInt(72, 10);
            FunctionalId = payload.ReadUInt(82, 6);
            Data = payload.ReadString(88, 920);
        }
    }
}