using SuitSupply.Framework.Domain;

namespace SuitSupply.Tailoring.Domain.Suits;

public class Leg : ValueObject<Leg>
{
    public Leg(int lenghtSize)
    {
        LenghtSize = lenghtSize;
    }

    public int LenghtSize { get; private set; }
    public override bool Equals(Leg other)
    {
        throw new NotImplementedException();
    }
}