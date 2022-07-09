namespace SuitSupply.Framework.Core.Events
{
    public abstract class BrokerMessage : Event, IBrokerMessage
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