namespace SuitSupply.Framework.Core.CommandHandling
{
    public interface ICommandBus
    {
        void Dispatch<TCommand>(TCommand command) where TCommand : ICommand;

        Task DispatchAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}