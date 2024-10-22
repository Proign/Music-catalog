using Microsoft.Data.Sqlite;

namespace Music_catalog.Data
{
    public interface IDatabaseManager
    {
        SqliteConnection GetConnection();
    }
}
