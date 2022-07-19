using SuitSupply.Framework.Core.ExternalEvents;
using SuitSupply.Framework.MessageBroker;

namespace SuitSupply.Tailoring.Interface.InboxListener.Models;

public class OrderPaidEvent : BaseExternalEvent<OrderPaidEvent>
{
    public Guid SuitId { get; set; }

    public Guid OrderId { get; set; }

    public int ChangeRightSleeves { get; set; }

    public int ChangeLeftSleeves { get; set; }

    public int ChangeTrouserRightLeg { get; set; }

    public int ChangeTrouserLeftLeg { get; set; }
    public DateTime TimeStamp { get; }
}