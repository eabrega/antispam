using AntiSpam.Core.Callers;
using AntiSpam.Core.PhoneNumbers;

namespace AntiSpam.Ui;

public record PermissionsStatus(bool Contact, bool Phone, bool CallLog, bool IsDefaulDialler);

public enum CallType
{
    Incoming = 1,
    Outgoing = 2,
    Missed = 3,
    Voicemail = 4,
    Rejected = 5,
    Blocked = 6,
    AnsweredExternally = 7
}

public record CallLogItem(
    string? Name, 
    PhoneNumber Number, 
    TimeSpan Duration, 
    DateTime Date, 
    CallType Type,
    Caller? Caller);

public interface IDeviceController
{
    IReadOnlyCollection<CallLogItem> GetCallLog();

    void SetDefaultDialler();

    void ConfigureNotification();

    void SendNotification(string message);
}

public interface IPermissionController
{
    Task<PermissionsStatus> CheckDevidePermissions();

    Task<bool> RequestContactPermission();

    Task<bool> RequestPhonePermission();

    Task<bool> RequestCallLogPermission();

    public bool CheckDefaultDiallerStatus();
}
