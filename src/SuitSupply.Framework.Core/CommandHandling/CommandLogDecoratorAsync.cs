using Microsoft.Extensions.Logging;
using SuitSupply.Framework.Domain;

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
            logger.LogInformation(command.ToString());
            await commandHandler.HandleAsync(command);
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