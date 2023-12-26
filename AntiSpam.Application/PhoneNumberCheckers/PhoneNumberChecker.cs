using AntiSpam.Core.Callers;
using AntiSpam.Core.PhoneNumbers;

namespace AntiSpam.Applications.PhoneNumberCheckers;

public class PhoneNumberChecker : IPhoneNumberChecker
{
    private readonly ICallersRepository _callsRepository;

    public PhoneNumberChecker(ICallersRepository callsRepository) {
        _callsRepository = callsRepository;
        PhoneNumber = "DELL";      
    }

    public string PhoneNumber { get; private set; }

    public bool IsSpamNumber(PhoneNumber number)
    {
        var caller = _callsRepository.GetCaller(number);
        return 
            caller is not null && 
            caller.Type == CallListType.BlackList;
    }

    public void SetPhone(string phoneNumber) =>
        PhoneNumber = phoneNumber;
}