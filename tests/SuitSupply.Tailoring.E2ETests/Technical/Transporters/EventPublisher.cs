using System.Threading.Tasks;
using STAN.Client;
using SuitSupply.Tailoring.E2ETests.Technical.Contracts;

namespace SuitSupply.Tailoring.E2ETests.Technical.Transporters
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IStanConnection _stanConnection;

        public EventPublisher(Utilities.StanConnectionFactory stanConnectionFactory)
        {
            _stanConnection = stanConnectionFactory.Create();
        }

        public async Task<string> PublishAsync(string subject, byte[] data)
            => await _stanConnection.PublishAsync(subject, data);

    }
}
