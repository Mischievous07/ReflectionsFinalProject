using Reflections.Models;
using Reflections.ViewModels;

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


    private async void Edit_Clicked(
        object sender,
        EventArgs e)
    {
        await DisplayAlert(
            "Edit",
            "Editing will be added later.",
            "OK");
    }


    private async void Delete_Clicked(
        object sender,
        EventArgs e)
    {
        await DisplayAlert(
            "Delete",
            "Delete functionality will be added with SQLite.",
            "OK");
    }
}