using Microsoft.Data.Sqlite;
using Music_catalog.Data;
using Music_catalog.Models;
using System;
using System.Collections.Generic;

namespace Music_catalog.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly IDatabaseManager _dbConnection;

        public ArtistRepository(IDatabaseManager dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<Artist> GetArtists(string searchTerm = "")
        {
            var artists = new List<Artist>();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                var queryBuilder = new ArtistQueryBuilder();

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    queryBuilder
                        .Where("Artists.name LIKE @searchTerm", searchTerm)
                        .Where("Albums.name LIKE @searchTerm", searchTerm)
                        .Where("Genres.name LIKE @searchTerm", searchTerm);
                }

                var (query, parameters) = queryBuilder.Build();

                using (var command = new SqliteCommand(query, connection))
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var artist = new Artist
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                GenreId = reader.IsDBNull(2) ? -1 : reader.GetInt32(2),
                                Genre = reader.IsDBNull(3) ? "Unknown" : reader.GetString(3)
                            };
                            artists.Add(artist);
                        }
                    }
                }
            }

            return artists;
        }

        public int AddArtist(string artistName, int genreId)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                var command = new SqliteCommand("INSERT INTO Artists (name, genre_id) VALUES (@name, @genreId); SELECT last_insert_rowid();", connection);

                // Добавляем параметры в команду
                command.Parameters.AddWithValue("@name", artistName);
                command.Parameters.AddWithValue("@genreId", genreId);

                // Выполняем запрос и возвращаем ID артиста
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public int GetArtistIdByName(string artistName)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                var command = new SqliteCommand("SELECT id FROM Artists WHERE name = @name LIMIT 1", connection);
                command.Parameters.AddWithValue("@name", artistName);

                var result = command.ExecuteScalar();

                if (result != null)
                {
                    return (int)(long)result;
                }
                else
                {
                    throw new KeyNotFoundException($"Artist '{artistName}' not found.");
                }
            }
        }

        public void Delete(int artistId)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Удаляем все треки артиста
                        var deleteTracks = new SqliteCommand("DELETE FROM Tracks WHERE artist_id = @artistId", connection, transaction);
                        deleteTracks.Parameters.AddWithValue("@artistId", artistId);
                        deleteTracks.ExecuteNonQuery();

                        // Удаляем все альбомы артиста
                        var deleteAlbums = new SqliteCommand("DELETE FROM Albums WHERE artist_id = @artistId", connection, transaction);
                        deleteAlbums.Parameters.AddWithValue("@artistId", artistId);
                        deleteAlbums.ExecuteNonQuery();

                        // Удаляем артиста
                        var deleteArtist = new SqliteCommand("DELETE FROM Artists WHERE id = @artistId", connection, transaction);
                        deleteArtist.Parameters.AddWithValue("@artistId", artistId);
                        deleteArtist.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

    }
}