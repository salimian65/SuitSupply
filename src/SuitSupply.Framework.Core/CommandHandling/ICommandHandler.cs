using SuitSupply.Framework.Domain;

namespace SuitSupply.Framework.Core.CommandHandling
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        IUnitOfWork UnitOfWork { get; }

        void Handle(TCommand command);
    }
}