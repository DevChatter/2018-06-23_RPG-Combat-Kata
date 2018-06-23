﻿using RpgCombat;
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

            Assert.Equal(Character.INITIAL_HEALTH - 100, enemy.Health);
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
        public void DealMoreDamage_GivenWeakerEnemy()
        {
            var me = new Character { Level = 6 };
            var enemy = new Character { Level = 1 };

            me.DealDamageTo(enemy);

            Assert.Equal(Character.INITIAL_HEALTH - 150, enemy.Health);
        }

        [Fact]
        public void DealLessDamage_GivenStrongerEnemy()
        {
            var me = new Character { Level = 1 };
            var enemy = new Character { Level = 6 };

            me.DealDamageTo(enemy);

            Assert.Equal(Character.INITIAL_HEALTH - 50, enemy.Health);
        }
    }
}