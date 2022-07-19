namespace SuitSupply.Framework.Core.InternalEvents
{
    public abstract class BrokerMessage : EnternalEvent, IBrokerMessage
    {
        protected BrokerMessage()
        {
        }

        protected BrokerMessage(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}