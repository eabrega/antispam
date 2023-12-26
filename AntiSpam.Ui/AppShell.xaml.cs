using AntiSpam.Ui.Events;
using AntiSpam.Ui.Helpers;
using AntiSpam.Ui.ViewModels;
using CommunityToolkit.Mvvm.Messaging;

namespace AntiSpam.Ui;

public partial class AppShell : Shell, IRecipient<NotificationMessage>
{
    public AppShell()
    {
        InitializeComponent();
        WeakReferenceMessenger.Default.Register(this);
    }

    public void Receive(NotificationMessage message)
    {
        var vm = PlatformServiceHelper.GetService<HomeViewModel>();
        if (vm is null)
        {
            return;
        }

        vm.Message = message.Value;
        CurrentItem = CurrentItem?.Items[0];
    }
}
