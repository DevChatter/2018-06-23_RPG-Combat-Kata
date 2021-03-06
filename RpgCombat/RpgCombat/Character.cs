﻿using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace RpgCombat
{
    public class Character : IDamageable
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

        public void DealDamageTo(IDamageable target)
        {
            if (target == this || IsInvalidTarget(target))
            {
                return;
            }

            int damage = GetDamageAmount(target);

            target.Health -= damage;
        }

        private bool IsInvalidTarget(IDamageable target)
        {
            if (target is Character character)
            {
                return IsAnAlly(character) || EnemyOutOfRange(character);
            }

            return false;
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

        private int GetDamageAmount(IDamageable enemy)
        {
            var damage = BASE_DAMAGE;

            if (enemy is Character character)
            {
                if ((Level - 5) >= character.Level)
                {
                    damage = GetWeakEnemyDamage();
                }

                if ((character.Level - 5) >= Level)
                {
                    damage = GetStrongEnemyDamage();
                }
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
            if (characterToHeal != this && !IsAnAlly(characterToHeal))
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
