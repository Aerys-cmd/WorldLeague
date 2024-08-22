using Microsoft.EntityFrameworkCore;
using WorldLeague.Application.Abstractions;
using WorldLeague.Domain.Entities;

namespace WorldLeague.Infrastructure.Persistence;

internal class WorldLeagueDbContext : DbContext , IUnitOfWork
{
    public WorldLeagueDbContext(DbContextOptions<WorldLeagueDbContext> options) : base(options)
    {
    }

    public DbSet<Draw> Draws { get; set; }
    public DbSet<Country> Countries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorldLeagueDbContext).Assembly);
    }

}
