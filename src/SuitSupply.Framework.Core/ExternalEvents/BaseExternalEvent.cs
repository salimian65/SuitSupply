using System.Runtime.Serialization.Json;

namespace SuitSupply.Framework.Core.ExternalEvents
{
    public abstract class BaseExternalEvent<T>
    {
        public Guid Id { get; set; }

        public DateTime DateOfEvent { get; set; }

        public static T DeserializeObject(byte[] buffer)
        {
            using var stream = new MemoryStream();
            var serializer = new DataContractJsonSerializer(typeof(T));
            stream.Write(buffer, 0, buffer.Length);
            stream.Position = 0;

            return (T)serializer.ReadObject(stream);
        }
    }
}