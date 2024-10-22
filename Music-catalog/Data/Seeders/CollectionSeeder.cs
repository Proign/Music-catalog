using Music_catalog.Models;
using Music_catalog.Repositories;

namespace Music_catalog.Seeders
{
    public class CollectionSeeder
    {
        // Метод для добавления коллекций
        public void SeedCollections(CollectionRepository collectionRepository)
        {
            // Пример коллекций
            var collections = new[]
            {
                new Collection { Title = "Greatest Hits" },
                new Collection { Title = "Chill Vibes" },
                new Collection { Title = "Workout Playlist" },
                new Collection { Title = "Classical Masterpieces" },
                new Collection { Title = "Jazz Essentials" }
            };

            // Добавляем коллекции через репозиторий
            foreach (var collection in collections)
            {
                collectionRepository.AddCollection(collection.Title);
            }
        }
    }
}