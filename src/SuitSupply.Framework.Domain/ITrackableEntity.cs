namespace SuitSupply.Framework.Domain
{
    public interface ITrackableEntity
    {
        DateTime CreationDate { get; set; }

        DateTime? LastChangedDate { get; set; }

        string LastChangedBy { get; set; }
    }
}