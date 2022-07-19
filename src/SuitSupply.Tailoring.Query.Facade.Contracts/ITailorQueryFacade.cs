using SuitSupply.Tailoring.Query.Facade.Contracts.Models;

namespace SuitSupply.Tailoring.Query.Facade.Contracts;

public interface ITailorQueryFacade
{
    Task<List<Tailor>> GetAll();
}