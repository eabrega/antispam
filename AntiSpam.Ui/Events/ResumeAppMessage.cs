namespace AntiSpam.Ui.Events;

using CommunityToolkit.Mvvm.Messaging.Messages;

public class ResumeAppMessage : ValueChangedMessage<bool>
{
    public ResumeAppMessage(bool value) : base(value)
    {
    }
}
