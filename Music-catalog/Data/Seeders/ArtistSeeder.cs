using Music_catalog.Models;
using Music_catalog.Repositories;

namespace Music_catalog.Seeders
{
    public class ArtistsSeeder
    {
        // Метод для добавления артистов
        public void SeedArtists(ArtistRepository artistRepository, GenreRepository genreRepository)
        {
            // Получаем ID жанров для корректного добавления артистов
            var rockId = genreRepository.GetGenreIdByName("Rock");
            var popId = genreRepository.GetGenreIdByName("Pop");
            var jazzId = genreRepository.GetGenreIdByName("Jazz");
            var classicalId = genreRepository.GetGenreIdByName("Classical");
            var hipHopId = genreRepository.GetGenreIdByName("Hip Hop");

            var artists = new[]
            {
                new Artist { Name = "The Beatles", GenreId = rockId },
                new Artist { Name = "Ariana Grande", GenreId = popId },
                new Artist { Name = "Miles Davis", GenreId = jazzId },
                new Artist { Name = "Ludwig van Beethoven", GenreId = classicalId },
                new Artist { Name = "Kendrick Lamar", GenreId = hipHopId }
            };

            foreach (var artist in artists)
            {
                artistRepository.AddArtist(artist.Name, artist.GenreId);
            }
        }
    }
}
