using WorldLeague.Domain.Abstractions;

namespace WorldLeague.Domain.Entities;

public sealed class GroupTeam : Entity
{
    public Team Team { get; init; }
    public Group Group { get; init; }
    public GroupTeam(Team team, Group group)
    {
        Team = team;
        Group = group;
    }
    /// <summary>
    /// For EF Core Mapping
    /// </summary>
    private GroupTeam()
    {
    }
}
