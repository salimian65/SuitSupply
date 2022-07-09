using SuitSupply.Framework.Core.Events;

namespace SuitSupply.Framework.Core.CommandHandling
{
    public abstract class CommandService
    {
        protected ICommandBus CommandBus => ServiceLocator.Current.Resolve<ICommandBus>();

        protected IEventBus EventBus => ServiceLocator.Current.Resolve<IEventBus>();
    }
}
