using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Reflections.ViewModels;

public class NewEntryViewModel : INotifyPropertyChanged
{
    private string title = string.Empty;
    private string content = string.Empty;
    private DateTime selectedDate = DateTime.Today;
    private string selectedMood = "Happy";

    public event PropertyChangedEventHandler? PropertyChanged;

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

    void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}