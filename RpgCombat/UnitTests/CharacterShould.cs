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

            Assert.Equal(1000, character.Health);
        }
    }
}
