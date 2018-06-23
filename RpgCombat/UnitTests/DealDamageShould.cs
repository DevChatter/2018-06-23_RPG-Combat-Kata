using RpgCombat;
using Xunit;

namespace UnitTests
{
    public class DealDamageShould
    {
        [Fact]
        public void SubtractFromEnemyHealth()
        {
            var me = new Character();
            var enemy = new Character();

            me.DealDamageTo(enemy);

            Assert.Equal(900, enemy.Health);
        }

        [Fact]
        public void MakeCharacterDead_GivenEnoughDamageDone()
        {
            var me = new Character();
            var enemy = new Character { Health = 1 };

            me.DealDamageTo(enemy);

            Assert.False(enemy.IsAlive);
        }

        [Fact]
        public void FloorHealthAtZero_RegardlessOfDamageDone()
        {
            var me = new Character();
            var enemy = new Character { Health = 1 };

            me.DealDamageTo(enemy);
            me.DealDamageTo(enemy);

            Assert.Equal(0, enemy.Health);
        }
    }
}