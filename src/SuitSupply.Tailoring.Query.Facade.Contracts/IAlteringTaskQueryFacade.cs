using SuitSupply.Tailoring.Query.Facade.Contracts.Models;

namespace SuitSupply.Tailoring.Query.Facade.Contracts
{
    public interface IAlteringTaskQueryFacade
    {
        Task<List<AlteringTask>> GetAll();
    }
}