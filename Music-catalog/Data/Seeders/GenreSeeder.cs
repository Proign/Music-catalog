using Music_catalog.Models;
using Music_catalog.Repositories;

namespace Music_catalog.Seeders
{
    public class GenreSeeder
    {
        // Метод для добавления жанров
        public void SeedGenres(GenreRepository genreRepository)
        {
            var genres = new[]
            {
                new Genre { Name = "Rock" },
                new Genre { Name = "Pop" },
                new Genre { Name = "Jazz" },
                new Genre { Name = "Classical" },
                new Genre { Name = "Hip Hop" }
            };

            foreach (var genre in genres)
            {
                genreRepository.AddGenre(genre.Name);
            }
        }
    }
}
