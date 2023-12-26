using AntiSpam.Core.Callers;
using AntiSpam.Core.PhoneNumbers;
using AntiSpam.Database;
using AntiSpam.Infrastructure.Repositories.Mappers;
using System.Data;

namespace AntiSpam.Infrastructure.Repositories;

public class CallersRepository : ICallersRepository
{
    private readonly CallersContext _callersContext;
    public CallersRepository(CallersContext callersContext)
    {
        _callersContext = callersContext;
    }

    public Caller? GetCaller(PhoneNumber phoneNumber)
    {
        var callerDto = _callersContext.GetCaller(phoneNumber.ToLong());

        if (callerDto == null)
        {
            return null;
        }

        return callerDto.MapToModel();
    }

    public IReadOnlyCollection<Caller> GetAll(CallListType type)
    {
        var types = Enum
            .GetValues(typeof(CallListType))
            .Cast<CallListType>()
            .Where(r => (type & r) == r)
            .Select(r => r.ToString())
            .ToArray();

        return _callersContext
             .GetAll(types)
             .Select(x => x.MapToModel())
             .ToArray();
    }
    public int GetCallerCount() =>
        _callersContext.GetCallerCount();

    public void Add(Caller caller)
    {
        _callersContext.AddCaller(caller.MapToDto());
    }

    public void Delete(Caller caller)
    {
        var dto = caller.MapToDto();
        _callersContext.Delete(dto);
    }
}