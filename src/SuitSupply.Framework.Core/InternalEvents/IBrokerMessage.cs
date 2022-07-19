namespace SuitSupply.Framework.Core.InternalEvents;

public interface IBrokerMessage : IEnternalEvent
{
    string Token { get; set; }
}