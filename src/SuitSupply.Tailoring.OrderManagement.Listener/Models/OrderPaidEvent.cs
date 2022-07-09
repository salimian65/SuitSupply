using SuitSupply.Framework.Core.Events;

namespace SuitSupply.Tailoring.OrderManagement.Listener.Models;

public class OrderPaidEvent : IEvent
{
    public Guid SuitId { get; set; }

    public Guid OrderId { get; set; }

    public int ChangeRightSleeves { get; set; }

    public int ChangeLeftSleeves { get; set; }

    public int ChangeTrouserRightLeg { get; set; }

    public int ChangeTrouserLeftLeg { get; set; }
    public DateTime TimeStamp { get; }
}