
using SuitSupply.Framework.Core.CommandHandling;

namespace SuitSupply.Tailoring.Application.Contracts;

public class AlteringCommand : ICommand
{

    public DateTime TimeStamp { get; }
}