using AntiSpam.Core.Callers;
using AntiSpam.Ui.ViewModels;

namespace AntiSpam.Ui.Pages;

public partial class CallerEditor : ContentPage
{
    public static IReadOnlyCollection<string> Elements => Enum.GetNames<CallListType>();

    public CallerEditor(Caller? caller)
    {
        InitializeComponent();
        BindingContext = new CallerEditorViewModel(caller);
    }
}