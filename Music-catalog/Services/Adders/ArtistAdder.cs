using System;
using System.Windows.Forms;
using Music_catalog.Repositories;
using Music_catalog.Services;

namespace Music_catalog.Services
{
    public class ArtistAdder
    {
        private readonly IArtistRepository _artistRepository;
        private readonly ArtistValidator _artistValidator;

        public ArtistAdder(IArtistRepository artistRepository, ArtistValidator artistValidator)
        {
            _artistRepository = artistRepository;
            _artistValidator = artistValidator;
        }

        // Метод для добавления артиста
        public int AddArtist(string artistName, int genreId, TextBox artistTextBox)
        {
            try
            {
                artistName = artistName.Trim();

                _artistValidator.Validate(artistName);

                int artistId = _artistRepository.AddArtist(artistName, genreId);

                MessageBox.Show($"Исполнитель '{artistName}' успешно добавлен с ID {artistId}.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                artistTextBox.Clear();

                return artistId; // Возвращаем ID добавленного артиста
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // Возвращаем -1 или другое значение для обработки ошибки
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении артиста: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // Возвращаем -1 или другое значение для обработки ошибки
            }
        }
    }
}
