
using SuitSupply.Framework.Core.CommandHandling;

namespace SuitSupply.Tailoring.Application.Contracts.AlteringTasks;

public class CreateAlteringTaskCommand : ICommand
{
    public Guid SuitId { get; set; }

    public Guid OrderId { get; set; }

    public int ChangeRightSleeves { get; set; }

    public int ChangeLeftSleeves { get; set; }

    public int ChangeTrouserRightLeg { get; set; }

    public int ChangeTrouserLeftLeg { get; set; }

    public DateTime TimeStamp { get; }
}