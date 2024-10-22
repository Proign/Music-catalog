using System;
using System.Windows.Forms;
using Music_catalog.Repositories;
using Music_catalog.Services;
using Music_catalog.UI;

namespace Music_catalog.Services
{
    public class AlbumAdder
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly AlbumValidator _albumValidator;

        public AlbumAdder(IAlbumRepository albumRepository, AlbumValidator albumValidator)
        {
            _albumRepository = albumRepository;
            _albumValidator = albumValidator;
        }

        // Метод для добавления альбома
        public void AddAlbum(string albumName, int artistId, int genreId, TextBox albumTextBox)
        {
            try
            {
                albumName = albumName.Trim();

                _albumValidator.Validate(albumName);

                int albumId = _albumRepository.AddAlbum(albumName, artistId, genreId);

                MessageBox.Show($"Альбом '{albumName}' успешно добавлен с ID {albumId}.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                albumTextBox.Clear();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении альбома: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}