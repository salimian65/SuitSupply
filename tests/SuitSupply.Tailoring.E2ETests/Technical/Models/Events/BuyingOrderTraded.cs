namespace SuitSupply.Tailoring.E2ETests.Technical.Models.Events
{
    public class BuyingOrderTraded
    {
        public BuyingOrderTraded(string traderId, byte accountType, decimal value)
        {
            TraderId = traderId;
            AccountType = accountType;
            Value = value;
        }

        public string TraderId { get; private set; }
        public byte AccountType { get; private set; }
        public decimal Value { get; private set; }

    }
}
