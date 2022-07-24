using System.Collections.Generic;
using System.Threading.Tasks;
using SuitSupply.Tailoring.E2ETests.Technical.Models.Commands;
using SuitSupply.Tailoring.E2ETests.Technical.Models.DomainModels;

namespace SuitSupply.Tailoring.E2ETests.Technical.APIs
{
    public interface IAlteringTaskEndpoint
    {
        Task<List<AlteringTask>> Get();
        Task Pick(PickAlteringTaskCommand command);
        Task Finish(FinishAlteringTaskCommand command);
    }
}
