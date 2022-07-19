using SuitSupply.Framework.MessageBroker;

namespace SuitSupply.Tailoring.Interface.OutboxPublisher
{
    public static class StanOptionFactory
    {
        public static StanOption GetStanOption(IConfiguration configuration)
        {
            var stanOption = configuration.GetSection(StanOption.StanConfigurationOptions).Get<StanOption>();
            stanOption.ClientId += $"-{configuration.GetSection("HOSTNAME").Value}";
            return stanOption;
        }
    }
}
