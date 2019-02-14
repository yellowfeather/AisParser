namespace AisParser
{
    public abstract class AisMessage
    {
        public AisMessageType MessageType { get; }

        protected AisMessage(AisMessageType messageType)
        {
            MessageType = messageType;
        }
    }
}