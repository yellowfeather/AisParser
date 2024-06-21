namespace AisParser.Messages
{
    public class SafetyRelatedBroadcastMessage : AisMessage
    {
        public uint Spare { get; set; }

        public string SafetyRelatedText { get; set; }

        public SafetyRelatedBroadcastMessage()
            : base(AisMessageType.SafetyRelatedBroadcastMessage)
        {
        }

        public SafetyRelatedBroadcastMessage(Payload payload)
            : base(AisMessageType.SafetyRelatedBroadcastMessage, payload)
        {
            Spare = payload.ReadUInt(38, 2);
            SafetyRelatedText = payload.ReadString(40, 968);
        }
    }
}