using RpgCombat;
using Xunit;

namespace UnitTests
{
    public class JoinFactionShould
    {
        [Fact]
        public void AddFactionToFactionsList_GivenNewFaction()
        {
            var character = new Character();
            var faction = new Faction();

            character.JoinFaction(faction);

            Assert.Contains(faction, character.Factions);
        }

        [Fact]
        public void NotAddFactionToFactionsList_GivenExistingFaction()
        {
            var character = new Character();
            var faction = new Faction();

            character.JoinFaction(faction);
            character.JoinFaction(faction);

            Assert.Single(character.Factions);
        }
    }
}