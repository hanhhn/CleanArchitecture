using System.ComponentModel;
using Coffee.Infrastructure.Interfaces;

namespace Coffee.Infrastructure.Abtractions
{
    public abstract class BaseEntity<T> : IEntityRoot, IAuditableEntity
    {
        public T Id { get; set; }
        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public string UpdatedBy { get; private set; }
        public byte[] Version { get; private set; }
        public bool IsDeleted { get; private set; }

        public BaseEntity()
        {
            if (typeof(T).ToString() == typeof(string).ToString())
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
                Id = (T)converter.ConvertFromInvariantString(Guid.NewGuid().ToString());
            }
        }

        public virtual void Delete()
        {
            IsDeleted = true;
        }

        public virtual void UnDelete()
        {
            IsDeleted = false;
        }

        public void SetCreatedBy(string by)
        {
            CreatedAt = DateTime.Now;
            CreatedBy = by;
        }

        public void SetUpdatedBy(string by)
        {
            UpdatedAt = DateTime.Now;
            UpdatedBy = by;
        }

        public object[] GetKeys()
        {
            throw new NotImplementedException();
        }
    }
}

