using SQLite;

namespace Reflections.Models;

public class JournalEntry
{
    [PrimaryKey]
    [AutoIncrement]
    public int Id { get; set; }

    public string Title { get; set; } = "";

    public string Content { get; set; } = "";

    public string Mood { get; set; } = "";

    public DateTime DateCreated { get; set; }
}