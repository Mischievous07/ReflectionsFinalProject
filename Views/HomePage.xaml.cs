using Reflections.Models;
using Reflections.ViewModels;

namespace Reflections.Views;

public partial class HomePage : ContentPage
{
    private readonly HomeViewModel viewModel;

    public HomePage(HomeViewModel vm)
    {
        InitializeComponent();

        viewModel = vm;
        BindingContext = viewModel;
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await viewModel.LoadEntriesAsync();
    }


    private async void NewEntry_Clicked(object sender, EventArgs e)
    {
        var page = Handler.MauiContext!
            .Services
            .GetService<NewEntryPage>();

        await Navigation.PushAsync(page!);
    }


    private async void Entry_Selected(
        object sender,
        SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is JournalEntry entry)
        {
            var page = Handler.MauiContext!
                .Services
                .GetService<EntryDetailPage>();

            page!.SetEntry(entry);

            await Navigation.PushAsync(page);

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}