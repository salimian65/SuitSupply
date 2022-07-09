namespace SuitSupply.Framework.Domain
{
    public interface IAggregateRoot        
    {
        Guid Id { get; }

        byte[] RowVersion { get; set; }
    }
}
 