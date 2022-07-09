using Microsoft.Extensions.Logging;

namespace SuitSupply.Framework.Core.CommandHandling;

public class CommandLogDecoratorAsync<TCommand> :
    ICommandHandlerAsync<TCommand> where TCommand : ICommand
{
    private readonly ICommandHandlerAsync<TCommand> commandHandler;

    private readonly ILogger logger;

    public CommandLogDecoratorAsync(ICommandHandlerAsync<TCommand> commandHandler, ILogger logger)
    {
        this.commandHandler = commandHandler;
        this.logger = logger;
        UnitOfWork = commandHandler.UnitOfWork;
    }

    public IUnitOfWork UnitOfWork { get; }

    public async Task HandleAsync(TCommand command)
    {
        try
        {
            logger.Information(command);
            await commandHandler.HandleAsync(command);
            logger.Information(command);
        }
        catch (Exception ex)
        {
            UnitOfWork.RejectChanges();
            logger.Error(ex);
            throw;
        }
    }
}