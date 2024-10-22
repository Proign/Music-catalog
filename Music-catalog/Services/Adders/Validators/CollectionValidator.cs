using System;
using System.Collections.Generic;

namespace Music_catalog.Services
{
    public class CollectionValidator
    {
        // Метод для проверки корректности названия коллекции
        public void Validate(string collectionTitle)
        {
            if (string.IsNullOrWhiteSpace(collectionTitle))
            {
                throw new ArgumentException("Название коллекции не может быть пустым или содержать только пробелы.");
            }

            if (collectionTitle.Length < 3)
            {
                throw new ArgumentException("Название коллекции должно содержать не менее 3 символов.");
            }
        }

        // Метод для проверки выбранных треков по их идентификаторам
        public void ValidateTracks(List<int> trackIds)
        {
            if (trackIds == null || trackIds.Count == 0)
            {
                throw new ArgumentException("Вы должны выбрать хотя бы один трек для добавления в коллекцию.");
            }
        }
    }
}
