using System.Threading.Tasks;

namespace SuitSupply.Tailoring.E2ETests.Technical.Contracts
{
    public interface IEventPublisher
    {
        Task<string> PublishAsync(string subject, byte[] data);
    }
}
