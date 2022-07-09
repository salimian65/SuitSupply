using Microsoft.Extensions.Logging;
using SuitSupply.Framework.Domain;

namespace SuitSupply.Framework.Core.CommandHandling
{
    public class CommandLogDecorator<TCommand> :
        ICommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> commandHandler;

        private readonly ILogger logger;

        public CommandLogDecorator(ICommandHandler<TCommand> commandHandler, ILogger logger)
        {
            this.commandHandler = commandHandler;
            this.logger = logger;
            UnitOfWork = commandHandler.UnitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        public void Handle(TCommand command)
        {
            try
            {
                logger.LogInformation(command.ToString());
                commandHandler.Handle(command);
                logger.LogInformation(command.ToString());
            }
            catch (Exception ex)
            {
                UnitOfWork.RejectChanges();
                logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}