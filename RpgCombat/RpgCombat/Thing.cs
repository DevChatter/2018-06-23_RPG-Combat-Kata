namespace RpgCombat
{
    public class Thing : IDamageable
    {
        public int Health { get; set; } = 1000;
        public bool IsDestroyed => Health <= 0;
    }
}