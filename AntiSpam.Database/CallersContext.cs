using AntiSpam.Database.Models;
using SQLite;

namespace AntiSpam.Database;

public class CallersContext
{
    private readonly SQLiteConnection _database;

    public CallersContext()
    {
        if (_database is not null)
        {
            return;
        }

        _database = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
        _database.CreateTable<CallerDto>();
    }

    public void AddCaller(CallerDto caller) =>
        _database.InsertOrReplace(caller);

    public CallerDto? GetCaller(long number)
    {
        return _database
          .Table<CallerDto>()
          .Where(i => i.PhoneNumber == number)
          .FirstOrDefault();
    }

    public int GetCallerCount() =>
        _database.Table<CallerDto>().Count();

    public IReadOnlyCollection<CallerDto> GetAll(IReadOnlyCollection<string> type) =>
        _database
            .Table<CallerDto>()
            .Where(x=> type.Contains(x.Type))
            .ToArray();

    public void Delete(CallerDto callerDto)
    {
        _database.Delete(callerDto);
    }
}
