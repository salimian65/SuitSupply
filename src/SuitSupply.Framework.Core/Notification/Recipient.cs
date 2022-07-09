namespace SuitSupply.Framework.Core.Notification
{
    public class Recipient
    {
        public string FullName { get; set; }

        public string CellPhone { get; set; }

        public string Email { get; set; }

        public Guid BranchId { get; set; }

        public string BranchName { get; set; }
    }
}