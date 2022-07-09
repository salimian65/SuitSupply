using System;

namespace SuitSupply.Framework.Core.Events
{
    public abstract class DomainEvent : Event
    {
        protected DomainEvent(Guid entityId)
        {
            EntityId = entityId;
        }

        public Guid EntityId { get; }
    }
}