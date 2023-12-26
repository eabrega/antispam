using AntiSpam.Ui.Events;
using CommunityToolkit.Mvvm.Messaging;

namespace AntiSpam.Ui;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activityState)
    {
        return new Window(new AppShell());
    }

    protected override void OnResume()
    {
        base.OnResume();
        WeakReferenceMessenger.Default.Send(new ResumeAppMessage(true));
    }
}
