using AntiSpam.Core.Callers;
using AntiSpam.Ui.Helpers;
using AntiSpam.Ui.ViewModels.Callers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AntiSpam.Ui.ViewModels;

public partial class CallerEditorViewModel : ObservableObject
{
    private readonly ICallersRepository _callersRepository;
    private Caller? _caller;

    public CallerEditorViewModel(Caller? caller)
    {
        _callersRepository =
            PlatformServiceHelper.GetService<ICallersRepository>()
            ?? throw new ArgumentException("Service 'ICallersRepository' not found.");
        _caller = caller;
        CallerDto = caller.MapToDto();
        CallerDto.PropertyChanged += (s, e) =>
        {
            OnPropertyChanged(nameof(IsValid));
        };
    }
    [ObservableProperty]
    public bool isContainsPhoneNumber;

    public bool IsValid => CallerDto?.IsValid ?? false;

    [ObservableProperty]
    public CallerViewModelDto? callerDto;

    [RelayCommand]
    void Init()
    {
        OnPropertyChanged(nameof(IsValid));
        IsContainsPhoneNumber = _caller is not null;       
    }

    [RelayCommand(CanExecute = nameof(IsValid))]
    async Task SaveAsync()
    {
        if (CallerDto is null)
        {
            return;
        }
        var caller = CallerDto.MapToModel();
        _callersRepository.Add(caller);
        await Shell.Current.GoToAsync("//Callers/All", true);
    }

    [RelayCommand(CanExecute = nameof(IsContainsPhoneNumber))]
    async Task DeleteAsync()
    {
        if (_caller is null)
        {
            return;
        }
        _callersRepository.Delete(_caller);
        _caller = null;
        await Shell.Current.GoToAsync("//Callers/All", true);
    }
}