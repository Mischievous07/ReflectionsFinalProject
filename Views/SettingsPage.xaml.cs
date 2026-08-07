using Reflections.ViewModels;

namespace Reflections.Views;

public partial class SettingsPage : ContentPage
{
    private readonly SettingsViewModel viewModel;

    public SettingsPage(SettingsViewModel viewModel)
    {
        InitializeComponent();

        this.viewModel = viewModel;
        BindingContext = viewModel;
    }

    private void DarkMode_Toggled(object sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            BackgroundColor = Colors.Black;
        }
        else
        {
            BackgroundColor = Colors.White;
        }
    }
}