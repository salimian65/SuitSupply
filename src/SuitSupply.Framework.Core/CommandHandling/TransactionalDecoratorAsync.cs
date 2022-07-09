namespace SuitSupply.Framework.Core.CommandHandling;

public class TransactionalDecoratorAsync<TCommand> : ICommandHandlerAsync<TCommand> where TCommand : ICommand
{
    private static readonly object LockObject = new object();

    private readonly ICommandHandlerAsync<TCommand> commandHandler;

    public TransactionalDecoratorAsync(ICommandHandlerAsync<TCommand> commandHandler)
    {
        this.commandHandler = commandHandler;
        UnitOfWork = commandHandler.UnitOfWork;
    }

    public IUnitOfWork UnitOfWork { get; }

    public async Task HandleAsync(TCommand command)
    {
        await commandHandler.HandleAsync(command);

        if (!(commandHandler is ITransactionIgnorable))
        {
            UnitOfWork.Commit();
        }
    }
}