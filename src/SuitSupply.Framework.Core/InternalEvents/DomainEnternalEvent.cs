namespace SuitSupply.Framework.Core.InternalEvents
{
    public abstract class DomainEnternalEvent : EnternalEvent
    {
        protected DomainEnternalEvent(Guid entityId)
        {
            EntityId = entityId;
        }

        public Guid EntityId { get; }
    }
}