using Microsoft.Data.Sqlite;
using Music_catalog.Data;
using Music_catalog.Models;
using System;
using System.Collections.Generic;

namespace Music_catalog.Repositories
{
    public class CollectionRepository : ICollectionRepository
    {
        private readonly DatabaseManager _dbManager;

        public CollectionRepository(DatabaseManager dbManager)
        {
            _dbManager = dbManager;
        }

        // Метод для добавления коллекции в базу данных
        public int AddCollection(string collectionTitle)
        {
            using (var connection = _dbManager.GetConnection())
            {
                connection.Open();
                var command = new SqliteCommand("INSERT INTO Collections (title) VALUES (@title); SELECT last_insert_rowid();", connection);
                command.Parameters.AddWithValue("@title", collectionTitle);

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        // Метод для получения всех коллекций
        public List<Collection> GetCollections(string searchTerm = "")
        {
            var collections = new List<Collection>();

            using (var connection = _dbManager.GetConnection())
            {
                connection.Open();

                // Создаем экземпляр CollectionQueryBuilder
                var queryBuilder = new CollectionQueryBuilder();
                queryBuilder.WhereTitleLike(searchTerm);

                var (query, parameters) = queryBuilder.Build();

                using (var command = new SqliteCommand(query, connection))
                {
                    // Добавляем параметры в команду
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var collection = new Collection
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1)
                            };
                            collections.Add(collection);
                        }
                    }
                }
            }

            return collections;
        }

        // Метод для получения ID коллекции по названию
        public int GetCollectionIdByTitle(string collectionTitle)
        {
            using (var connection = _dbManager.GetConnection())
            {
                connection.Open();
                var command = new SqliteCommand("SELECT id FROM Collections WHERE title = @title LIMIT 1", connection);
                command.Parameters.AddWithValue("@title", collectionTitle);
                var result = command.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result); // Возвращаем ID коллекции
                }
                else
                {
                    throw new KeyNotFoundException($"Collection '{collectionTitle}' not found.");
                }
            }
        }

        // Реализация метода для обновления коллекции у трека
        public void UpdateTrackCollection(int trackId, int collectionId)
        {
            using (var connection = _dbManager.GetConnection())
            {
                connection.Open();
                var command = new SqliteCommand("UPDATE Tracks SET collection_id = @collectionId WHERE id = @trackId", connection);
                command.Parameters.AddWithValue("@collectionId", collectionId);
                command.Parameters.AddWithValue("@trackId", trackId);

                var rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new KeyNotFoundException($"Track with ID '{trackId}' not found.");
                }
            }
        }

        public void Delete(int collectionId)
        {
            using (var connection = _dbManager.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Удаляем коллекцию
                        var deleteCollection = new SqliteCommand("DELETE FROM Collections WHERE id = @collectionId", connection, transaction);
                        deleteCollection.Parameters.AddWithValue("@collectionId", collectionId);
                        deleteCollection.ExecuteNonQuery();

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