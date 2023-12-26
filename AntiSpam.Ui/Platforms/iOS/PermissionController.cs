namespace AntiSpam.Ui.Devices;

public class PermissionController : IPermissionController
{
    public Task<PermissionsStatus> CheckDevidePermissions()
    {
        throw new NotImplementedException();
    }

    public Task<bool> RequestCallLogPermission()
    {
        throw new NotImplementedException();
    }

    public Task<bool> RequestContactPermission()
    {
        throw new NotImplementedException();
    }

    public bool CheckDefaultDiallerStatus()
    {
        throw new NotImplementedException();
    }

    public Task<bool> RequestPhonePermission()
    {
        throw new NotImplementedException();
    }
}
