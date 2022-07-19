using Microsoft.EntityFrameworkCore;
using SuitSupply.Tailoring.Query.Facade.Context;
using SuitSupply.Tailoring.Query.Facade.Contracts;
using SuitSupply.Tailoring.Query.Facade.Contracts.Models;

namespace SuitSupply.Tailoring.Query.Facade;

public class TailorQueryFacade : ITailorQueryFacade
{
    private readonly SuitSupplyDbContext _dbContext;

    public TailorQueryFacade(SuitSupplyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Tailor>> GetAll()
    {
        return await _dbContext.Tailors.ToListAsync();
    }
}