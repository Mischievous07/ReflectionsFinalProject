using Reflections.ViewModels;
using Reflections.Models;
   
namespace Reflections.Views;

public partial class HomePage : ContentPage
{
    public HomePage(HomeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void NewEntry_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NewEntryPage));
    }

    private async void Entry_Selected(
    object sender,
    SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault()
            is JournalEntry entry)
        {

            var page = new EntryDetailPage(
                new EntryDetailViewModel());

            page.SetEntry(entry);

            await Navigation.PushAsync(page);

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}