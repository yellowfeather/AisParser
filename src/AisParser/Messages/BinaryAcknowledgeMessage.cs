﻿namespace AisParser.Messages
{
    public class BinaryAcknowledgeMessage : AisMessage
    {
        public uint Spare { get; set; }
        public uint SequenceNumber1 { get; set; }
        public uint Mmsi1 { get; set; }
        public uint SequenceNumber2 { get; set; }
        public uint Mmsi2 { get; set; }
        public uint SequenceNumber3 { get; set; }
        public uint Mmsi3 { get; set; }
        public uint SequenceNumber4 { get; set; }
        public uint Mmsi4 { get; set; }

        public BinaryAcknowledgeMessage()
            : base(AisMessageType.BinaryAcknowledge)
        {

        }

        public BinaryAcknowledgeMessage(Payload payload)
            : base(AisMessageType.BinaryAcknowledge, payload)
        {
            Spare = payload.ReadUInt(38, 2);
            Mmsi1 = payload.ReadUInt(40, 30);
            SequenceNumber1 = payload.ReadUInt(70, 2);
            Mmsi2 = payload.ReadUInt(72, 30);
            SequenceNumber2 = payload.ReadUInt(102, 2);
            Mmsi3 = payload.ReadUInt(104, 30);
            SequenceNumber3 = payload.ReadUInt(134, 2);
            Mmsi4 = payload.ReadUInt(136, 30);
            SequenceNumber4 = payload.ReadUInt(166, 2);
        }
    }
}