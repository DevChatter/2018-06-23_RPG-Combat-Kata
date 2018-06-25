using System;

namespace RpgCombat
{
    public class Faction : IEquatable<Faction>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public bool Equals(Faction other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Faction) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}