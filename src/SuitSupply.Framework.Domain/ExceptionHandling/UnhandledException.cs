namespace SuitSupply.Framework.Domain.ExceptionHandling
{
    public class UnhandledException : ExceptionBase
    {
        public UnhandledException(Exception innerException) : base("ExceptionMessages.UnhandledException", innerException)
        {
        }
    }
}