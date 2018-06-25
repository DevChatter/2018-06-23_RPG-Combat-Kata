using RpgCombat;
using Xunit;

namespace UnitTests
{
    public class ThingShould
    {
        [Fact]
        public void StartWithIsDestroyedBeingFalse()
        {
            var thing = new Thing();

            Assert.False(thing.IsDestroyed);
        }
    }
}