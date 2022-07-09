using SuitSupply.Framework.Domain;

namespace SuitSupply.Framework.Core.CommandHandling
{
    public abstract class CommandHandler
    {
        protected CommandHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }        
    }
}