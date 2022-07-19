using Microsoft.EntityFrameworkCore;
using SuitSupply.Tailoring.Query.Facade.Context;
using SuitSupply.Tailoring.Query.Facade.Contracts;
using SuitSupply.Tailoring.Query.Facade.Contracts.Models;

namespace SuitSupply.Tailoring.Query.Facade
{
    public class AlteringTaskQueryFacade : IAlteringTaskQueryFacade
    {
        private readonly SuitSupplyDbContext _dbContext;

        public AlteringTaskQueryFacade(SuitSupplyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AlteringTask>> GetAll()
        {
            return await _dbContext.AlteringTasks.ToListAsync();
        }
    }
}