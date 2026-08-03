using System.Collections.ObjectModel;
using Reflections.Models;

namespace Reflections.ViewModels;

public class HomeViewModel
{
    public ObservableCollection<JournalEntry> Entries { get; } = new();

    public HomeViewModel()
    {
        Entries.Add(new JournalEntry
        {
            Id = 1,
            Title = "A Productive Day",
            Content = "Today I made great progress on my MAUI project.",
            DateCreated = DateTime.Now.AddDays(-1)
        });

        Entries.Add(new JournalEntry
        {
            Id = 2,
            Title = "Weekend Thoughts",
            Content = "Looking forward to relaxing and spending time with family.",
            DateCreated = DateTime.Now.AddDays(-2)
        });

        Entries.Add(new JournalEntry
        {
            Id = 3,
            Title = "New Goals",
            Content = "I want to journal more consistently this month.",
            DateCreated = DateTime.Now.AddDays(-5)
        });
    }
}