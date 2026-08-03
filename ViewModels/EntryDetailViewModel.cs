using Reflections.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Reflections.ViewModels;

public class EntryDetailViewModel : INotifyPropertyChanged
{
    private JournalEntry? entry;

    public event PropertyChangedEventHandler? PropertyChanged;


    public JournalEntry? Entry
    {
        get => entry;
        set
        {
            entry = value;
            OnPropertyChanged();
        }
    }


    public string Title =>
        Entry?.Title ?? "No Title";


    public string Content =>
        Entry?.Content ?? "No Content";


    public string Mood =>
        Entry?.Mood ?? "Unknown";


    public string Date =>
        Entry?.DateCreated.ToString("MMMM dd, yyyy")
        ?? "";


    public void LoadEntry(JournalEntry selectedEntry)
    {
        Entry = selectedEntry;

        OnPropertyChanged(nameof(Title));
        OnPropertyChanged(nameof(Content));
        OnPropertyChanged(nameof(Mood));
        OnPropertyChanged(nameof(Date));
    }


    private void OnPropertyChanged(
        [CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(propertyName));
    }
}