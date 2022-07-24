
using System.Threading.Tasks;
using SuitSupply.Tailoring.E2ETests.Technical.Models.DomainModels;

namespace SuitSupply.Tailoring.E2ETests.Technical.Persistence.WriteModel
{
    public class WriteModelRepository : IWriteModelRepository
    {
        public Task DeleteEventsAsync(string traderId)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateTailor(Tailor tailor)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateAlteringTask(AlteringTask alteringTask)
        {
            throw new System.NotImplementedException();
        }
    }
}
