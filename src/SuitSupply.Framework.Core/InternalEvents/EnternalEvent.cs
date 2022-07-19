namespace SuitSupply.Framework.Core.InternalEvents
{
    public abstract class EnternalEvent : IEnternalEvent
    {
        protected EnternalEvent()
        {
            TimeStamp = DateTime.Now;
        }

        public DateTime TimeStamp { get; }
    }
}