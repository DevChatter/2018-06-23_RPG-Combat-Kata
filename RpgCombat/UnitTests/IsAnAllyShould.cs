using RpgCombat;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class IsAnAllyShould
    {
        [Fact]
        public void ReturnTrue_GivenCharactersInSameFaction()
        {
            var faction = new Faction();
            var (character1, character2) = 
                GetTestCharacters(new[] { faction }, new[] { faction });

            Assert.True(character1.IsAnAlly(character2));
            Assert.True(character2.IsAnAlly(character1));
        }

        [Fact]
        public void ReturnTrue_GivenCharactersInSameSetOfFactions()
        {
            var faction1 = new Faction();
            var faction2 = new Faction();
            var (character1, character2) =
                GetTestCharacters(new[] { faction1, faction2 }, new[] { faction1, faction2 });

            Assert.True(character1.IsAnAlly(character2));
            Assert.True(character2.IsAnAlly(character1));
        }

        [Fact]
        public void ReturnTrue_GivenCharactersWithOneMatchingFaction()
        {
            var faction = new Faction();
            var (character1, character2) =
                GetTestCharacters(new[] { faction, new Faction() },
                    new[] { new Faction(), faction });

            Assert.True(character1.IsAnAlly(character2));
            Assert.True(character2.IsAnAlly(character1));
        }

        [Fact]
        public void ReturnFalse_GivenNoFaction()
        {
            var (character1, character2) =
                GetTestCharacters(new Faction[] { }, new Faction[] { });

            Assert.False(character1.IsAnAlly(character2));
            Assert.False(character2.IsAnAlly(character1));
        }

        [Fact]
        public void ReturnFalse_GivenUnmatchingFaction()
        {
            var (character1, character2) =
                GetTestCharacters(new[] { new Faction() }, new[] { new Faction() });

            Assert.False(character1.IsAnAlly(character2));
            Assert.False(character2.IsAnAlly(character1));
        }

        private (Character, Character) GetTestCharacters(
            IEnumerable<Faction> factions1,
            IEnumerable<Faction> factions2)
        {
            var character1 = new Character();
            var character2 = new Character();

            foreach (var faction in factions1)
            {
                character1.JoinFaction(faction);
            }

            foreach (var faction in factions2)
            {
                character2.JoinFaction(faction);
            }

            return (character1, character2);
        }

    }
}