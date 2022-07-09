using System.Runtime.Serialization;

namespace SuitSupply.Framework.Core.CommandHandling
{
    [DataContract(IsReference = true)]
    [Serializable]
    public abstract class Command : ICommand
    {
        protected Command()
        {
            TimeStamp = DateTime.Now;            
        }

        public DateTime TimeStamp { get; set; }
    }
}