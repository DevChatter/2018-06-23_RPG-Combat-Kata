using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RpgCombat
{
    public class Character
    {
        public FightingStyle FightingStyle { get; }
        public const int INITIAL_HEALTH = 1000;
        public const int BASE_DAMAGE = 100;
        public ISet<Faction> Factions { get; } = new HashSet<Faction>();

        public Character(FightingStyle fightingStyle = FightingStyle.Melee)
        {
            FightingStyle = fightingStyle;
        }

        public ILocation Location { get; set; } = new DistanceBasedLocation(0);
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
            if (enemy == this || EnemyOutOfRange(enemy))
            {
                return;
            }

            int damage = GetDamageAmount(enemy);

            enemy.Health -= damage;
        }

        private bool EnemyOutOfRange(Character enemy)
        {
            int range = 0;
            switch (FightingStyle)
            {
                case FightingStyle.Melee:
                    range = 2;
                    break;
                case FightingStyle.Ranged:
                    range = 20;
                    break;
            }

            return enemy.Location.DistanceFrom(Location) > range;
        }

        private int GetDamageAmount(Character enemy)
        {
            var damage = BASE_DAMAGE;

            if ((Level - 5) >= enemy.Level)
            {
                damage = GetWeakEnemyDamage();
            }

            if ((enemy.Level - 5) >= Level)
            {
                damage = GetStrongEnemyDamage();
            }

            return damage;
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

        public void JoinFaction(Faction faction)
        {
            Factions.Add(faction);
        }

        public void LeaveFaction(Faction faction)
        {
            Factions.Remove(faction);
        }

        public bool IsAnAlly(Character other) => Factions.Overlaps(other.Factions);
    }
}
