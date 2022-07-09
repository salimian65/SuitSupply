namespace SuitSupply.Framework.Domain.ExceptionHandling
{
    public class DomainException : ExceptionBase
    {
        protected DomainException()
        {
        }

        protected DomainException(string message) : base(message)
        {
        }

        protected DomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}