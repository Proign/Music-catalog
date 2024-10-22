using Music_catalog.Repositories;
using Music_catalog.Services.Loaders;
using Music_catalog.Services;

namespace Music_catalog.UI
{
    public partial class MainForm : Form
    {
        private readonly GenreRepository _genreRepository;
        private readonly ArtistRepository _artistRepository;
        private readonly AlbumRepository _albumRepository;
        private readonly TrackRepository _trackRepository;
        private readonly CollectionRepository _collectionRepository;
        private readonly AlbumValidator _albumValidator;
        private readonly TrackValidator _trackValidator;
        private readonly CollectionValidator _collectionValidator;
        private readonly CatalogViewer _catalogViewer;
        private readonly GenreValidator _genreValidator;
        private readonly ArtistValidator _artistValidator;
        private readonly IDataLoader[] _dataLoaders;
        private readonly DataDeleter _dataDeleter;

        public MainForm(
            CatalogViewer catalogViewer,
            AlbumRepository albumRepository,
            CollectionRepository collectionRepository,
            ArtistRepository artistRepository,
            GenreRepository genreRepository,
            TrackRepository trackRepository,
            GenreValidator genreValidator,
            ArtistValidator artistValidator,
            AlbumValidator albumValidator,
            TrackValidator trackValidator,
            CollectionValidator collectionValidator,
            IDataLoaderFactory dataLoaderFactory)
        {
            InitializeComponent();

            _genreRepository = genreRepository;
            _genreValidator = genreValidator;
            _artistRepository = artistRepository;
            _artistValidator = artistValidator;
            _albumRepository = albumRepository;
            _albumValidator = albumValidator;
            _trackRepository = trackRepository;
            _trackValidator = trackValidator;
            _collectionRepository = collectionRepository;
            _collectionValidator = collectionValidator;
            _catalogViewer = catalogViewer;
            _dataDeleter = new DataDeleter();

            // Инициализация загрузчиков данных через фабрику
            _dataLoaders = new IDataLoader[]
            {
                dataLoaderFactory.CreateLoader("Track"),
                dataLoaderFactory.CreateLoader("Album"),
                dataLoaderFactory.CreateLoader("Collection"),
                dataLoaderFactory.CreateLoader("Artist"),
                dataLoaderFactory.CreateLoader("Genre")
            };

            this.MaximizeBox = false;
            this.KeyPreview = true;
            this.KeyDown += MainForm_KeyDown;

            LoadData();
        }

        public void LoadData(string searchTerm = "")
        {
            foreach (var loader in _dataLoaders)
            {
                loader.LoadData(GetGridViewForLoader(loader), searchTerm);
            }
        }

        private DataGridView GetGridViewForLoader(IDataLoader loader)
        {
            return loader switch
            {
                TrackLoader => CatalogGridView,
                AlbumLoader => AlbumGridView,
                CollectionLoader => CollectionGridView,
                ArtistLoader => ArtistGridView,
                GenreLoader => GenreGridView,
                _ => throw new NotSupportedException("Unknown loader type")
            };
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = textBoxSearch.Text;
            LoadData(searchTerm);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = string.Empty;
            LoadData();
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
            if (cellValue != null)
            {
                textBoxSearch.Text = cellValue;
                LoadData(cellValue);
                CatalogTabControl.SelectedIndex = 0;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                HandleDelete();
                textBoxSearch.Text = string.Empty;
                LoadData();
            }
        }

        private void HandleDelete()
        {
            var selectedTab = CatalogTabControl.SelectedTab;

            if (selectedTab == tabPage4) // Artists
                _dataDeleter.DeleteItem(ArtistGridView, _artistRepository);
            else if (selectedTab == tabPage2) // Albums
                _dataDeleter.DeleteItem(AlbumGridView, _albumRepository);
            else if (selectedTab == tabPage3) // Collections
                _dataDeleter.DeleteItem(CollectionGridView, _collectionRepository);
            else if (selectedTab == tabPage1) // Tracks
                _dataDeleter.DeleteItem(CatalogGridView, _trackRepository);
            else if (selectedTab == tabPage5) // Genres
                _dataDeleter.DeleteItem(GenreGridView, _genreRepository);
        }

        // Метод для открытия AddForm
        private void AddFormButton_Click(object sender, EventArgs e)
        {
            AddForm newEntry = new AddForm(
                _genreRepository,
                _artistRepository,
                _trackRepository,
                _collectionRepository,
                _genreValidator,
                _artistValidator,
                _collectionValidator,
                new GenreLoader(_genreRepository),
                new ArtistLoader(_artistRepository),
                new AlbumLoader(_albumRepository),
                _albumRepository,
                new TrackLoader(_catalogViewer),
                _albumValidator,
                _trackValidator
            );

            newEntry.FormClosed += (s, args) => LoadData();

            newEntry.Show();
        }
    }
}