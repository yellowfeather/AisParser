namespace AisParser
{
    public abstract class AisMessage
    {
        public AisMessageType MessageType { get; set; }

        protected AisMessage(AisMessageType messageType)
        {
            MessageType = messageType;
        }
    }
}