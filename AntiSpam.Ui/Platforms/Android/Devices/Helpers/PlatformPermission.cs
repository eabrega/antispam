using static Microsoft.Maui.ApplicationModel.Permissions;

namespace AntiSpam.Ui.Platforms.Android.Devices.DeviceHelpers;

internal class ContactPermission : BasePlatformPermission
{
    public override (string androidPermission, bool isRuntime)[] RequiredPermissions =>
        new List<(string androidPermission, bool isRuntime)>()
        {
            ("android.permission.READ_CONTACTS", true),
        }
        .ToArray();
}

internal class PhoneStatePermission : BasePlatformPermission
{
    public override (string androidPermission, bool isRuntime)[] RequiredPermissions =>
        new List<(string androidPermission, bool isRuntime)>()
        {
            ("android.permission.READ_PHONE_STATE", true)
        }
        .ToArray();
}

internal class CallLogPermission : BasePlatformPermission
{
    public override (string androidPermission, bool isRuntime)[] RequiredPermissions =>
        new List<(string androidPermission, bool isRuntime)>()
        {
            ("android.permission.READ_CALL_LOG", true)
        }
        .ToArray();
}

