using Microsoft.EntityFrameworkCore;
using SuitSupply.Tailoring.Query.Facade.Contracts.Models;

namespace SuitSupply.Tailoring.Query.Facade.Context;

public class SuitSupplyDbContext : DbContext
{
    public SuitSupplyDbContext(DbContextOptions<SuitSupplyDbContext> options, DbSet<Tailor> tailors, DbSet<AlteringTask> alteringTasks) : base(options)
    {
        Tailors = tailors;
        AlteringTasks = alteringTasks;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
    }

    public DbSet<Tailor> Tailors { get; set; }

    public DbSet<AlteringTask> AlteringTasks { get; set; }
}



