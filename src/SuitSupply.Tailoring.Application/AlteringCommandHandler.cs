using SuitSupply.Framework.Core.CommandHandling;
using SuitSupply.Framework.Domain;
using SuitSupply.Tailoring.Application.Contracts;
using SuitSupply.Tailoring.Domain.Tailors.Services;

namespace SuitSupply.Tailoring.Application;

public class AlteringCommandHandler : CommandHandler, ICommandHandler<AlteringCommand>
{
    private readonly ITailorRepository _tailorRepository;

    public AlteringCommandHandler(ITailorUnitOfWork unitOfWork, ITailorRepository tailorRepository) : base(unitOfWork)
    {
        this._tailorRepository = tailorRepository;
    }

    public void Handle(AlteringCommand command)
    {
        var tailor = _tailorRepository.Get(command.AccountId);
        tailor.Altering(command.BlockAmount, command.Comment);
       // tailorRepository.Update(account);
    }
}

public interface ITailorUnitOfWork:IUnitOfWork
{
}