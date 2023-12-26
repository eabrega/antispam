using AntiSpam.Ui.ViewModels.SettingsViewModels.Helpers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AntiSpam.Ui.ViewModels.SettingsViewModels;

public partial class SettingsViewModel : ObservableObject
{
    private bool EBLO = false;
    private bool PIZDA = false;


    [ObservableProperty]
    public SettingItem contactPermission;

    [ObservableProperty]
    public SettingItem phonePermission;

    [ObservableProperty]
    public SettingItem callLogPermission;

    public bool IsDefaultDialler
    {
        get => EBLO;
        set
        {
            EBLO = _permissionController.CheckDefaultDiallerStatus();
            if (PIZDA == false)
            {
                _deviceController.SetDefaultDialler();
                PIZDA = true;
            }
            OnPropertyChanged(nameof(IsDefaultDialler));
        }
    }

    [RelayCommand]
    async Task Toggled(SettingItem? item)
    {
        if (item is null)
        {
            return;
        }

        var permission = await _permissionController.GetPermissionByCategory(item.Category);
        item.Value = permission;
    }

    [RelayCommand]
    void ConfigureNotification()
    {
        _deviceController.ConfigureNotification();
    }

    [RelayCommand]
    void SetDefaultDialler()
    {
        var result = _permissionController.CheckDefaultDiallerStatus();
        if (result == false)
        {

        }

        //        IsDefaultDialler = result;
    }

    [RelayCommand]
    void SendTestNotification()
    {
        _deviceController.SendNotification("PLAMS");
    }
}
