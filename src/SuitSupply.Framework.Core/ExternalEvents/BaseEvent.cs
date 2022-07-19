using System.Runtime.Serialization.Json;
using System.Text;

namespace SuitSupply.Framework.Core.ExternalEvents
{
    public abstract class BaseEvent<T>
    {
        public int Id { get; set; }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();
            strBuilder.Append(base.ToString());
          //  strBuilder.Append(nameof(Id), Id);

            return strBuilder.ToString();
        }

        public  byte[] SerializeObject(object obj)
        {
            if (obj == null)
                return null;
            try
            {
                using var stream = new MemoryStream();
                var serializer = new DataContractJsonSerializer(obj.GetType());
                serializer.WriteObject(stream, obj);

                return stream.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}