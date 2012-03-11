namespace Core
{
    public abstract class Entity : IEntity
    {
        public virtual int Id { get; set; }

        public virtual bool IsPersistent
        {
            get { return IsPersistentObject(); }
        }

        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (IsPersistent)
            {
                return (other != null) && (Id == other.Id);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return IsPersistentObject() ? Id.GetHashCode() : base.GetHashCode();
        }

        private bool IsPersistentObject()
        {
            return (Id != 0);
        }
    }
}