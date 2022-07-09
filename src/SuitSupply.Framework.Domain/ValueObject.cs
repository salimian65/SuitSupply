namespace SuitSupply.Framework.Domain
{
    public abstract class ValueObject<TValueObject> : IValueObject<TValueObject>
    {
        public abstract bool Equals(TValueObject other);
    }
}