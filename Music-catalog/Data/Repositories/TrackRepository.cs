using Microsoft.Data.Sqlite;
using Music_catalog.Data;
using Music_catalog.Models;
using System;
using System.Collections.Generic;

namespace Music_catalog.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly DatabaseManager _dbManager;

        public TrackRepository(DatabaseManager dbManager)
        {
            _dbManager = dbManager;
        }

        public void AddTrack(string title, int artistId, int albumId, int duration, int? collectionId = null)
        {
            using (var connection = _dbManager.GetConnection())
            {
                connection.Open();

                var command = new SqliteCommand(
                    "INSERT INTO Tracks (title, artist_id, album_id, duration, collection_id) " +
                    "VALUES (@title, @artistId, @albumId, @duration, @collectionId)", connection);

                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@artistId", artistId);
                command.Parameters.AddWithValue("@albumId", albumId);
                command.Parameters.AddWithValue("@duration", duration);

                command.Parameters.AddWithValue("@collectionId", collectionId.HasValue ? (object)collectionId.Value : DBNull.Value);

                command.ExecuteNonQuery();
            }
        }

        // Метод для получения всех треков
        public List<Track> GetAllTracks()
        {
            using (var connection = _dbManager.GetConnection())
            {
                connection.Open();

                // Создаем экземпляр TrackQueryBuilder
                var queryBuilder = new TrackQueryBuilder();
                var query = queryBuilder.Build();

                var command = new SqliteCommand(query, connection);
                using (var reader = command.ExecuteReader())
                {
                    var tracks = new List<Track>();

                    while (reader.Read())
                    {
                        var track = new Track
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            ArtistId = reader.GetInt32(2),
                            AlbumId = reader.GetInt32(3),
                            Duration = reader.GetInt32(4),
                            CollectionId = reader.IsDBNull(5) ? (int?)null : reader.GetInt32(5)
                        };

                        tracks.Add(track);
                    }

                    return tracks; 
                }
            }
        }

        public void Delete(int trackId)
        {
            using (var connection = _dbManager.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Удаление трека
                        var deleteTrack = new SqliteCommand("DELETE FROM Tracks WHERE id = @trackId", connection, transaction);
                        deleteTrack.Parameters.AddWithValue("@trackId", trackId);
                        deleteTrack.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Ошибка при удалении трека.", ex);
                    }
                }
            }
        }
    }
}