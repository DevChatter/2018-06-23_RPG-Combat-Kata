using RpgCombat;
using Xunit;

namespace UnitTests
{
    public class HealCharacterShould
    {
        [Fact]
        public void RaiseHealthOfInjuredCharacter()
        {
            var me = new Character();
            var toHeal = new Character { Health = 1 };

            me.HealCharacter(toHeal);

            Assert.Equal(101, toHeal.Health);
        }

        [Fact]
        public void NeverHealAboveStartingHealth()
        {
            var me = new Character();
            var toHeal = new Character();

            me.HealCharacter(toHeal);
            me.HealCharacter(toHeal);

            Assert.Equal(1000, toHeal.Health);
        }

        [Fact]
        public void DoNothing_GivenDeadCharacter()
        {
            var me = new Character();
            var deadGuy = new Character { Health = 0, IsAlive = false };

            me.HealCharacter(deadGuy);

            Assert.Equal(0, deadGuy.Health);
            Assert.False(deadGuy.IsAlive);
        }
    }
}