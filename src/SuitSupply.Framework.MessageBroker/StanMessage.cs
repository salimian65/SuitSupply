namespace SuitSupply.Framework.MessageBroker
{
    public class StanMessage
    {
        public string Subject { get; set; }

        public byte[] Body { get; set; }

        public STAN.Client.StanMsg StanMsg { get; set; }
    }

    //namespace Soshyant.Framework.MessageBroker
    //{
    //    public interface IStanMessage
    //    {
    //        string Subject { get; }

    //        byte[] Body { get; }

    //        STAN.Client.StanMsg StanMsg { get; set; }
    //    }
    //}

    public class StanQueueGroupName
    {
        public string Name { get; set; }
    }
}