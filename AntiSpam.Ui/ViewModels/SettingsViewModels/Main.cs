using AntiSpam.Core.Callers;
using AntiSpam.Ui.Events;
using AntiSpam.Ui.ViewModels.SettingsViewModels.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace AntiSpam.Ui.ViewModels.SettingsViewModels;

public partial class SettingsViewModel : ObservableObject, IRecipient<ResumeAppMessage>
{
    private readonly IDeviceController _deviceController;
    private readonly ICallersRepository _callersRepository;
    private readonly IPermissionController _permissionController;

    public SettingsViewModel(
        IDeviceController deviceController,
        ICallersRepository callersRepository,
        IPermissionController permissionController)
    {
        _deviceController = deviceController;
        _callersRepository = callersRepository;
        _permissionController = permissionController;

        ContactPermission = new SettingItem() { Category = PermissionCategory.Contact, Value = false };
        PhonePermission = new SettingItem() { Category = PermissionCategory.Phone, Value = false };
        CallLogPermission = new SettingItem() { Category = PermissionCategory.CallLog, Value = false };
       // IsDefaultDialler = new SettingItem() { Category = PermissionCategory.Dialler, Value = false };

        WeakReferenceMessenger.Default.Register(this);
    }

    public static string Version => VersionTracking.Default.CurrentVersion;

    [ObservableProperty]
    public int rowCount;

    [RelayCommand]
    async Task Init()
    {
        RowCount = _callersRepository.GetCallerCount();
        await UpdatePermissionStatuses();
    }

    public async void Receive(ResumeAppMessage message)
    {
        await UpdatePermissionStatuses();
    }

    private async Task UpdatePermissionStatuses()
    {
        var permissionsStatuses = await _permissionController.CheckDevidePermissions();
        ContactPermission.Value = permissionsStatuses.Contact;
        CallLogPermission.Value = permissionsStatuses.CallLog;
        PhonePermission.Value = permissionsStatuses.Phone;
       // IsDefaultDialler.Value = permissionsStatuses.IsDefaulDialler;
    }
}
