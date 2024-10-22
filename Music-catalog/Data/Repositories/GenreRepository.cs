using Microsoft.Data.Sqlite;
using Music_catalog.Data;
using Music_catalog.Models;
using System;
using System.Collections.Generic;

namespace Music_catalog.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DatabaseManager _dbManager;

        public GenreRepository(DatabaseManager dbManager)
        {
            _dbManager = dbManager;
        }

        public int AddGenre(string genreName)
        {
            using (var connection = _dbManager.GetConnection())
            {
                connection.Open();
                var command = new SqliteCommand("INSERT INTO Genres (name) VALUES (@name); SELECT last_insert_rowid();", connection);
                command.Parameters.AddWithValue("@name", genreName);
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public int GetGenreIdByName(string genreName)
        {
            using (var connection = _dbManager.GetConnection())
            {
                connection.Open();
                var command = new SqliteCommand("SELECT id FROM Genres WHERE name = @name LIMIT 1", connection);
                command.Parameters.AddWithValue("@name", genreName);
                var result = command.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result); // Возвращаем ID жанра
                }
                else
                {
                    throw new KeyNotFoundException($"Genre '{genreName}' not found.");
                }
            }
        }

        // Реализация метода для получения всех жанров
        public List<Genre> GetAllGenres()
        {
            var genres = new List<Genre>();

            using (var connection = _dbManager.GetConnection())
            {
                connection.Open();

                // Создаем экземпляр GenreQueryBuilder
                var queryBuilder = new GenreQueryBuilder();
                var query = queryBuilder.Build();

                var command = new SqliteCommand(query, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        genres.Add(new Genre
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                }
            }

            return genres;
        }

        public void Delete(int genreId)
        {
            using (var connection = _dbManager.GetConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Удаление треков, связанных с альбомами этого жанра
                        var deleteTracksCommand = new SqliteCommand(@"
                        DELETE FROM Tracks 
                        WHERE album_id IN (SELECT id FROM Albums WHERE genre_id = @genreId)
                        ", connection, transaction);
                        deleteTracksCommand.Parameters.AddWithValue("@genreId", genreId);
                        deleteTracksCommand.ExecuteNonQuery();

                        // Удаление альбомов, связанных с этим жанром
                        var deleteAlbumsCommand = new SqliteCommand(@"
                        DELETE FROM Albums 
                        WHERE genre_id = @genreId
                        ", connection, transaction);
                        deleteAlbumsCommand.Parameters.AddWithValue("@genreId", genreId);
                        deleteAlbumsCommand.ExecuteNonQuery();

                        // Удаление артистов, связанных с этим жанром
                        var deleteArtistsCommand = new SqliteCommand(@"
                        DELETE FROM Artists 
                        WHERE genre_id = @genreId
                        ", connection, transaction);
                        deleteArtistsCommand.Parameters.AddWithValue("@genreId", genreId);
                        deleteArtistsCommand.ExecuteNonQuery();

                        // Удаление самого жанра
                        var deleteGenreCommand = new SqliteCommand(@"
                        DELETE FROM Genres 
                        WHERE id = @genreId
                        ", connection, transaction);
                        deleteGenreCommand.Parameters.AddWithValue("@genreId", genreId);
                        deleteGenreCommand.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Ошибка при удалении жанра и связанных данных.", ex);
                    }
                }
            }
        }
    }
}