using System.Threading.Tasks;
using SuitSupply.Tailoring.E2ETests.Technical.Models.DomainModels;

namespace SuitSupply.Tailoring.E2ETests.Technical.Persistence.ReadModel
{
    public interface IReadModelRepository
    {
        Task AddAlteringTaskAsync(AlteringTask alteringTask);
        Task RemoveAllAlteringTasksAsync();
        Task RemoveAlteringTaskAsync(string id);

        Task AddTailor(Tailor tailor);
        Task AddAlteringTask(AlteringTask alteringTask);
        Task<AlteringTask> GetAlteringTask(string tailorNumber);
    }
}
