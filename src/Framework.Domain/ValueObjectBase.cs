using Framework.Core;

namespace Framework.Domain
{
    public class ValueObjectBase
    {
        public override bool Equals(object obj)
        {
            return EqualsBuilder.ReflectionEquals(this, obj);
        }

        public override int GetHashCode()
        {
            return HashCodeBuilder.ReflectionHashCode(this);
        }
    }
}