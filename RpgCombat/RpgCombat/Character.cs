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
            if (enemy == this)
            {
                return;
            }

            var damage = 100;

            if ((Level-5) >= enemy.Level)
            {
                damage += 50;
            }

            if ((enemy.Level -5) >= Level)
            {
                damage -= 50;
            }

            enemy.Health -= damage;
        }

        public void HealCharacter(Character characterToHeal)
        {
            if (characterToHeal != this)
            {
                return;
            }

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
