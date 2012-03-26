namespace Core.DomainModels
{
    public abstract class Entity : IEntity
    {
        protected bool IsPersistent
        {
            get { return IsPersistentObject(); }
        }

        #region IEntity Members

        public virtual int Id { get; set; }

        #endregion

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

        bool IsPersistentObject()
        {
            return (Id != 0);
        }
    }
}