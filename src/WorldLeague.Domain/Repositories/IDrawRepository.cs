using WorldLeague.Domain.Entities;

namespace WorldLeague.Domain.Repositories;

public interface IDrawRepository
{
    Task AddDrawAsync(Draw draw);
}
