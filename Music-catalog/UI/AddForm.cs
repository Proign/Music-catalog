using System;
using System.Windows.Forms;
using Music_catalog.Commands;
using Music_catalog.Models;
using Music_catalog.Repositories;
using Music_catalog.Services;
using Music_catalog.Services.Loaders;

namespace Music_catalog.UI
{
    public partial class AddForm : Form
    {
        private readonly GenreAdder _genreAdder;
        private readonly ArtistAdder _artistAdder;
        private readonly AlbumAdder _albumAdder;
        private readonly TrackAdder _trackAdder;
        private readonly CollectionAdder _collectionAdder;
        private readonly GenreLoader _genreLoader;
        private readonly AlbumLoader _albumLoader;
        private readonly ArtistLoader _artistLoader;
        private readonly TrackLoader _trackLoader;
        private readonly IGenreRepository _genreRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly ITrackRepository _trackRepository;
        private readonly ICollectionRepository _collectionRepository;
        private readonly AlbumValidator _albumValidator;
        private readonly GenreValidator _genreValidator;
        private readonly ArtistValidator _artistValidator;
        private readonly TrackValidator _trackValidator;
        private readonly CollectionValidator _collectionValidator;

        public AddForm(
            IGenreRepository genreRepository,
            IArtistRepository artistRepository,
            ITrackRepository trackRepository,
            ICollectionRepository collectionRepository, 
            GenreValidator genreValidator,
            ArtistValidator artistValidator,
            CollectionValidator collectionValidator,
            GenreLoader genreLoader,
            ArtistLoader artistLoader,
            AlbumLoader albumLoader,
            AlbumRepository albumRepository,
            TrackLoader trackLoader,
            AlbumValidator albumValidator,
            TrackValidator trackValidator)
        {
            InitializeComponent();

            this.MaximizeBox = false;

            _genreRepository = genreRepository;
            _artistRepository = artistRepository;
            _albumRepository = albumRepository;
            _trackRepository = trackRepository;
            _collectionRepository = collectionRepository;
            _albumValidator = albumValidator;
            _genreValidator = genreValidator;
            _artistValidator = artistValidator;
            _trackValidator = trackValidator;
            _collectionValidator = collectionValidator;

            _genreLoader = genreLoader;
            _artistLoader = artistLoader;
            _albumLoader = albumLoader;
            _trackLoader = trackLoader;

            _genreAdder = new GenreAdder(_genreRepository, _genreValidator);
            _artistAdder = new ArtistAdder(_artistRepository, _artistValidator);
            _albumAdder = new AlbumAdder(_albumRepository, _albumValidator);
            _trackAdder = new TrackAdder(_trackRepository, _trackValidator);
            _collectionAdder = new CollectionAdder(_collectionRepository, _collectionValidator); // Инициализация

            // Загрузка жанров в ComboBox
            _genreLoader.LoadGenresIntoComboBox(GenreComboBox);
            _genreLoader.LoadGenresIntoComboBox(AlbumGenreComboBox);

            _artistLoader.LoadArtistsIntoComboBox(GetArtistComboBox);
            _artistLoader.LoadArtistsIntoComboBox(TrackArtistComboBox);

            _albumLoader.LoadAlbumsIntoComboBox(GetAlbumComboBox);

            _trackLoader.LoadTracksIntoCheckedListBox(CollectionCListBox);
        }

        // Метод для обработки нажатия кнопки "Добавить"
        private void AddButton_Click(object sender, EventArgs e)
        {
            var commands = new List<ICommand>();

            string genreName = GenreTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(genreName))
            {
                commands.Add(new AddGenreCommand(_genreAdder, genreName, GenreTextBox));
            }

            string artistName = ArtistNameTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(artistName))
            {
                var selectedGenreItem = (GenreComboBoxItem)GenreComboBox.SelectedItem;
                if (selectedGenreItem != null)
                {
                    int genreId = selectedGenreItem.Id;
                    commands.Add(new AddArtistCommand(_artistAdder, artistName, genreId, ArtistNameTextBox));
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите жанр.");
                }
            }

            string albumName = AlbumTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(albumName))
            {
                var selectedArtistItem = (ArtistComboBoxItem)GetArtistComboBox.SelectedItem;
                var selectedAlbumGenreItem = (GenreComboBoxItem)AlbumGenreComboBox.SelectedItem;

                if (selectedArtistItem != null && selectedAlbumGenreItem != null)
                {
                    int artistId = selectedArtistItem.Id;
                    int genreId = selectedAlbumGenreItem.Id;
                    commands.Add(new AddAlbumCommand(_albumAdder, albumName, artistId, genreId, AlbumTextBox));
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите жанр и артиста.");
                }
            }

            string trackTitle = TrackNameTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(trackTitle))
            {
                var selectedTrackArtist = (ArtistComboBoxItem)TrackArtistComboBox.SelectedItem;
                var selectedTrackAlbum = (AlbumComboBoxItem)GetAlbumComboBox.SelectedItem;

                if (selectedTrackArtist != null && selectedTrackAlbum != null && int.TryParse(TrackDurationTextBox.Text, out int duration))
                {
                    int artistId = selectedTrackArtist.Id;
                    int albumId = selectedTrackAlbum.Id;

                    try
                    {
                        _trackValidator.Validate(trackTitle, duration);
                        commands.Add(new AddTrackCommand(_trackAdder, trackTitle, artistId, albumId, duration, TrackNameTextBox, TrackDurationTextBox));
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите артиста и альбом, а также введите корректную продолжительность трека.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            string collectionTitle = CollectionTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(collectionTitle))
            {
                try
                {
                    List<int> selectedTrackIds = CollectionCListBox.CheckedItems
                        .Cast<TrackCheckedListItem>()
                        .Select(trackItem => trackItem.Id)
                        .ToList();

                    if (selectedTrackIds.Count > 0)
                    {
                        commands.Add(new AddCollectionCommand(_collectionAdder, collectionTitle, selectedTrackIds));
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, выберите хотя бы один трек для добавления в коллекцию.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Выполнение всех команд
            foreach (var command in commands)
            {
                command.Execute();
            }
        }
    }
}