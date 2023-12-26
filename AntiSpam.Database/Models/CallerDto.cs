using SQLite;

namespace AntiSpam.Database.Models;

public class CallerDto
{
    [PrimaryKey]
    public long PhoneNumber { get; set; }

    public string Type { get; set; }

    public string? Note { get; set; }
}
