using SuitSupply.Framework.Core.CommandHandling;
using SuitSupply.Framework.Core.Events;
using SuitSupply.Tailoring.Application.Contracts;
using SuitSupply.Tailoring.OrderManagement.Listener.Models;

namespace SuitSupply.Tailoring.OrderManagement.Listener;

public class OrderPaidEventHandler : CommandService, IEventHandler<OrderPaidEvent>
{
    public void Handle(OrderPaidEvent eventToHandle)
    {
        var command = new AlteringCommand
        {

        };

        CommandBus.Dispatch(command);
    }

}