namespace SuitSupply.Framework.Domain.ExceptionHandling
{
    public interface IExceptionBase 
    {
      //  IExceptionHandler Handler { get; }

        int ErrorCode { get; }

        Severity Severity { get; }

        string Message { get; }
    }

    public enum Severity
    {
        Error
    }
}