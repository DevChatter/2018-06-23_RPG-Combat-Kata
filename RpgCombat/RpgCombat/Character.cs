namespace RpgCombat
{
    public class Character
    {
        public const int INITIAL_HEALTH = 1000;
        public const int BASE_DAMAGE = 100;

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

            var damage = BASE_DAMAGE;

            if ((Level-5) >= enemy.Level)
            {
                damage = GetWeakEnemyDamage();
            }

            if ((enemy.Level -5) >= Level)
            {
                damage = GetStrongEnemyDamage();
            }

            enemy.Health -= damage;
        }

        public static int GetStrongEnemyDamage()
        {
            return BASE_DAMAGE - 50;
        }

        public static int GetWeakEnemyDamage()
        {
            return BASE_DAMAGE + 50;
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
