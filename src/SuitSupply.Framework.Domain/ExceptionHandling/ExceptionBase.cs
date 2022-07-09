namespace SuitSupply.Framework.Domain.ExceptionHandling
{
    public abstract class ExceptionBase : ApplicationException, IExceptionBase
    {
        protected ExceptionBase()
        {
        }

        protected ExceptionBase(string message) : base(message)
        {
        }

        protected ExceptionBase(string message, Exception innerException) : base(message, innerException)
        {
        }

     //   public virtual IExceptionHandler Handler => 
        public virtual int ErrorCode => 0;

        public virtual Severity Severity => Severity.Error;
    }
}