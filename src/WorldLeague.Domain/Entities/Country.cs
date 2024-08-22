using WorldLeague.Domain.Abstractions;

namespace WorldLeague.Domain.Entities;

public sealed class Country : Entity
{
    public string Name { get; private set; }

    private List<Team> _teams = new();
    public IReadOnlyCollection<Team> Teams => _teams.AsReadOnly();

    public Country(string name)
    {
        Name = name;
    }

    public void AddTeam(string team)
    {
        _teams.Add(new Team(team, this));
    }

}
