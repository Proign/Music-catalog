using Music_catalog.Models;
using Music_catalog.Repositories;

namespace Music_catalog.Seeders
{
    public class TrackSeeder
    {
        // Метод для добавления треков
        public void SeedTracks(TrackRepository trackRepository, ArtistRepository artistRepository, AlbumRepository albumRepository, CollectionRepository collectionRepository)
        {
            // Получаем ID артистов и альбомов для корректного добавления треков
            var beatlesId = artistRepository.GetArtistIdByName("The Beatles");
            var arianaGrandeId = artistRepository.GetArtistIdByName("Ariana Grande");
            var milesDavisId = artistRepository.GetArtistIdByName("Miles Davis");
            var beethovenId = artistRepository.GetArtistIdByName("Ludwig van Beethoven");
            var kendrickLamarId = artistRepository.GetArtistIdByName("Kendrick Lamar");

            var beatlesAlbumId = albumRepository.GetAlbumIdByName("Abbey Road");
            var arianaAlbumId = albumRepository.GetAlbumIdByName("Thank U, Next");
            var milesAlbumId = albumRepository.GetAlbumIdByName("Kind of Blue");
            var beethovenAlbumId = albumRepository.GetAlbumIdByName("Symphony No. 9");
            var kendrickAlbumId = albumRepository.GetAlbumIdByName("DAMN.");

            // Получаем ID коллекций для треков, если необходимо
            var greatestHitsCollectionId = collectionRepository.GetCollectionIdByTitle("Greatest Hits");
            var chillVibesCollectionId = collectionRepository.GetCollectionIdByTitle("Chill Vibes");

            // Пример треков с привязкой к коллекциям
            var tracks = new[]
            {
                new Track { Title = "Come Together", ArtistId = beatlesId, AlbumId = beatlesAlbumId, Duration = 259, CollectionId = greatestHitsCollectionId },
                new Track { Title = "7 rings", ArtistId = arianaGrandeId, AlbumId = arianaAlbumId, Duration = 178, CollectionId = chillVibesCollectionId },
                new Track { Title = "So What", ArtistId = milesDavisId, AlbumId = milesAlbumId, Duration = 565, CollectionId = chillVibesCollectionId },
                new Track { Title = "Ode to Joy", ArtistId = beethovenId, AlbumId = beethovenAlbumId, Duration = 600, CollectionId = null }, // Без коллекции
                new Track { Title = "HUMBLE.", ArtistId = kendrickLamarId, AlbumId = kendrickAlbumId, Duration = 177, CollectionId = greatestHitsCollectionId }
            };

            // Добавляем треки через репозиторий
            foreach (var track in tracks)
            {
                trackRepository.AddTrack(track.Title, track.ArtistId, track.AlbumId, track.Duration, track.CollectionId);
            }
        }
    }
}