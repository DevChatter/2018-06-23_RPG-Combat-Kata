using RpgCombat;
using Xunit;

namespace UnitTests
{
    public class CharacterShould
    {
        [Fact]
        public void StartOutAlive()
        {
            var character = new Character();

            Assert.True(character.IsAlive);
        }

        [Fact]
        public void StartAtLevelOne()
        {
            var character = new Character();

            Assert.Equal(1, character.Level);
        }

        [Fact]
        public void StartAt1000Health()
        {
            var character = new Character();

            Assert.Equal(Character.INITIAL_HEALTH, character.Health);
        }

        [Fact]
        public void StartWithoutAnyFactions()
        {
            var character = new Character();

            Assert.Empty(character.Factions);
        }
    }
}
