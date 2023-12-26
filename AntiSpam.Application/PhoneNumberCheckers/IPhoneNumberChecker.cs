using AntiSpam.Core.PhoneNumbers;

namespace AntiSpam.Applications.PhoneNumberCheckers;

public interface IPhoneNumberChecker
{
    bool IsSpamNumber(PhoneNumber number);

    void SetPhone(string phoneNumber);
}
