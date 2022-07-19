using SuitSupply.Framework.Core.CommandHandling;

namespace SuitSupply.Tailoring.Application.Contracts.AlteringTasks;

public class PickAlteringTaskCommand : ICommand
{
    public Guid TailorId { get; set; }
    public Guid AlteringTaskId { get; set; }
  
    public DateTime TimeStamp { get; }
}