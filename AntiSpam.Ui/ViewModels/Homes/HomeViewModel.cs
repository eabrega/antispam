using AntiSpam.Core.Callers;
using AntiSpam.Core.PhoneNumbers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AntiSpam.Ui.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private readonly IDeviceController _deviceController;
    private readonly IPermissionController _permissionController;

    public HomeViewModel(
        IDeviceController deviceController,
        IPermissionController permissionController)
    {
        _deviceController = deviceController;
        _permissionController = permissionController;
    }

    [ObservableProperty]
    string message = "";

    [ObservableProperty]
    IReadOnlyCollection<CallItem>? calls;

    [RelayCommand]
    async Task Init()
    {
        var d = await _permissionController.CheckDevidePermissions();
        if (d.CallLog == true)
        {
            var callLogItems = _deviceController.GetCallLog();
            var wd = callLogItems
                .Select(x => new
                {
                    callItem = x,
                    caller = x.Caller,
                    type = x.Type,
                    date = DateOnly.FromDateTime(x.Date),
                    o = x
                })
                .GroupBy(x => new { x.callItem.Number, x.type, x.date })
                .Select(c => new
                {
                    c.Key,
                    callLogItems.First(x=>x.Number == c.Key.Number).Caller,
                    c.Key.type,
                    items = c.Select(x => (x.o.Date, x.o.Duration)).ToArray()
                });

            Calls = wd
                .Select(y => new CallItem(callLogItems.First(x => x.Number == y.Key.Number), y.Caller, y.type, y.items))
                .OrderByDescending(x=>x.Items.Max().Date)
                .ToArray();
        }
    }
}
public record CallItem(CallLogItem Call, Caller? Caller, CallType CallType, IReadOnlyCollection<(DateTime Date, TimeSpan Duration)> Items);
