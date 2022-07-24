using System.Threading.Tasks;
using SuitSupply.Tailoring.E2ETests.Technical.Models.DomainModels;

namespace SuitSupply.Tailoring.E2ETests.Technical.Persistence.WriteModel
{
    public interface IWriteModelRepository
    {
       // Task AddTotalOfT2IncreasedEventAsync(AlteringTaskCreated totalOfT2Increased);
        Task DeleteEventsAsync(string traderId);
        Task CreateTailor(Tailor tailor);
        Task CreateAlteringTask(AlteringTask alteringTask);
    }
}
