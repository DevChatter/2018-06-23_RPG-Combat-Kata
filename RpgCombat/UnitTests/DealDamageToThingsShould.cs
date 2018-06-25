using RpgCombat;
using Xunit;

namespace UnitTests
{
    public class DealDamageToThingsShould
    {
        [Fact]
        public void ReduceHealthOfThings_WhenDamagedByCharacters()
        {
            var character = new Character();
            var thing = new Thing { Health = 1000 };

            character.DealDamageTo(thing);

            Assert.Equal(900, thing.Health);
        }

        [Fact]
        public void MakeItDestroyed_WhenDamagedToZero()
        {
            var character = new Character();
            var thing = new Thing { Health = 1 };

            character.DealDamageTo(thing);

            Assert.True(thing.IsDestroyed);
        }
    }
}