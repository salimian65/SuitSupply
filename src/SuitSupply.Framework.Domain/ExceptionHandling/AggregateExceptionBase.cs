namespace SuitSupply.Framework.Domain.ExceptionHandling
{
    public class AggregateExceptionBase : AggregateException, IExceptionBase
    {
        protected AggregateExceptionBase()
        {
        }

        protected AggregateExceptionBase(string message) : base(message)
        {
        }

        protected AggregateExceptionBase(IEnumerable<Exception> innerExceptions) : base(innerExceptions)
        {
        }

        public virtual int ErrorCode => 0;

        public virtual Severity Severity => Severity.Error;
    }
}