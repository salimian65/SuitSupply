//using System.Reflection;
//using System.Text.Json;

//namespace SuitSupply.Framework.Core.CommandHandling
//{
//    public static class CommandExtensions
//    {
//        public static string ToJson(this ICommand command)
//        {
//            var serializerSettings = new JsonSerializerSettings
//            {
//                ContractResolver = new IncludeInternalStateContractResolver()
//            };

//            var json = JsonConvert.SerializeObject(command, serializerSettings);
//            return json;
//        }

//        private class IncludeInternalStateContractResolver : DefaultContractResolver
//        {
//            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
//            {
//                return (from property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
//                        where !property.Name.ToLower().Contains("password")
//                        let jsonProperty = CreateProperty(property, memberSerialization)
//                        select jsonProperty)
//                        .ToList();
//            }
//        }

//    }
//}