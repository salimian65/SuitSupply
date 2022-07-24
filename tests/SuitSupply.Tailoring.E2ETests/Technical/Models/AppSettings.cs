namespace SuitSupply.Tailoring.E2ETests.Technical.Models
{
    public class AppSettings
    {
        public const string ConfigurationOptions = nameof(AppSettings);
        public string DefaultConnectionString { get; set; }
        public ElasticAppSettingsModel Elastic { get; set; }
        public OMSServiceHostModel OMSServiceHost { get; set; }
        public StanOption Stan { get; set; }

        public class ElasticAppSettingsModel
        {
            public string Uri { get; set; }
            public string DefaultIndex { get; set; }
        }

        public class OMSServiceHostModel
        {
            public string Url { get; set; }
            public string ExecutableFileName { get; set; }
            public string ExecutableFilePath { get; set; }
        }

        public class StanOption
        {
            public const string StanConfigurationOptions = "Stan";

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
}
