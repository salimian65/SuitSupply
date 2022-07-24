using System;
using System.Linq;

namespace SuitSupply.Tailoring.E2ETests.Technical.Utilities;

public static class StringExtensions
{
    public static T ToAccountType<T>(this string value) where T : Enum
    {
        var accountType = (T)Enum.Parse(typeof(T), value);
        return accountType;
    }

    private static Random random = new Random();

    public static string GetRandomNumber()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 5)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}