using System.Text.RegularExpressions;

namespace backend_famLogitech_aw.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;

public static partial class StringExtensions
{
    [GeneratedRegex("(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", RegexOptions.Compiled)]
    private static partial Regex KebabCaseRegex();
    public static string ToKebabCase(this string text)
    {
        return string.IsNullOrEmpty(text) 
            ? text 
            : KebabCaseRegex().Replace(text, "-$1").Trim().ToLower();
    }
}