using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Music_catalog.Models;
using Music_catalog.Repositories;

namespace Music_catalog.Services
{
    public class AlbumLoader : IDataLoader
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumLoader(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public void LoadData(DataGridView albumGridView, string searchTerm)
        {
            try
            {
                List<Album> albumData = _albumRepository.GetAlbums(searchTerm);
                albumGridView.DataSource = albumData;

                albumGridView.Columns["Title"].HeaderText = "Название";
                albumGridView.Columns["ArtistName"].HeaderText = "Исполнитель";
                albumGridView.Columns["GenreName"].HeaderText = "Жанр";

                albumGridView.Columns["Id"].Visible = false;
                albumGridView.Columns["ArtistId"].Visible = false;
                albumGridView.Columns["GenreId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке альбомов в таблицу: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadAlbumsIntoComboBox(ComboBox albumComboBox)
        {
            try
            {
                List<Album> albums = _albumRepository.GetAlbums(); 

                albumComboBox.Items.Clear();

                foreach (var album in albums)
                {
                    albumComboBox.Items.Add(new AlbumComboBoxItem(album.Id, $"{album.Title} - {album.ArtistName}"));
                }

                if (albums.Count > 0)
                {
                    albumComboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке альбомов в комбобокс: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class AlbumComboBoxItem
    {
        public int Id { get; }
        public string Name { get; }

        public AlbumComboBoxItem(int id, string name)
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
