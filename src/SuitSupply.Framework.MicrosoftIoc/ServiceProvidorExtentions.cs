using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Soshyant.Framework.TypeExtension;

namespace Soshyant.Framework.MicrosoftIoc
{
    public static class ServiceProviderExtensions
    {

        public static void RegisterAllImplementationOfInterface(this IServiceCollection services, Type indexBase)
        {
            Assembly.GetAssembly(indexBase).GetAllDescendantsOf(indexBase).ToList()
                    .ForEach(indexType => { services.AddScoped(indexBase, indexType); });
        }

        public static void RegisterAllImplementationOfInterface<T>(this IServiceCollection services)
        {
            var indexBase = typeof(T);
            Assembly.GetAssembly(indexBase).GetAllDescendantsOf<T>().ToList()
                    .ForEach(indexType => { services.AddScoped(indexBase, indexType); });

        }

        public static void RegisterAllImplementationOfInterface1<T>(IServiceCollection services)
        {
            var indexBase = typeof(T);
            Assembly.GetAssembly(indexBase).GetAllDescendantsOf<T>().ToList()
                .ForEach(indexType => { services.AddScoped(indexBase, indexType); });

        }
    }
}