using Microsoft.Data.Sqlite;
using Music_catalog.Data;
using Music_catalog.Models;
using System;
using System.Collections.Generic;

namespace Music_catalog.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly IDatabaseManager _dbConnection;

        public AlbumRepository(IDatabaseManager dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public int AddAlbum(string albumName, int artistId, int genreId)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                var command = new SqliteCommand("INSERT INTO Albums (name, artist_id, genre_id) VALUES (@name, @artistId, @genreId); SELECT last_insert_rowid();", connection);
                command.Parameters.AddWithValue("@name", albumName);
                command.Parameters.AddWithValue("@artistId", artistId);
                command.Parameters.AddWithValue("@genreId", genreId);

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public List<Album> GetAlbums(string searchTerm = "")
        {
            var albums = new List<Album>();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                var queryBuilder = new AlbumQueryBuilder();

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    queryBuilder
                        .Where("Albums.name LIKE @searchTerm", searchTerm)
                        .Where("Artists.name LIKE @searchTerm", searchTerm)
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
                            var album = new Album
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                ArtistId = reader.GetInt32(2),
                                ArtistName = reader.GetString(3),
                                GenreId = reader.GetInt32(4),
                                GenreName = reader.GetString(5)
                            };
                            albums.Add(album);
                        }
                    }
                }
            }

            return albums;
        }

        public int GetAlbumIdByName(string albumName)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                var command = new SqliteCommand("SELECT id FROM Albums WHERE name = @name LIMIT 1", connection);
                command.Parameters.AddWithValue("@name", albumName);

                var result = command.ExecuteScalar();

                if (result != null)
                {
                    return (int)(long)result;
                }
                else
                {
                    throw new KeyNotFoundException($"Album '{albumName}' not found.");
                }
            }
        }

        public void Delete(int albumId)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Удаляем все треки из альбома
                        var deleteTracks = new SqliteCommand("DELETE FROM Tracks WHERE album_id = @albumId", connection, transaction);
                        deleteTracks.Parameters.AddWithValue("@albumId", albumId);
                        deleteTracks.ExecuteNonQuery();

                        // Удаляем альбом
                        var deleteAlbum = new SqliteCommand("DELETE FROM Albums WHERE id = @albumId", connection, transaction);
                        deleteAlbum.Parameters.AddWithValue("@albumId", albumId);
                        deleteAlbum.ExecuteNonQuery();

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