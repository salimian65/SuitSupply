using Microsoft.Extensions.Logging;
using SuitSupply.Framework.Core.DependencyInjection;
using SuitSupply.Framework.Core.InternalEvents;

namespace SuitSupply.Framework.Core.CommandHandling
{
    public class CommandBus : ICommandBus
    {
        private readonly ILogger logger;

        public CommandBus(ILogger logger)
        {
            this.logger = logger;
        }

        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler = ServiceLocator.Current.Resolve<ICommandHandler<TCommand>>();
            var eventBus = ServiceLocator.Current.Resolve<IEnternalEventBus>();
            var commandHandlerWithTransactionDecorator = new TransactionalDecorator<TCommand>(commandHandler, eventBus);
            var commandHandlerWithCommandLogDecorator = new CommandLogDecorator<TCommand>(commandHandlerWithTransactionDecorator, logger);
            commandHandlerWithCommandLogDecorator.Handle(command);
        }

        public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler = ServiceLocator.Current.Resolve<ICommandHandlerAsync<TCommand>>();
            var commandHandlerWithTransactionDecorator = new TransactionalDecoratorAsync<TCommand>(commandHandler);
            var commandHandlerWithCommandLogDecorator = new CommandLogDecoratorAsync<TCommand>(commandHandlerWithTransactionDecorator, logger);
            await commandHandlerWithCommandLogDecorator.HandleAsync(command);
        }
    }
}