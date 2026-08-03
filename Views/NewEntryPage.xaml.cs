using Reflections.ViewModels;

namespace Reflections.Views;

public partial class NewEntryPage : ContentPage
{
    private readonly NewEntryViewModel viewModel;

    public NewEntryPage(NewEntryViewModel vm)
    {
        InitializeComponent();
        viewModel = vm;
        BindingContext = viewModel;
    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert(
            "Journal Entry",
            "Saving will be added later.",
            "OK");
    }

    private void Clear_Clicked(object sender, EventArgs e)
    {
        viewModel.Title = "";
        viewModel.Content = "";
        viewModel.SelectedDate = DateTime.Today;
        viewModel.SelectedMood = "Happy";
    }
}