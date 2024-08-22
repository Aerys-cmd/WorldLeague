using Microsoft.EntityFrameworkCore;
using WorldLeague.Domain.Entities;
using WorldLeague.Domain.Repositories;

namespace WorldLeague.Infrastructure.Persistence.Repositories;

internal sealed class CountryRepository : ICountryRepository
{
    private readonly WorldLeagueDbContext _context;

    public CountryRepository(WorldLeagueDbContext context)
    {
        _context = context;
    }

    public async Task<List<Country>> GetAllAsync()
    {
        return await _context.Countries
            .Include(c => c.Teams)
            .ThenInclude(t => t.Country)
            .ToListAsync();
    }
}
