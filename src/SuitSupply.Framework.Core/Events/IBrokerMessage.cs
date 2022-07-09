namespace SuitSupply.Framework.Core.Events;

public interface IBrokerMessage : IEvent
{
    string Token { get; set; }
}