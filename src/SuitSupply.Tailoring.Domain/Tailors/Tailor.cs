using SuitSupply.Framework.Domain;

namespace SuitSupply.Tailoring.Domain.Tailors
{
    public class Tailor : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public void Altering()
        {

        }
    }
}
