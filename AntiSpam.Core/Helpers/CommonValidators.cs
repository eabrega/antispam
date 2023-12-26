namespace AntiSpam.Core.Helpers;

public static class CommonValidators
{
    public static string ThrowIfStringInvalid(this string? @string) =>
        @string.IsStringValid()
            ? @string!
            : throw new ArgumentException($"{@string} is not valid.");

    public static bool IsStringValid(this string? @string) =>
        @string is not null &&
        @string.Length >= 2 &&
        @string.Length <= 120;
}
