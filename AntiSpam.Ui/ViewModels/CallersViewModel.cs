using AntiSpam.Core.Callers;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AntiSpam.Ui.ViewModels;

public partial class CallersViewModel : ObservableObject
{
    [ObservableProperty]
    public IReadOnlyCollection<Caller>? callers;
}