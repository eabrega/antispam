using AntiSpam.Core.PhoneNumbers;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace AntiSpam.Ui.ViewModels.Callers;

public partial class CallerViewModelDto : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsValid))]
    public string? number;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsValid))]
    public string? type;

    [ObservableProperty]
    public string? note;

    public bool IsValid => PhoneNumber.IsValid(Number) & !string.IsNullOrEmpty(Type);
}
