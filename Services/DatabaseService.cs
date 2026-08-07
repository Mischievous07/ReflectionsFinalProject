using Reflections.Models;
using SQLite;

namespace Reflections.Services;

public class DatabaseService
{
    private SQLiteAsyncConnection? database;

    async Task Init()
    {
        if (database != null)
            return;

        string dbPath = Path.Combine(
            FileSystem.AppDataDirectory,
            "reflections.db3");

        database = new SQLiteAsyncConnection(dbPath);

        await database.CreateTableAsync<JournalEntry>();
    }

    public async Task<List<JournalEntry>> GetEntriesAsync()
    {
        await Init();

        return await database!
            .Table<JournalEntry>()
            .OrderByDescending(x => x.DateCreated)
            .ToListAsync();
    }

    public async Task<int> SaveEntryAsync(JournalEntry entry)
    {
        await Init();

        if (entry.Id != 0)
            return await database!.UpdateAsync(entry);

        return await database!.InsertAsync(entry);
    }

    public async Task<int> DeleteEntryAsync(JournalEntry entry)
    {
        await Init();

        return await database!.DeleteAsync(entry);
    }
}