namespace RpgCombat
{
    public class Character
    {
        public const int INITIAL_HEALTH = 1000;

        private int _health = INITIAL_HEALTH;
        public bool IsAlive { get; set; } = true;
        public int Level { get; set; } = 1;

        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                if (_health <= 0)
                {
                    IsAlive = false;
                    _health = 0;
                }
            }
        }

        public void DealDamageTo(Character enemy)
        {
            enemy.Health -= 100;
        }

        public void HealCharacter(Character characterToHeal)
        {
            if (characterToHeal.IsAlive)
            {
                characterToHeal.Health += 100;
            }

            if (characterToHeal.Health > INITIAL_HEALTH)
            {
                characterToHeal.Health = INITIAL_HEALTH;
            }
        }
    }
}
