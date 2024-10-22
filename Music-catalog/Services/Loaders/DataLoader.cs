using Music_catalog.Services.Loaders;
using System.Windows.Forms;

namespace Music_catalog.Services
{
    public class DataLoader
    {
        private readonly TrackLoader _trackLoader;
        private readonly AlbumLoader _albumLoader;
        private readonly CollectionLoader _collectionLoader;
        private readonly ArtistLoader _artistLoader;
        private readonly GenreLoader _genreLoader;

        public DataLoader(TrackLoader trackLoader, AlbumLoader albumLoader, CollectionLoader collectionLoader, ArtistLoader artistLoader, GenreLoader genreLoader)
        {
            _trackLoader = trackLoader;
            _albumLoader = albumLoader;
            _collectionLoader = collectionLoader;
            _artistLoader = artistLoader;
            _genreLoader = genreLoader;
        }

        public void LoadTracksData(DataGridView catalogGridView, string searchTerm)
        {
            _trackLoader.LoadData(catalogGridView, searchTerm);
        }

        public void LoadAlbumsData(DataGridView albumGridView, string searchTerm)
        {
            _albumLoader.LoadData(albumGridView, searchTerm);
        }

        public void LoadCollectionsData(DataGridView collectionGridView, string searchTerm)
        {
            _collectionLoader.LoadData(collectionGridView, searchTerm);
        }

        public void LoadArtistsData(DataGridView artistGridView, string searchTerm)
        {
            _artistLoader.LoadData(artistGridView, searchTerm);
        }

        public void LoadGenresData(DataGridView genreGridView, string searchTerm)
        {
            _genreLoader.LoadData(genreGridView, searchTerm);
        }
    }
}
