namespace RpgCombat
{
    public class Character
    {
        private int _health = 1000;
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

            if (characterToHeal.Health > 1000)
            {
                characterToHeal.Health = 1000;
            }
        }
    }
}
