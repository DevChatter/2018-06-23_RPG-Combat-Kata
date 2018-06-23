namespace RpgCombat
{
    public interface ILocation
    {
        int DistanceFrom(ILocation location);
    }
}