using SuitSupply.Framework.Domain;

namespace SuitSupply.Tailoring.Domain.Suits;

public class Trouser : ValueObject<Sleeve>
{
    public Trouser(int waistSize, Leg rightLeg, Leg leftLeg)
    {
        WaistSize = waistSize;
        RightLeg = rightLeg;
        LeftLeg = leftLeg;
    }

    public int WaistSize { get; private set; }
    public Leg RightLeg { get; private set; }

    public Leg LeftLeg { get; set; }
    public override bool Equals(Sleeve other)
    {
        throw new NotImplementedException();
    }
}