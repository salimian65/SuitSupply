//using System.Globalization;
//using System.Text;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;

//namespace SuitSupply.Tailoring.E2ETests.Technical.Utilities
//{
//    public static class ByteArraySerializer
//    {
//        public static byte[] AlteringTaskCreatedToBinary(this AlteringTaskCreated obj)
//        {
//            var type = obj.GetType();
//            var jObject = JObject.FromObject(obj);

//            var totalOfT2JToken = jObject.SelectToken(nameof(obj.TotalOfT2));
//            totalOfT2JToken.Replace(new JObject(new JProperty("$", GetString(obj.TotalOfT2))));

//            var powerCreditT2JToken = jObject.SelectToken(nameof(obj.PowerCreditT2));
//            powerCreditT2JToken.Replace(new JObject(new JProperty("$", GetString(obj.PowerCreditT2))));

//            AddEventScourceJProperties(type, jObject);
//            var serializedJson = jObject.ToString(Formatting.None);

//            var stream = Encoding.UTF8.GetBytes(serializedJson);
//            return stream;
//        }

//        public static byte[] ToBinary(this object obj)
//        {
//            string serializedJson = JsonConvert.SerializeObject(obj); 
//            var stream = Encoding.UTF8.GetBytes(serializedJson);
//            return stream;
//        }

//        public static byte[] ArrayToBinary(object obj)
//        {
//            string serializedJson = SerializeJArray(obj);
//            var stream = Encoding.UTF8.GetBytes(serializedJson);
//            return stream;
//        }

//        public static object FromBinary(byte[] bytes, Type type)
//        {
//            return bytes;
//        }

//        private static string SerializeObject(object obj)
//        {
//            var type = obj.GetType();
//            JObject serializedJson = JObject.FromObject(obj);
//            AddEventScourceJProperties(type, serializedJson);
//            var result = serializedJson.ToString(Formatting.None);
//            return result;
//        }

//        private static string SerializeJArray(object obj)
//        {
//            var type = obj.GetType();
//            var serializedJson = new JObject();
//            AddEventScourceJProperties(type, serializedJson);

//            JArray jArray = JArray.FromObject(obj);
//            AddEventScourceJProperties(serializedJson, jArray);
//            var result = serializedJson.ToString();
//            return result;
//        }

//        private static void AddEventScourceJProperties(JObject serializedJson, JArray jArray)
//        {
//            jArray.AddFirst(serializedJson);
//        }

//        private static void AddEventScourceJProperties(Type type, JObject serializedJson)
//        {
//            var typeNameOfAlteringTaskCreated = "OMS.Domain.Contracts.Trader.Events.AlteringTaskCreated, OMS.Domain.Contracts";
//            serializedJson.AddFirst(new JProperty("$type", typeNameOfAlteringTaskCreated));
//            serializedJson.AddFirst(new JProperty("$id", "1"));
//        }

//        private static string GetString(object value)
//        {
//            if (value is int)
//                return "I" + ((int)value).ToString(NumberFormatInfo.InvariantInfo);
//            if (value is float)
//                return "F" + ((float)value).ToString(NumberFormatInfo.InvariantInfo);
//            if (value is decimal)
//                return "M" + ((decimal)value).ToString(NumberFormatInfo.InvariantInfo);
//            throw new NotSupportedException();
//        }

//    }
//}
