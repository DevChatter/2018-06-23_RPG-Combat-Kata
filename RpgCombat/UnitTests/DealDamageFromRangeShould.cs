using RpgCombat;
using Xunit;

namespace UnitTests
{
    public class DealDamageFromRangeShould
    {
        [Fact]
        public void NotDealDamage_GivenMeleeCharacterAtRange()
        {
            var me = new Character();
            var enemy = new Character { Location = new DistanceBasedLocation(20) };

            me.DealDamageTo(enemy);

            Assert.Equal(Character.INITIAL_HEALTH, enemy.Health);
        }
    }
}