using STAN.Client;

namespace SuitSupply.Framework.MessageBroker
{
    public class StanConnectionFactory
    {
        private readonly StanOption _stanOption;

        public StanConnectionFactory(StanOption stanOption)
        {
            this._stanOption = stanOption;
        }

        public IStanConnection Create()
        {
            var stanOptions = StanOptions.GetDefaultOptions();
            stanOptions.NatsURL = _stanOption.ServerUrl;
            return new STAN.Client.StanConnectionFactory().CreateConnection(_stanOption.ClusterId, _stanOption.ClientId, stanOptions);
        }
    }
}
