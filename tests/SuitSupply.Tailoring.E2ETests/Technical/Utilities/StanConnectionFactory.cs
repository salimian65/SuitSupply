using STAN.Client;
using SuitSupply.Tailoring.E2ETests.Technical.Models;

namespace SuitSupply.Tailoring.E2ETests.Technical.Utilities
{
    public class StanConnectionFactory
    {
        private readonly AppSettings _appSettings;

        public StanConnectionFactory(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public IStanConnection Create()
        {
            var stanOptions = StanOptions.GetDefaultOptions();
            stanOptions.NatsURL = _appSettings.Stan.ServerUrl;
            return new STAN.Client.StanConnectionFactory().CreateConnection(_appSettings.Stan.ClusterId, _appSettings.Stan.ClientId, stanOptions);
        }
    }
}
