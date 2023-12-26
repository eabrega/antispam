using AntiSpam.Core.PhoneNumbers;

namespace AntiSpam.Core.Callers;

public interface ICallersRepository
{
    void Add(Caller caller);

    Caller? GetCaller(PhoneNumber phoneNumber);

    IReadOnlyCollection<Caller> GetAll(CallListType type);

    int GetCallerCount();

    void Delete(Caller caller);
}
