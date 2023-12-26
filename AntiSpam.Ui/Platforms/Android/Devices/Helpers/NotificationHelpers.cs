using Android.App;
using Android.Content;
using Android.Provider;
using AndroidX.Core.App;

namespace AntiSpam.Ui.Platforms.Android.Devices.DeviceHelpers;

public static partial class NotificationHelpers
{
    private const string NOTIFICATION_CANNEL_ID = "1000";

    public static void ConfigureNotification()
    {
        var mChannel = new NotificationChannel(
            NOTIFICATION_CANNEL_ID,
            "notification",
            NotificationImportance.High)
        {
            Description = "AntiSpam"
        };
        var notificationManager = Platform.AppContext.GetSystemService(Context.NotificationService) as NotificationManager;
        notificationManager?.CreateNotificationChannel(mChannel);

        var intent = new Intent(Settings.ActionChannelNotificationSettings)
            .PutExtra(Settings.ExtraAppPackage, Platform.CurrentActivity?.PackageName)
            .PutExtra(Settings.ExtraChannelId, NOTIFICATION_CANNEL_ID);

        Platform.CurrentActivity?.StartActivity(intent);
    }

    public static void SendNotification(string messageString)
    {
        Random rnd = new();
        var id = rnd.Next(1, 999);

        var message = $"call {messageString}";
        var intent = new Intent(Platform.AppContext, typeof(MainActivity))
            .SetFlags(ActivityFlags.SingleTop | ActivityFlags.ClearTop)
            .PutExtra("t", message);

        PendingIntent? pendingIntent = PendingIntent.GetActivity(Platform.AppContext, id, intent, PendingIntentFlags.Immutable);
        NotificationCompat.Builder builder = new NotificationCompat.Builder(Platform.AppContext, NOTIFICATION_CANNEL_ID)
            .SetSmallIcon(Resource.Mipmap.appicon)
            .SetContentTitle(message)
            .SetPriority(NotificationCompat.PriorityHigh)
            .SetContentIntent(pendingIntent)
            .SetShowWhen(true)
            .SetBadgeIconType(NotificationCompat.BadgeIconLarge)
            .SetCategory(NotificationCompat.CategoryCall)
            .SetAutoCancel(true);

        NotificationManagerCompat
            .From(Platform.AppContext)
            .Notify(id, builder.Build());
    }
}
