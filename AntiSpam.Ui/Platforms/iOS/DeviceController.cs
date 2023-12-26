namespace AntiSpam.Ui.Devices;

public class DeviceController : IDeviceController
{
    public DeviceController()
    {
    }

    public void ConfigureNotification()
    {
        throw new NotImplementedException();
    }

    public void SendNotification(string message)
    {
        throw new NotImplementedException();
    }

    public void SetDefaultDialler()
    {
        throw new NotImplementedException();
    }

    IReadOnlyCollection<CallLogItem> IDeviceController.GetCallLog()
    {
        throw new NotImplementedException();
    }
}
