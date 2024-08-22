using WorldLeague.Domain.Entities;
using WorldLeague.Domain.Repositories;

namespace WorldLeague.Infrastructure.Persistence.Repositories;

internal sealed class DrawRepository : IDrawRepository
{
    private readonly WorldLeagueDbContext _context;

    public DrawRepository(WorldLeagueDbContext context)
    {
        _context = context;
    }
    public async Task AddDrawAsync(Draw draw)
    {
        await _context.Draws.AddAsync(draw);
    }
}
