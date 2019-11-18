using MessagePack;
namespace AisParser.Messages
{
    [MessagePackObject]
    public class DataLinkManagementMessage : AisMessage
    {
        [Key(3)]
        public uint Spare { get; set; }
        [Key(4)]
        public uint Offset1 { get; set; }
        [Key(5)]
        public uint ReservedSlots1 { get; set; }
        [Key(6)]
        public uint Timeout1 { get; set; }
        [Key(7)]
        public uint Increment1 { get; set; }
        [Key(8)]
        public uint Offset2 { get; set; }
        [Key(9)]
        public uint ReservedSlots2 { get; set; }
        [Key(10)]
        public uint Timeout2 { get; set; }
        [Key(11)]
        public uint Increment2 { get; set; }
        [Key(12)]
        public uint Offset3 { get; set; }
        [Key(13)]
        public uint ReservedSlots3 { get; set; }
        [Key(14)]
        public uint Timeout3 { get; set; }
        [Key(15)]
        public uint Increment3 { get; set; }
        [Key(16)]
        public uint Offset4 { get; set; }
        [Key(17)]
        public uint ReservedSlots4 { get; set; }
        [Key(18)]
        public uint Timeout4 { get; set; }
        [Key(19)]
        public uint Increment4 { get; set; }

        public DataLinkManagementMessage()
            : base(AisMessageType.DataLinkManagement)
        {
        }

        public DataLinkManagementMessage(Payload payload)
            : base(AisMessageType.DataLinkManagement, payload)
        {
            Spare = payload.ReadUInt(38, 2);
            Offset1 = payload.ReadUInt(40, 12);
            ReservedSlots1 = payload.ReadUInt(52, 4);
            Timeout1 = payload.ReadUInt(56, 3);
            Increment1 = payload.ReadUInt(59, 11);
            Offset2 = payload.ReadUInt(70, 12);
            ReservedSlots2 = payload.ReadUInt(82, 4);
            Timeout2 = payload.ReadUInt(86, 3);
            Increment2 = payload.ReadUInt(89, 11);
            Offset3 = payload.ReadUInt(100, 12);
            ReservedSlots3 = payload.ReadUInt(112, 4);
            Timeout3 = payload.ReadUInt(116, 3);
            Increment3 = payload.ReadUInt(119, 11);
            Offset4 = payload.ReadUInt(130, 12);
            ReservedSlots4 = payload.ReadUInt(142, 4);
            Timeout4 = payload.ReadUInt(146, 3);
            Increment4 = payload.ReadUInt(149, 11);
        }
    }
}
