using System;
namespace TypecastAPI.Domain.Models
{
    public abstract class BaseModel
    {
        public Guid Guid { get; set; }

        public BaseModel()
        {
            this.Guid = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as BaseModel);
        }

        public virtual bool Equals(BaseModel other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public static bool operator ==(BaseModel x, BaseModel y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(BaseModel x, BaseModel y)
        {
            return !(x == y);
        }
    }
}
