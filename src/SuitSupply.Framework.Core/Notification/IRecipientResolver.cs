namespace SuitSupply.Framework.Core.Notification
{
    public interface IRecipientResolver
    {
        Recipient GetRecipientByPartyId(Guid partyId);

        Recipient GetRecipientByCustomerId(Guid customerId);
    }
}