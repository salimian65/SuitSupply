
using SuitSupply.Framework.Domain;

namespace SuitSupply.Tailoring.Domain.Suits
{
    public class Suit : Entity, IAggregateRoot
    {
        public Suit(Sleeve rightSleeve, Sleeve leftSleeve, Trouser trouser)
        {
            RightSleeve = rightSleeve;
            LeftSleeve = leftSleeve;
            Trouser = trouser;
        }

        public Sleeve RightSleeve { get; private set; }

        public Sleeve LeftSleeve { get; private set; }

        public Trouser Trouser { get; private set; }
    }
}
