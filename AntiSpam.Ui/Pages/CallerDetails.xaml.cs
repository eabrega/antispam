using AntiSpam.Core.Callers;

namespace AntiSpam.Ui.Pages;

public partial class CallerDetails : ContentPage
{
    private readonly Caller _caller;

    public CallerDetails(Caller caller)
    {
        InitializeComponent();
        BindingContext = _caller = caller;
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CallerEditor(_caller), true);
    }
}
