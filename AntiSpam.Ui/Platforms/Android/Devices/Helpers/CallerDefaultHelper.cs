using Android.App.Roles;
using Android.Content;
using Android.Telecom;

namespace AntiSpam.Ui.Platforms.Android.Devices.Helpers;

internal class CallerDefaultHelper
{
    private const int REQUEST_CODE = 9872;
    public static void MakeAppDefaultCaller()
    {
        var intent = MakeIntent();
        Platform.CurrentActivity?.StartActivityForResult(intent, REQUEST_CODE);
    }

    internal static Intent? MakeIntent()
    {
        if (OperatingSystem.IsAndroidVersionAtLeast(29))
        {
            var roleManager = Platform.AppContext.GetSystemService(Context.RoleService) as RoleManager;
            return roleManager?.CreateRequestRoleIntent(RoleManager.RoleCallScreening);
        }
        else
        {
            return new Intent(TelecomManager.ActionChangeDefaultDialer)
                .PutExtra(
                    TelecomManager.ExtraChangeDefaultDialerPackageName,
                    Platform.CurrentActivity?.PackageName);
        }
    }
}
