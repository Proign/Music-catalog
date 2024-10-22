using Microsoft.Data.Sqlite;
using System;
using System.IO;

namespace Music_catalog.Data
{
    public class DatabaseManager : IDatabaseManager
    {
        private readonly string _connectionString;
        private static DatabaseManager _instance;

        public DatabaseManager(string databaseFilePath)
        {
            _connectionString = $"Data Source={databaseFilePath}";
        }

        public static DatabaseManager GetInstance(string databaseFilePath)
        {
            if (_instance == null)
            {
                _instance = new DatabaseManager(databaseFilePath);
            }
            return _instance;
        }

        public SqliteConnection GetConnection()
        {
            return new SqliteConnection(_connectionString);
        }

        public void CreateDatabase()
        {
            if (!File.Exists("music_catalog.db"))
            {
                using var connection = GetConnection();
                connection.Open();

                ExecuteCommand(connection, @"
                        CREATE TABLE IF NOT EXISTS Artists (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            name TEXT NOT NULL,
                            genre_id INTEGER,
                            FOREIGN KEY(genre_id) REFERENCES Genres(id)
                        );");

                ExecuteCommand(connection, @"
                        CREATE TABLE IF NOT EXISTS Genres (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            name TEXT NOT NULL
                        );");

                ExecuteCommand(connection, @"
                        CREATE TABLE IF NOT EXISTS Albums (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            name TEXT NOT NULL,
                            artist_id INTEGER NOT NULL,
                            genre_id INTEGER,
                            FOREIGN KEY(artist_id) REFERENCES Artists(id),
                            FOREIGN KEY(genre_id) REFERENCES Genres(id)
                        );");

                ExecuteCommand(connection, @"
                        CREATE TABLE IF NOT EXISTS Collections (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            title TEXT NOT NULL
                        );");

                ExecuteCommand(connection, @"
                        CREATE TABLE IF NOT EXISTS Tracks (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            title TEXT NOT NULL,
                            artist_id INTEGER NOT NULL,
                            album_id INTEGER NOT NULL,
                            duration INTEGER NOT NULL,
                            collection_id INTEGER,
                            FOREIGN KEY(artist_id) REFERENCES Artists(id),
                            FOREIGN KEY(album_id) REFERENCES Albums(id),
                            FOREIGN KEY(collection_id) REFERENCES Collections(id) ON DELETE SET NULL
                        );");
            }
        }

        private void ExecuteCommand(SqliteConnection connection, string commandText)
        {
            using (var command = new SqliteCommand(commandText, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public bool IsDatabaseEmpty()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                int artistCount = ExecuteScalar(connection, "SELECT COUNT(*) FROM Artists");
                int genreCount = ExecuteScalar(connection, "SELECT COUNT(*) FROM Genres");

                return artistCount == 0 && genreCount == 0;
            }
        }

        private int ExecuteScalar(SqliteConnection connection, string query)
        {
            using (var command = new SqliteCommand(query, connection))
            {
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
    }
}
