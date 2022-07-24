using System.Threading.Tasks;
using SuitSupply.Tailoring.E2ETests.Technical.Models.DomainModels;

namespace SuitSupply.Tailoring.E2ETests.Technical.Persistence.ReadModel;

public class ReadModelRepository: IReadModelRepository
{
    public Task AddAlteringTaskAsync(AlteringTask alteringTask)
    {
        throw new System.NotImplementedException();
    }

    public Task RemoveAllAlteringTasksAsync()
    {
        throw new System.NotImplementedException();
    }

    public Task RemoveAlteringTaskAsync(string id)
    {
        throw new System.NotImplementedException();
    }

    public Task AddTailor(Tailor tailor)
    {
        throw new System.NotImplementedException();
    }

    public Task AddAlteringTask(AlteringTask alteringTask)
    {
        throw new System.NotImplementedException();
    }

    public Task<AlteringTask> GetAlteringTask(string tailorNumber)
    {
        throw new System.NotImplementedException();
    }
}