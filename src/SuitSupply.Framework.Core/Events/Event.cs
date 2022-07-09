using System;

namespace SuitSupply.Framework.Core.Events
{
    public abstract class Event : IEvent
    {
        protected Event()
        {
            TimeStamp = DateTime.Now;
        }

        public DateTime TimeStamp { get; }
    }
}