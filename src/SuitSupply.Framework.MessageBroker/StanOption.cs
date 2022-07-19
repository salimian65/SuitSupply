namespace SuitSupply.Framework.MessageBroker
{
    public class StanOption
    {
        public const string StanConfigurationOptions = "StanConfigurationOptions";

        public string ServerUrl { get; set; }
        public bool AllowReconnect { get; set; }
        public int MaxReconnect { get; set; }
        public int ReconnectWait { get; set; }
        public bool Verbose { get; set; }
        public string ClusterId { get; set; }
        public string ClientId { get; set; }
        public string QueueGroup { get; set; }
        public int AcknowledgementWait { get; set; }
        public int SubscriberRateLimiting { get; set; }
        public string DurableName { get; set; }
        public bool ManualAcknowledgement { get; set; }
    }
}
