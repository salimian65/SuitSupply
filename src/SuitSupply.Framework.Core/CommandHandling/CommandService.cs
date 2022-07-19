using SuitSupply.Framework.Core.DependencyInjection;
using SuitSupply.Framework.Core.InternalEvents;

namespace SuitSupply.Framework.Core.CommandHandling
{
    public abstract class CommandService
    {
        protected ICommandBus CommandBus => ServiceLocator.Current.Resolve<ICommandBus>();

        protected IEnternalEventBus EnternalEventBus =>  ServiceLocator.Current.Resolve<IEnternalEventBus>();
    }
}
