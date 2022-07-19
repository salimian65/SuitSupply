using System.Collections;

namespace SuitSupply.Framework.Core.DependencyInjection
{
    public interface IContainer
    {
        T Resolve<T>();

        T Resolve<T>(Func<T, bool> selector);

        T Resolve<T>(string objectName);

        T Resolve<T>(string objectName, IDictionary arguments);

        T TryResolve<T>();

        IEnumerable<T> ResolveAll<T>();
    }
}