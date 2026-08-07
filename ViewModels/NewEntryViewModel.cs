using Reflections.Models;
using Reflections.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Reflections.ViewModels;

public class NewEntryViewModel : INotifyPropertyChanged
{
    private readonly DatabaseService databaseService;

    private int id;
    private string title = string.Empty;
    private string content = string.Empty;
    private DateTime selectedDate = DateTime.Today;
    private string selectedMood = "Happy";

    public event PropertyChangedEventHandler? PropertyChanged;

    public NewEntryViewModel(DatabaseService databaseService)
    {
        this.databaseService = databaseService;
    }

    public int Id
    {
        get => id;
        set
        {
            id = value;
            OnPropertyChanged();
        }
    }

    public string Title
    {
        get => title;
        set
        {
            title = value;
            OnPropertyChanged();
        }
    }

    public string Content
    {
        get => content;
        set
        {
            content = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(CharacterCount));
        }
    }

    public DateTime SelectedDate
    {
        get => selectedDate;
        set
        {
            selectedDate = value;
            OnPropertyChanged();
        }
    }

    public string SelectedMood
    {
        get => selectedMood;
        set
        {
            selectedMood = value;
            OnPropertyChanged();
        }
    }

    public List<string> Moods { get; } =
    [
        "Happy",
        "Calm",
        "Excited",
        "Sad",
        "Stressed",
        "Grateful"
    ];

    public int CharacterCount => Content.Length;

    public void LoadEntry(JournalEntry entry)
    {
        Id = entry.Id;
        Title = entry.Title;
        Content = entry.Content;
        SelectedMood = entry.Mood;
        SelectedDate = entry.DateCreated;
    }

    public async Task SaveEntryAsync()
    {
        JournalEntry entry = new()
        {
            Id = Id,
            Title = Title,
            Content = Content,
            Mood = SelectedMood,
            DateCreated = SelectedDate.Date.Add(DateTime.Now.TimeOfDay)
        };

        await databaseService.SaveEntryAsync(entry);
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}