using AntiSpam.Ui.ViewModels.SettingsViewModels.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AntiSpam.Ui.ViewModels.SettingsViewModels;

public partial class SettingItem : ObservableObject
{
    public PermissionCategory Category { get; set; }

    [ObservableProperty]
    public bool value;
}
