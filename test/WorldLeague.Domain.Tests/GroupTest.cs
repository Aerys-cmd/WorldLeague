using WorldLeague.Domain.Entities;
using WorldLeague.Domain.Exceptions;
namespace WorldLeague.Domain.Tests;

public class GroupTest 
{

     [Fact]
    public void Group_Should_Be_Created_With_Valid_Name()
    {
        var draw = new Draw("John", "Doe");

        draw.CreateGroupsAndDistributeTeams(new List<Country>(), 4);

        var group = draw.Groups.First();

        Assert.True(group.Name == "A");
    }

    [Fact]
    public void Group_Should_Not_Have_Two_Teams_With_Same_Country()
    {
        var draw = new Draw("John", "Doe");

        var group = new Group("A", draw);

        var country = new Country("Türkiye");

        country.AddTeam("Adesso İstanbul");

        country.AddTeam("Adesso Ankara");

        var team1 = country.Teams.First();

        var team2 = country.Teams.TakeLast(1).First();

        group.AddTeam(team1);

        Assert.Throws<CantAddMoreThanOneTeamFromOneCountryException>(() => group.AddTeam(team2));


    }
}
