using SuitSupply.Framework.Domain;

namespace SuitSupply.Tailoring.Domain.Suits;

public class Sleeve : ValueObject<Sleeve>
{
    public Sleeve(int lenghtSize)
    {
        LenghtSize = lenghtSize;
    }

    public int LenghtSize { get; private set; }
    public override bool Equals(Sleeve other)
    {
        throw new NotImplementedException();
    }
}