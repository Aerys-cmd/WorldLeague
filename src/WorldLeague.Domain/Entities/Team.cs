using WorldLeague.Domain.Abstractions;

namespace WorldLeague.Domain.Entities;

public class Team : Entity
{
    public string Name { get; private set; }
    public Country Country { get; private set; }

    public Team(string name, Country country)
    {

        Name = name;
        Country = country;
    }
    /// <summary>
    /// For EF Core Mapping
    /// </summary>
    private Team()
    {
    }
}
