using Microsoft.Data.Sqlite;
using Music_catalog.Data;
using Music_catalog.Models;
using System.Collections.Generic;

namespace Music_catalog.Services
{
    public class CatalogViewer
    {
        private readonly DatabaseManager _dbManager;

        public CatalogViewer(DatabaseManager dbManager)
        {
            _dbManager = dbManager;
        }

        // Метод для получения списка треков с возможностью поиска
        public List<Track> GetTracks(string searchTerm = "")
        {
            var tracks = new List<Track>();

            using (var connection = _dbManager.GetConnection())
            {
                connection.Open();

                // Создаем экземпляр ViewerQueryBuilder
                var queryBuilder = new ViewerQueryBuilder();

                // Добавляем условия для поиска
                queryBuilder.WhereLike(searchTerm);
                var query = queryBuilder.Build(out var parameters, searchTerm);

                using (var command = new SqliteCommand(query, connection))
                {
                    // Добавляем параметры для поиска
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        command.Parameters.Add(parameters[0]);
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var track = new Track
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                ArtistId = reader.GetInt32(2),
                                ArtistName = reader.GetString(3),
                                AlbumId = reader.GetInt32(4),
                                AlbumName = reader.GetString(5),
                                Duration = reader.GetInt32(6),
                                CollectionId = reader.IsDBNull(7) ? (int?)null : reader.GetInt32(7),
                                CollectionTitle = reader.IsDBNull(8) ? null : reader.GetString(8),
                                GenreId = reader.IsDBNull(9) ? 0 : reader.GetInt32(9), 
                                GenreName = reader.IsDBNull(10) ? null : reader.GetString(10)
                            };
                            tracks.Add(track);
                        }
                    }
                }
            }

            return tracks;
        }
    }
}