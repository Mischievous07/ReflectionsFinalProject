using Reflections.Models;
using Reflections.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Reflections.ViewModels;

public class EntryDetailViewModel : INotifyPropertyChanged
{
    private readonly DatabaseService databaseService;

    private JournalEntry? entry;

    public event PropertyChangedEventHandler? PropertyChanged;

    public EntryDetailViewModel(DatabaseService databaseService)
    {
        this.databaseService = databaseService;
    }

    public JournalEntry? Entry
    {
        get => entry;
        set
        {
            entry = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Content));
            OnPropertyChanged(nameof(Mood));
            OnPropertyChanged(nameof(Date));
        }
    }

    public string Title => Entry?.Title ?? "";
    public string Content => Entry?.Content ?? "";
    public string Mood => Entry?.Mood ?? "";
    public string Date => Entry?.DateCreated.ToString("MMMM dd, yyyy h:mm tt") ?? "";

    public void LoadEntry(JournalEntry selectedEntry)
    {
        Entry = selectedEntry;
    }

    public async Task DeleteEntryAsync()
    {
        if (Entry != null)
        {
            await databaseService.DeleteEntryAsync(Entry);
        }
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}