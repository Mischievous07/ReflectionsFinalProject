using Reflections.Models;
using Reflections.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Reflections.Views;

public partial class EntryDetailPage : ContentPage
{
    private readonly EntryDetailViewModel viewModel;

    public EntryDetailPage(EntryDetailViewModel vm)
    {
        InitializeComponent();

        viewModel = vm;
        BindingContext = viewModel;
    }

    public void SetEntry(JournalEntry entry)
    {
        viewModel.LoadEntry(entry);
    }

    private async void Edit_Clicked(object sender, EventArgs e)
    {
        var page = Handler.MauiContext!
            .Services
            .GetService<NewEntryPage>();

        page!.LoadEntry(viewModel.Entry!);

        await Navigation.PushAsync(page);
    }

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        bool result = await DisplayAlert(
            "Delete Entry",
            "Are you sure you want to delete this journal entry?",
            "Yes",
            "No");

        if (!result)
            return;

        await viewModel.DeleteEntryAsync();

        await DisplayAlert(
            "Deleted",
            "Journal entry deleted.",
            "OK");

        await Navigation.PopAsync();
    }
}