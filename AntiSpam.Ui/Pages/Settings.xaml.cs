using AntiSpam.Ui.ViewModels.SettingsViewModels;

namespace AntiSpam.Ui.Pages;

public partial class Settings : ContentPage
{
    private readonly SettingsViewModel _viewModel;

    public Settings(SettingsViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}
