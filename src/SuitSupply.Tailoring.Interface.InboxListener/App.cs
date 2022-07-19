using SuitSupply.Framework.Core.ExternalEvents;

namespace SuitSupply.Tailoring.Interface.InboxListener
{
    public class App
    {
        private readonly ISubscriber _subscriber;
        
        public App(ISubscriber subscriber)
        {
            _subscriber = subscriber;
        }

        public void Run()
        {
            _subscriber.Subscribe();
        }
    }
}