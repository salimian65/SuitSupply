using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace SuitSupply.Framework.MessageBroker
{
    public abstract class BaseCommand<T>
    {
        public Guid Id { get; set; }

        public DateTime DateOfEvent { get; set; }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();
            strBuilder.Append(base.ToString());

            return strBuilder.ToString();
        }

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