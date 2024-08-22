using WorldLeague.Domain.Entities;
using WorldLeague.Domain.Exceptions;

namespace WorldLeague.Domain.Tests
{
    public class DrawTest
    {
        [Fact]
        public void Draw_Should_Not_Be_Performed_With_Invalid_Numbers_Of_Groups()
        {
            var draw = new Draw("John", "Doe");

            Assert.Throws<NumberOfGroupsOutOfRangeException>(() => draw.CreateGroupsAndDistributeTeams(new List<Country>(), 5));

        }

        [Fact]
        public void Draw_Should_Be_Performed_With_Valid_Numbers_Of_Groups()
        {
            var drawWith4Groups = new Draw("John", "Doe");

            drawWith4Groups.CreateGroupsAndDistributeTeams(new List<Country>(), 4);

            Assert.True(drawWith4Groups.Groups.Count == 4);

            var drawWith8Groups = new Draw("John", "Doe");

            drawWith8Groups.CreateGroupsAndDistributeTeams(new List<Country>(), 8);

            Assert.True(drawWith8Groups.Groups.Count == 8);
        }
        [Fact]
        public void Draw_Should_Be_Vald_With_4_Groups()
        {
            var draw = new Draw("John", "Doe");


            draw.CreateGroupsAndDistributeTeams(CreateTestCountriesData(), 4);

            Assert.True(draw.Groups.All(group => group.Teams.Count == 8));

            Assert.True(draw.Groups.All(group => group.Teams.Select(team => team.Team.Country).Distinct().Count() == 8));
        }

        [Fact]

        public void Draw_Should_Be_Valid_With_8_Groups()
        {
            var draw = new Draw("John", "Doe");

            draw.CreateGroupsAndDistributeTeams(CreateTestCountriesData(), 8);

            Assert.True(draw.Groups.All(group => group.Teams.Count == 4));

            Assert.True(draw.Groups.All(group => group.Teams.Select(team => team.Team.Country).Distinct().Count() == 4));
        }


        private List<Country> CreateTestCountriesData()
        {

            var country1 = new Country("Türkiye");

            country1.AddTeam("Adesso Ýstanbul");

            country1.AddTeam("Adesso Ankara");

            country1.AddTeam("Adesso Ýzmir");

            country1.AddTeam("Adesso Antalya");

            var country2 = new Country("Almanya");

            country2.AddTeam("Adesso Berlin");

            country2.AddTeam("Adesso Münih");

            country2.AddTeam("Adesso Frankfurt");

            country2.AddTeam("Adesso Dortmund");

            var country3 = new Country("Ýtalya");

            country3.AddTeam("Adesso Roma");

            country3.AddTeam("Adesso Milano");

            country3.AddTeam("Adesso Porto");

            country3.AddTeam("Adesso Venedik");

            var country4 = new Country("Ýspanya");

            country4.AddTeam("Adesso Madrid");

            country4.AddTeam("Adesso Barselona");

            country4.AddTeam("Adesso Sevilla");

            country4.AddTeam("Adesso Granada");

            var country5 = new Country("Fransa");

            country5.AddTeam("Adesso Paris");

            country5.AddTeam("Adesso Marsilya");

            country5.AddTeam("Adesso Nice");

            country5.AddTeam("Adesso Lyon");

            var country6 = new Country("Hollanda");

            country6.AddTeam("Adesso Amsterdam");

            country6.AddTeam("Adesso Rotterdam");

            country6.AddTeam("Adesso Lahey");

            country6.AddTeam("Adesso Eindhoven");


            var country7 = new Country("Portekiz");

            country7.AddTeam("Adesso Lizbon");

            country7.AddTeam("Adesso Porto");

            country7.AddTeam("Adesso Braga");

            country7.AddTeam("Adesso Coimbra");

            var country8 = new Country("Belçika");

            country8.AddTeam("Adesso Brüksel");

            country8.AddTeam("Adesso Brugge");

            country8.AddTeam("Adesso Gent");

            country8.AddTeam("Adesso Anvers");


            return [country1, country2, country3, country4, country5, country6, country7, country8];
        }


    }
}