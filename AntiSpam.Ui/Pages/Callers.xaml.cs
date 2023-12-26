using AntiSpam.Core.Callers;
using AntiSpam.Ui.ViewModels;

namespace AntiSpam.Ui.Pages;

public partial class Callers : ContentPage
{
    private readonly CallersViewModel _viewModel;
    private readonly ICallersRepository _callersRepository;

    public Callers(
        ICallersRepository callersRepository,
        CallersViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        _callersRepository = callersRepository;
        BindingContext = _viewModel;
    }

    private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var caller = e.SelectedItem as Caller;
        ArgumentNullException.ThrowIfNull(caller);

        await Navigation.PushAsync(new CallerDetails(caller), true);
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        var d = Shell.Current.CurrentState.Location
            .OriginalString.Split("/").LastOrDefault();
        
        if (d  == "All")
        {
            _viewModel.Callers = _callersRepository.GetAll(CallListType.WhiteList | CallListType.BlackList);
            return;
        }

        if (d == "Black")
        {
            _viewModel.Callers = _callersRepository.GetAll(CallListType.BlackList);
            return;
        }

        if (d == "White")
        {
            _viewModel.Callers = _callersRepository.GetAll(CallListType.WhiteList);
            return;
        }

        //_viewModel.Callers = _callersRepository.GetAll(1);

    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CallerEditor(null), true);
    }
}
