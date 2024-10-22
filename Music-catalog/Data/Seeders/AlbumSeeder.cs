using Music_catalog.Models;
using Music_catalog.Repositories;

namespace Music_catalog.Seeders
{
    public class AlbumSeeder
    {
        // Метод для добавления альбомов
        public void SeedAlbums(AlbumRepository albumRepository, ArtistRepository artistRepository, GenreRepository genreRepository)
        {
            // Получаем ID артистов для корректного добавления альбомов
            var beatlesId = artistRepository.GetArtistIdByName("The Beatles");
            var arianaGrandeId = artistRepository.GetArtistIdByName("Ariana Grande");
            var milesDavisId = artistRepository.GetArtistIdByName("Miles Davis");
            var beethovenId = artistRepository.GetArtistIdByName("Ludwig van Beethoven");
            var kendrickLamarId = artistRepository.GetArtistIdByName("Kendrick Lamar");

            var rockId = genreRepository.GetGenreIdByName("Rock");
            var popId = genreRepository.GetGenreIdByName("Pop");
            var jazzId = genreRepository.GetGenreIdByName("Jazz");
            var classicalId = genreRepository.GetGenreIdByName("Classical");
            var hipHopId = genreRepository.GetGenreIdByName("Hip Hop");

            // Пример альбомов
            var albums = new[]
            {
                new Album { Title = "Abbey Road", ArtistId = beatlesId, GenreId = rockId },
                new Album { Title = "Thank U, Next", ArtistId = arianaGrandeId, GenreId = popId },
                new Album { Title = "Kind of Blue", ArtistId = milesDavisId, GenreId = jazzId },
                new Album { Title = "Symphony No. 9", ArtistId = beethovenId, GenreId = classicalId },
                new Album { Title = "DAMN.", ArtistId = kendrickLamarId, GenreId = hipHopId }
            };

            // Добавляем альбомы через репозиторий
            foreach (var album in albums)
            {
                albumRepository.AddAlbum(album.Title, album.ArtistId, album.GenreId);
            }
        }
    }
}