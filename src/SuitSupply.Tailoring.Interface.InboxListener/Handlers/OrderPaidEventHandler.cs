using SuitSupply.Framework.Core.CommandHandling;
using SuitSupply.Framework.Core.ExternalEvents;
using SuitSupply.Framework.MessageBroker;
using SuitSupply.Tailoring.Application.Contracts.AlteringTasks;
using SuitSupply.Tailoring.Interface.InboxListener.Models;

namespace SuitSupply.Tailoring.Interface.InboxListener.Handlers
{
    public class OrderPaidEventHandler : CommandService, IExternalEventHandler<OrderPaidEvent>
    {

        public async Task Handle(OrderPaidEvent exEvent)
        {

            var command = new CreateAlteringTaskCommand
            {
               ChangeLeftSleeves = exEvent.ChangeLeftSleeves,
               ChangeRightSleeves = exEvent.ChangeRightSleeves,
               ChangeTrouserLeftLeg = exEvent.ChangeTrouserLeftLeg,
               ChangeTrouserRightLeg = exEvent.ChangeTrouserRightLeg,
               OrderId = exEvent.OrderId,
               SuitId = exEvent.SuitId
            };

            await CommandBus.DispatchAsync(command);
        }

    }
}