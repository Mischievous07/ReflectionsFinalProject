using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Reflections.Models;
using Reflections.Services;

namespace Reflections.ViewModels;

public class HomeViewModel : INotifyPropertyChanged
{
    private readonly DatabaseService databaseService;

    private List<JournalEntry> allEntries = new();

    private string searchText = string.Empty;

    public ObservableCollection<JournalEntry> Entries { get; } = new();


    public event PropertyChangedEventHandler? PropertyChanged;


    public HomeViewModel(DatabaseService databaseService)
    {
        this.databaseService = databaseService;
    }


    public string SearchText
    {
        get => searchText;

        set
        {
            searchText = value;

            OnPropertyChanged();

            FilterEntries();
        }
    }


    public async Task LoadEntriesAsync()
    {
        allEntries = (await databaseService.GetEntriesAsync())
        .OrderByDescending(x => x.DateCreated)
        .ToList();

        FilterEntries();
    }


    private void FilterEntries()
    {
        Entries.Clear();

        IEnumerable<JournalEntry> filteredEntries = allEntries;


        if (!string.IsNullOrWhiteSpace(SearchText))
        {
            filteredEntries = allEntries.Where(entry =>
                entry.Title.Contains(
                    SearchText,
                    StringComparison.OrdinalIgnoreCase)
                ||
                entry.Content.Contains(
                    SearchText,
                    StringComparison.OrdinalIgnoreCase)
                ||
                entry.Mood.Contains(
                    SearchText,
                    StringComparison.OrdinalIgnoreCase));
        }


        foreach (JournalEntry entry in filteredEntries)
        {
            Entries.Add(entry);
        }
    }


    private void OnPropertyChanged(
        [CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(propertyName));
    }
}