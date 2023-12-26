using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using AntiSpam.Ui.Events;
using CommunityToolkit.Mvvm.Messaging;

namespace AntiSpam.Ui.Platforms.Android;

[Activity(
    Theme = "@style/Maui.SplashTheme",
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize,
    MainLauncher = true,
    LaunchMode = LaunchMode.SingleTop)]
[IntentFilter(
    new[] { Intent.ActionView, Intent.ActionDial },
    Categories = new[]
    {
        Intent.CategoryDefault,
        Intent.CategoryBrowsable
    },
    DataScheme = "tel")]
[IntentFilter(
    new[] { Intent.ActionDial },
    Categories = new[]
    {
        Intent.CategoryDefault,
    })]
public class MainActivity : MauiAppCompatActivity
{
    string? _onCreateNotificationMessage;

    protected override void OnNewIntent(Intent? intent)
    {
        base.OnNewIntent(intent);
        var payLoad = intent?.GetStringExtra("t") ?? "err";

        WeakReferenceMessenger.Default.Send(new NotificationMessage(payLoad));
        Toast.MakeText(this, $"intent::{payLoad}", ToastLength.Long)?.Show();
    }

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        var payLoad = Intent?.GetStringExtra("t");
        _onCreateNotificationMessage = payLoad;
    }

    protected override void OnResume()
    {
        base.OnResume();
        if (_onCreateNotificationMessage is not null)
        {
            WeakReferenceMessenger.Default.Send(new NotificationMessage(_onCreateNotificationMessage));
            _onCreateNotificationMessage = null;
        }
    }
}
