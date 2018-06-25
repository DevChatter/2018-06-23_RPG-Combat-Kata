using RpgCombat;
using Xunit;

namespace UnitTests
{
    public class LeaveFactionShould
    {
        [Fact]
        public void RemoveFactionFromFactionsList_GivenExistingFaction()
        {
            var character = new Character();
            var faction = new Faction();

            character.JoinFaction(faction);
            character.LeaveFaction(faction);

            Assert.Empty(character.Factions);
        }

        [Fact]
        public void DoNothing_GivenNonJoinedFaction()
        {
            var character = new Character();

            character.LeaveFaction(new Faction());

            Assert.Empty(character.Factions);
        }
    }
}