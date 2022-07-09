namespace SuitSupply.Framework.Domain
{
    public abstract class Entity : IEquatable<Entity>
    {
        protected Entity() : this(Guid.NewGuid())
        {
            if (this is ITrackableEntity)
            {
                var trackable = this as ITrackableEntity;
                trackable.CreationDate = DateTime.Now;
            }
        }

        protected Entity(Guid id)
        {
            Id = id;
        
        }

        public Guid Id { get; protected set; }

        public byte[] RowVersion { get; set; }


        public bool Equals(Entity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Entity)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}