using System.Windows.Input;

namespace AntiSpam.Ui.Components.TableViews;

public partial class TableSwitch : ContentView
{
    public TableSwitch()
    {
        InitializeComponent();
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public object? PayLoad
    {
        get => (object?)GetValue(PayLoadProperty);
        set 
        {
            SetValue(PayLoadProperty, value);
            OnPropertyChanged(nameof(IsToggled));
        }
    }

    public bool IsToggled
    {
        get => (bool)GetValue(IsToggledProperty);
        set
        {
            SetValue(IsToggledProperty, value);
            OnPropertyChanged(nameof(PayLoad));
        }
    }

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public static readonly BindableProperty IsToggledProperty =
        BindableProperty.Create(
            nameof(IsToggled),
            typeof(bool),
            typeof(TableSwitch),
            false);

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(TableSwitch),
            "");

    public static readonly BindableProperty PayLoadProperty =
        BindableProperty.Create(
            nameof(Text),
            typeof(object),
            typeof(TableSwitch),
            null);

    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(TableSwitch), null);
}
