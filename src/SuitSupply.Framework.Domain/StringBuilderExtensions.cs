using System.Text;

namespace SuitSupply.Framework.Domain
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder Append<T>(this StringBuilder strBuilder, string title, T value)
        {
            if (title == null || value == null) return strBuilder;

            strBuilder.Append($" {title}: ");
            strBuilder.Append(value);
            return strBuilder;
        }
    }
}