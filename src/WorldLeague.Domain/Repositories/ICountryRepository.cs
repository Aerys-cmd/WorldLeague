using WorldLeague.Domain.Entities;

namespace WorldLeague.Domain.Repositories;

public interface ICountryRepository
{

    /// <summary>
    /// Gets all countries with their teams.
    /// </summary>
    /// <returns>
    /// A list of countries with their teams.
    /// </returns>
    Task<List<Country>> GetAllAsync();
}
