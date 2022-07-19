
using SuitSupply.Framework.Core.CommandHandling;

namespace SuitSupply.Tailoring.Application.Contracts.Tailors;

public class CreateTailorCommand : ICommand
{

    public DateTime TimeStamp { get; }
}