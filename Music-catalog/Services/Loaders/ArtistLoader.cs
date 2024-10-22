using System.Collections.Generic;
using System.Windows.Forms;
using Music_catalog.Models;
using Music_catalog.Repositories;

namespace Music_catalog.Services
{
    public class ArtistLoader : IDataLoader
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistLoader(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void LoadData(DataGridView artistGridView, string searchTerm)
        {
            List<Artist> artistData = _artistRepository.GetArtists(searchTerm);
            artistGridView.DataSource = artistData;

            artistGridView.Columns["Name"].HeaderText = "Исполнитель";
            artistGridView.Columns["Genre"].HeaderText = "Жанр";

            artistGridView.Columns["Id"].Visible = false;
            artistGridView.Columns["GenreId"].Visible = false;
        }

        public void LoadArtistsIntoComboBox(ComboBox artistComboBox)
        {
            try
            {
                var artists = _artistRepository.GetArtists();  // Получаем артистов через репозиторий

                artistComboBox.Items.Clear();

                foreach (var artist in artists)
                {
                    artistComboBox.Items.Add(new ArtistComboBoxItem(artist.Id, artist.Name));
                }

                if (artists.Count > 0)
                {
                    artistComboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке артистов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
    public class ArtistComboBoxItem
    {
        public int Id { get; }
        public string Name { get; }

        public ArtistComboBoxItem(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}