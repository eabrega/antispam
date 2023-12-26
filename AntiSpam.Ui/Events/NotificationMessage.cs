namespace AntiSpam.Ui.Events;

using CommunityToolkit.Mvvm.Messaging.Messages;

public class NotificationMessage : ValueChangedMessage<string>
{
    public NotificationMessage(string value) : base(value)
    {
    }
}
