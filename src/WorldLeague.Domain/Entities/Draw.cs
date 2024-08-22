using System;
using WorldLeague.Domain.Abstractions;
using WorldLeague.Domain.Exceptions;

namespace WorldLeague.Domain.Entities;

public sealed class Draw : Entity
{
    public string DrawerName { get; private set; }
    public string DrawerLastName { get; private set; }
    public DateTime DrawedAt { get; private set; }

    private List<Group> _groups = new();
    public IReadOnlyCollection<Group> Groups => _groups.AsReadOnly();

    public Draw(string drawerName, string drawerLastName)
    {
        DrawerName = drawerName;
        DrawerLastName = drawerLastName;
        DrawedAt = DateTime.UtcNow;
    }


    /// <summary>
    /// Create groups and distribute teams to groups
    /// </summary>
    /// <param name="countries">
    /// Teams will be selected from these countries
    /// </param>
    /// <param name="numberOfGroups">
    /// Must be 4 or 8
    /// </param>
    /// <exception cref="NumberOfGroupsOutOfRangeException">
    /// Throws when the number of groups is not 4 or 8
    /// </exception>
    public void CreateGroupsAndDistributeTeams(List<Country> countries, int numberOfGroups)
    {
        if (numberOfGroups != 4 && numberOfGroups != 8)
        {
            throw new NumberOfGroupsOutOfRangeException();
        }

        var random = new Random();

        var shuffledTeams = countries.SelectMany(x => x.Teams).OrderBy(x => random.Next()).ToList();

        var groups = Enumerable.Range(0, numberOfGroups)
            .Select(i => ((char)('A' + i)).ToString())
            .Select(groupName => new Group(groupName, this))
            .ToList();

        var groupSize = shuffledTeams.Count / numberOfGroups;

        while (shuffledTeams.Count > 0)
        {

            foreach (var group in groups)
            {
                if (group.Teams.Count == groupSize)
                    continue;

                var availableTeams = shuffledTeams.Where(t => !group.HasTeamFromCountry(t.Country)).ToList();

                if (availableTeams.Count == 0) continue;

                var selectedTeam = availableTeams.OrderBy(t => shuffledTeams.Count(st => st.Country == t.Country)).First();

                group.AddTeam(selectedTeam);
                shuffledTeams.Remove(selectedTeam);
            }
        }

        _groups = groups;
    }



}
