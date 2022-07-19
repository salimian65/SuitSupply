using SuitSupply.Framework.Core.CommandHandling;
using SuitSupply.Framework.Domain;
using SuitSupply.Tailoring.Application.Contracts;
using SuitSupply.Tailoring.Application.Contracts.AlteringTasks;
using SuitSupply.Tailoring.Domain.Tailors.Services;

namespace SuitSupply.Tailoring.Application;

public class AlteringCommandHandler : CommandHandler, ICommandHandler<CreateAlteringTaskCommand>
{
    private readonly ITailorRepository _tailorRepository;

    public AlteringCommandHandler(ITailorUnitOfWork unitOfWork, ITailorRepository tailorRepository) : base(unitOfWork)
    {
        this._tailorRepository = tailorRepository;
    }

    public void Handle(CreateAlteringTaskCommand taskCommand)
    {
        //   var tailor = _tailorRepository.Get(taskCommand.AccountId);
        //  tailor.Altering(taskCommand.BlockAmount, taskCommand.Comment);
        // tailorRepository.Update(account);
    }
}

public interface ITailorUnitOfWork : IUnitOfWork
{
}