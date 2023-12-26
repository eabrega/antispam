using AntiSpam.Core.Helpers;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Onecloud.Ssl.Tests")]
namespace AntiSpam.Core.PhoneNumbers;

internal static class Helpers
{
    internal static string ThrowIfPhoneInvalid(this string phoneNumber) =>
        phoneNumber.ThrowIfStringInvalid() != "" &&
        phoneNumber.IsPhoneNumberValid()
            ? phoneNumber
            : throw new ArgumentException($"Phone number '{phoneNumber}' is not valid.");

    internal static bool IsPhoneNumberValid(this string? @string)
    {
        if (@string is null)
        {
            return false;
        }

        var sanitizeString = @string.SanitizePhoneNumber();

        return
            sanitizeString.Length >= 3 &&
            sanitizeString.Length <= 20 &&
            sanitizeString[0] != '0' &&
            sanitizeString.All(char.IsNumber);
    }

    internal static string SanitizePhoneNumber(this string @string)
    {
        var clearString =
            @string == string.Empty
                ? @string
                : @string
                    .Where(char.IsNumber)
                    .Aggregate("", (phone, digit) => phone + digit);

        return clearString[0] == '8'
                    ? clearString.Remove(0, 1).Insert(0, "7")
                    : clearString;
    }
}
