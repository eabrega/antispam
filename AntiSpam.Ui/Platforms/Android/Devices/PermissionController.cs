using Android.Content;
using Android.Telecom;
using AntiSpam.Ui.Platforms.Android.Devices.DeviceHelpers;

namespace AntiSpam.Ui.Devices;

public class PermissionController : IPermissionController
{
    public async Task<bool> RequestContactPermission()
    {
        var status = await Permissions.RequestAsync<ContactPermission>();
        return status == PermissionStatus.Granted;
    }

    public async Task<bool> RequestPhonePermission()
    {
        var status = await Permissions.RequestAsync<PhoneStatePermission>();
        return status == PermissionStatus.Granted;
    }

    public async Task<bool> RequestCallLogPermission()
    {
        var status = await Permissions.RequestAsync<CallLogPermission>();
        return status == PermissionStatus.Granted;
    }

    public bool CheckDefaultDiallerStatus()
    {
        var telecomManager = Platform.AppContext.GetSystemService(Context.TelecomService) as TelecomManager;
        return telecomManager?.DefaultDialerPackage == Platform.CurrentActivity?.PackageName;
    }

    public async Task<PermissionsStatus> CheckDevidePermissions()
    {
        var contact = await Permissions.CheckStatusAsync<ContactPermission>() == PermissionStatus.Granted;
        var phone = await Permissions.CheckStatusAsync<PhoneStatePermission>() == PermissionStatus.Granted;
        var callLog = await Permissions.CheckStatusAsync<CallLogPermission>() == PermissionStatus.Granted;
        var isDefaultDialler = CheckDefaultDiallerStatus();

        return new PermissionsStatus(contact, phone, callLog, isDefaultDialler);
    }
}
