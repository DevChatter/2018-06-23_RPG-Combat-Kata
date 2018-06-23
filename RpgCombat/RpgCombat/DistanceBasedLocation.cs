namespace RpgCombat
{
    public class DistanceBasedLocation : ILocation
    {
        private readonly int _distanceFrom;

        public DistanceBasedLocation(int distanceFrom)
        {
            _distanceFrom = distanceFrom;
        }
        public int DistanceFrom(ILocation location)
        {
            return _distanceFrom;
        }
    }
}