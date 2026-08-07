using Reflections.Models;
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

    public void LoadEntry(JournalEntry entry)
    {
        viewModel.LoadEntry(entry);
    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(viewModel.Title))
        {
            await DisplayAlert("Missing Title", "Please enter a title.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(viewModel.Content))
        {
            await DisplayAlert("Missing Content", "Please write something.", "OK");
            return;
        }

        await viewModel.SaveEntryAsync();

        await DisplayAlert("Saved", "Journal entry saved successfully!", "OK");

        viewModel.Id = 0;
        viewModel.Title = "";
        viewModel.Content = "";
        viewModel.SelectedMood = "Happy";
        viewModel.SelectedDate = DateTime.Today;

        await Shell.Current.GoToAsync("..");
    }

    private void Clear_Clicked(object sender, EventArgs e)
    {
        viewModel.Id = 0;
        viewModel.Title = "";
        viewModel.Content = "";
        viewModel.SelectedMood = "Happy";
        viewModel.SelectedDate = DateTime.Today;
    }
}