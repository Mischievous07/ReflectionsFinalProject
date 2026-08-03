using Reflections.ViewModels;

namespace Reflections.Views;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(SettingsViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}