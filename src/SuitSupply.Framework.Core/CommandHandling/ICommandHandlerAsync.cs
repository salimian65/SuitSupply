using SuitSupply.Framework.Domain;

namespace SuitSupply.Framework.Core.CommandHandling;

public interface ICommandHandlerAsync<in TCommand> where TCommand : ICommand
{
    IUnitOfWork UnitOfWork { get; }

    Task HandleAsync(TCommand command);
}