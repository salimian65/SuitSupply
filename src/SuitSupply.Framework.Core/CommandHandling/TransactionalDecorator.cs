namespace SuitSupply.Framework.Core.CommandHandling
{
    public class TransactionalDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> commandHandler;
        private readonly IEventBus bus;

        public TransactionalDecorator(ICommandHandler<TCommand> commandHandler, IEventBus bus)
        {
            this.commandHandler = commandHandler;
            this.bus = bus;
            UnitOfWork = commandHandler.UnitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        public void Handle(TCommand command)
        {
            commandHandler.Handle(command);

            if (!(commandHandler is ITransactionIgnorable))
            {
                UnitOfWork.Commit();
                PublishTransactionCommitedEvent();
            }
        }

        private void PublishTransactionCommitedEvent()
        {
            if (System.Transactions.Transaction.Current == null)
            {
                bus.Publish(new TransactionCommitedEvent());
            }
        }
    }
}