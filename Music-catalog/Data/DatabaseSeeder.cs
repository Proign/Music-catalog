using Music_catalog.Data;
using Music_catalog.Repositories;
using Music_catalog.Seeders;

namespace Music_catalog.Services
{
    public class DatabaseSeeder
    {
        private readonly GenreRepository _genreRepository;
        private readonly GenreSeeder _genreSeeder;
        private readonly ArtistRepository _artistRepository;
        private readonly ArtistsSeeder _artistsSeeder;
        private readonly AlbumRepository _albumRepository;
        private readonly AlbumSeeder _albumSeeder;
        private readonly TrackRepository _trackRepository;
        private readonly TrackSeeder _trackSeeder;
        private readonly CollectionRepository _collectionRepository;
        private readonly CollectionSeeder _collectionSeeder;

        public DatabaseSeeder(
            GenreRepository genreRepository,
            GenreSeeder genreSeeder,
            ArtistRepository artistRepository,
            ArtistsSeeder artistsSeeder,
            AlbumRepository albumRepository,
            AlbumSeeder albumSeeder,
            TrackRepository trackRepository,
            TrackSeeder trackSeeder,
            CollectionRepository collectionRepository,
            CollectionSeeder collectionSeeder)
        {
            _genreRepository = genreRepository;
            _genreSeeder = genreSeeder;
            _artistRepository = artistRepository;
            _artistsSeeder = artistsSeeder;
            _albumRepository = albumRepository;
            _albumSeeder = albumSeeder;
            _trackRepository = trackRepository;
            _trackSeeder = trackSeeder;
            _collectionRepository = collectionRepository;
            _collectionSeeder = collectionSeeder;
        }

        public void SeedDatabase(DatabaseManager databaseManager)
        {
            if (databaseManager.IsDatabaseEmpty())
            {
                SeedAll();
            }
        }

        private void SeedAll()
        {
            _genreSeeder.SeedGenres(_genreRepository);
            _artistsSeeder.SeedArtists(_artistRepository, _genreRepository);
            _albumSeeder.SeedAlbums(_albumRepository, _artistRepository, _genreRepository);
            _collectionSeeder.SeedCollections(_collectionRepository);
            _trackSeeder.SeedTracks(_trackRepository, _artistRepository, _albumRepository, _collectionRepository);
        }
    }
}
