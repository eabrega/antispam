using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AntiSpam.Core.PhoneNumbers;

public record PhoneNumber
{
    private readonly long _number;
    private readonly int _length;

    public PhoneNumber(long number)
    {
        number
            .ToString()
            .Insert(0, "+")
            .ThrowIfPhoneInvalid();

        _length = number.ToString().Length;
        _number = number;
    }

    public PhoneNumber(string @string)
    {
        var phoneNumber = @string
            .SanitizePhoneNumber()
            .ThrowIfPhoneInvalid();

        _length = phoneNumber.Length;
        _number = Convert.ToInt64(phoneNumber);
    }

    public override string ToString() => _length switch
    {
        >=3 and <=5 => _number.ToString(),
        >= 6 and <= 7 => _number.ToString("###-##-##"),
        >= 8 and <= 10 => _number.ToString("+(###) ###-##-##"),
        _ => _number.ToString("+# (###) ###-##-##"),
    };

    public long ToLong() => _number;

    public static implicit operator PhoneNumber(string phoneNumber) =>
        new(phoneNumber);

    public static implicit operator PhoneNumber(long phoneNumber) =>
        new(phoneNumber);

    public static bool IsValid(string? @string) =>
        @string.IsPhoneNumberValid();

    public static PhoneNumber Parse(long phoneNumber) =>
        new (phoneNumber);

    public static PhoneNumber Parse(string? phoneNumber) =>
        new(phoneNumber ?? "");
}
