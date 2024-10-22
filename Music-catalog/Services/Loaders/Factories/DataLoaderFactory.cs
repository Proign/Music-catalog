using Music_catalog.Repositories;

namespace Music_catalog.Services.Loaders
{
    public class DataLoaderFactory : IDataLoaderFactory
    {
        private readonly GenreRepository _genreRepository;
        private readonly ArtistRepository _artistRepository;
        private readonly AlbumRepository _albumRepository;
        private readonly TrackRepository _trackRepository;
        private readonly CollectionRepository _collectionRepository;
        private readonly CatalogViewer _catalogViewer;

        public DataLoaderFactory(
            GenreRepository genreRepository,
            ArtistRepository artistRepository,
            AlbumRepository albumRepository,
            TrackRepository trackRepository,
            CollectionRepository collectionRepository,
            CatalogViewer catalogViewer)
        {
            _genreRepository = genreRepository;
            _artistRepository = artistRepository;
            _albumRepository = albumRepository;
            _trackRepository = trackRepository;
            _collectionRepository = collectionRepository;
            _catalogViewer = catalogViewer;
        }

        public IDataLoader CreateLoader(string loaderType)
        {
            return loaderType switch
            {
                "Track" => new TrackLoader(_catalogViewer),
                "Album" => new AlbumLoader(_albumRepository),
                "Collection" => new CollectionLoader(_collectionRepository),
                "Artist" => new ArtistLoader(_artistRepository),
                "Genre" => new GenreLoader(_genreRepository),
                _ => throw new NotSupportedException("Unknown loader type")
            };
        }
    }
}

