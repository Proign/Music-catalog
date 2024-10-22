using System.Collections.Generic;
using System.Windows.Forms;
using Music_catalog.Models;
using Music_catalog.Repositories; 

namespace Music_catalog.Services.Loaders
{
    public class TrackLoader : IDataLoader
    {
        private readonly CatalogViewer _catalogViewer;

        public TrackLoader(CatalogViewer catalogViewer)
        {
            _catalogViewer = catalogViewer;
        }

        public void LoadData(DataGridView catalogGridView, string searchTerm)
        {
            List<Track> tracks = _catalogViewer.GetTracks(searchTerm);
            catalogGridView.DataSource = tracks;

            catalogGridView.Columns["ArtistName"].DisplayIndex = 1; // Исполнитель
            catalogGridView.Columns["AlbumName"].DisplayIndex = 2; // Альбом
            catalogGridView.Columns["Title"].DisplayIndex = 3; // Трек
            catalogGridView.Columns["Duration"].DisplayIndex = 4; // Продолжительность

            catalogGridView.Columns["ArtistId"].HeaderText = "Artist ID";
            catalogGridView.Columns["ArtistName"].HeaderText = "Исполнитель";
            catalogGridView.Columns["AlbumId"].HeaderText = "Album ID";
            catalogGridView.Columns["AlbumName"].HeaderText = "Альбом";
            catalogGridView.Columns["Id"].HeaderText = "Track ID";
            catalogGridView.Columns["Title"].HeaderText = "Трек";
            catalogGridView.Columns["Duration"].HeaderText = "Длина трека";

            catalogGridView.Columns["Id"].Visible = false;
            catalogGridView.Columns["ArtistId"].Visible = false;
            catalogGridView.Columns["AlbumId"].Visible = false;
            catalogGridView.Columns["CollectionId"].Visible = false;
            catalogGridView.Columns["CollectionTitle"].Visible = false;
            catalogGridView.Columns["GenreId"].Visible = false;
            catalogGridView.Columns["GenreName"].Visible = false;
        }

        public void LoadTracksIntoCheckedListBox(CheckedListBox trackCheckedListBox)
        {
            try
            {
                List<Track> tracks = _catalogViewer.GetTracks(); // Получаем все треки через каталог

                trackCheckedListBox.Items.Clear();

                foreach (var track in tracks)
                {
                    trackCheckedListBox.Items.Add(new TrackCheckedListItem(track.Id, track.Title));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке треков: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    public class TrackCheckedListItem
    {
        public int Id { get; }
        public string Name { get; }

        public TrackCheckedListItem(int id, string name)
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
