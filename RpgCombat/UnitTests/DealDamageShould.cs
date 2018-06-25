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

            Assert.Equal(Character.INITIAL_HEALTH - Character.BASE_DAMAGE, enemy.Health);
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

        [Fact]
        public void NotDealDamageToSelf()
        {
            var me = new Character();

            me.DealDamageTo(me);

            Assert.Equal(Character.INITIAL_HEALTH, me.Health);
        }

        [Fact]
        public void NotDealDamageToAllies()
        {
            var faction = new Faction();
            var me = new Character{Factions = { faction }};
            var ally = new Character{Factions = { faction }};

            me.DealDamageTo(ally);

            Assert.Equal(Character.INITIAL_HEALTH, ally.Health);
        }

        [Fact]
        public void DealMoreDamage_GivenWeakerEnemy()
        {
            var me = new Character { Level = 6 };
            var enemy = new Character { Level = 1 };

            me.DealDamageTo(enemy);

            int expected = Character.INITIAL_HEALTH - Character.GetWeakEnemyDamage();
            Assert.Equal(expected, enemy.Health);
        }

        [Fact]
        public void DealLessDamage_GivenStrongerEnemy()
        {
            var me = new Character { Level = 1 };
            var enemy = new Character { Level = 6 };

            me.DealDamageTo(enemy);

            int expected = Character.INITIAL_HEALTH - Character.GetStrongEnemyDamage();
            Assert.Equal(expected, enemy.Health);
        }
    }
}