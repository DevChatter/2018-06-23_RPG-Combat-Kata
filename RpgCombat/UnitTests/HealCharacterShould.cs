using RpgCombat;
using Xunit;

namespace UnitTests
{
    public class HealCharacterShould
    {
        [Fact]
        public void DoNothing_GivenTryingToHealSomeoneElse()
        {
            var me = new Character();
            var toHeal = new Character { Health = 1 };

            me.HealCharacter(toHeal);

            Assert.Equal(1, toHeal.Health);
        }

        [Fact]
        public void RaiseHealthOfInjuredCharacter()
        {
            var toHeal = new Character { Health = 1 };

            toHeal.HealCharacter(toHeal);

            Assert.Equal(101, toHeal.Health);
        }

        [Fact]
        public void NeverHealAboveStartingHealth()
        {
            var toHeal = new Character();

            toHeal.HealCharacter(toHeal);
            toHeal.HealCharacter(toHeal);

            Assert.Equal(Character.INITIAL_HEALTH, toHeal.Health);
        }

        [Fact]
        public void DoNothing_GivenDeadCharacter()
        {
            var deadGuy = new Character { Health = 0, IsAlive = false };

            deadGuy.HealCharacter(deadGuy);

            Assert.Equal(0, deadGuy.Health);
            Assert.False(deadGuy.IsAlive);
        }
    }
}