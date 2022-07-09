namespace SuitSupply.Framework.Domain
{
    public interface IUnitOfWork
    {
        void Commit();

        void RejectChanges();
    }
}