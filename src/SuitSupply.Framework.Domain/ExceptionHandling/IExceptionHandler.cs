namespace SuitSupply.Framework.Domain.ExceptionHandling
{
    public interface IExceptionHandler
    {
        void Handle(IExceptionBase exceptionBase);
    }
}