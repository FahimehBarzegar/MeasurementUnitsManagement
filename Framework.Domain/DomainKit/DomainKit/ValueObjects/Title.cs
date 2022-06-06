using Framework.Domain;

namespace DomainKit.ValueObjects
{
    public class Title : BaseValueObject<Title>
    {
        public string Value { get; private set; }

        public Title(string value)
        {
            Value = value;
        }

        public override bool ObjectIsEqual(Title otherObject)
        {
            if (Value == otherObject.Value)
                return true;

            return false;
        }

        public override int ObjectGetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
