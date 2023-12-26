using AntiSpam.Core.Callers;
using AntiSpam.Ui.Platforms.Android.Devices;
using AntiSpam.Ui.Platforms.Android.Devices.DeviceHelpers;
using AntiSpam.Ui.Platforms.Android.Devices.Helpers;
using CommunityToolkit.Mvvm.Messaging;

namespace AntiSpam.Ui.Devices;

public class DeviceController : IDeviceController
{
    private readonly ICallersRepository _callersRepository;

    public DeviceController(ICallersRepository callersRepository)
    {
        _callersRepository = callersRepository;
        WeakReferenceMessenger.Default.RegisterAll(this);
    }

    public void ConfigureNotification()
    {
        NotificationHelpers.ConfigureNotification();
    }

    public void SetDefaultDialler()
    {
        CallerDefaultHelper.MakeAppDefaultCaller();
    }

    public void SendNotification(string message) =>
        NotificationHelpers.SendNotification(message);

    public IReadOnlyCollection<CallLogItem> GetCallLog()
    {
        return CallLogController.GetCalls(_callersRepository);
    }
}
