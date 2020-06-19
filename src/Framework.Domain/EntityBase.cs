using System;

namespace Framework.Domain
{
    public class EntityBase<TKey>
    {
        public virtual TKey Id { get; protected set; }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;

            var entity = (EntityBase<TKey>) obj;
            return this.Id.Equals(entity.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        protected virtual byte[] Timestamp { get; set; }
        public virtual string Version
        {
            get { return Timestamp != null && Timestamp.Length > 0 ? Convert.ToBase64String(Timestamp) : null; }
            set { Timestamp = value != null && value.Length > 0 ? Convert.FromBase64String(value) : null; }
        }
    }
}