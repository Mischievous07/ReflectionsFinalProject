namespace Reflections.Models;

public class JournalEntry
{
    public int Id { get; set; }

    public string Title { get; set; } = "";

    public string Content { get; set; } = "";

    public DateTime DateCreated { get; set; }

    public string Mood { get; set; } = "";
}