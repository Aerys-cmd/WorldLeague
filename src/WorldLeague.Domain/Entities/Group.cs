using WorldLeague.Domain.Abstractions;
using WorldLeague.Domain.Exceptions;

namespace WorldLeague.Domain.Entities;

public sealed class Group : Entity
{
    public string Name { get; init; }

    public Draw Draw { get; init; }

    private List<GroupTeam> _teams = new();
    public IReadOnlyCollection<GroupTeam> Teams => _teams.AsReadOnly();

    public Group(string name, Draw draw)
    {
        Name = name;
        Draw = draw;
    }

    public void AddTeam(Team team)
    {
        if (_teams.Any(x => x.Team.Country == team.Country))
        {
            throw new CantAddMoreThanOneTeamFromOneCountryException();
        }

        _teams.Add(new GroupTeam(team, this));
    }

    public bool HasTeamFromCountry(Country country)
    {
        return _teams.Any(x => x.Team.Country == country);
    }


    private Group()
    {
    }

}
