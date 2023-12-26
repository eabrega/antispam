namespace AntiSpam.Ui.Components.TableViews;

public partial class TableInfo : ContentView
{
	public TableInfo()
	{
		InitializeComponent();
	}

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string Detail
    {
        get => (string)GetValue(DetailProperty);
        set => SetValue(DetailProperty, value);
    }

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(TableInfo),
            "");

    public static readonly BindableProperty DetailProperty =
        BindableProperty.Create(
            nameof(Detail),
            typeof(string),
            typeof(TableInfo),
            "");
}