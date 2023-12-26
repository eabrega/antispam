using AntiSpam.Ui.ViewModels;

namespace AntiSpam.Ui.Pages;

public partial class Home : ContentPage
{
    public Home(HomeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
