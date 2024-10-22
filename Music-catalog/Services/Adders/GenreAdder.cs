using System;
using System.Windows.Forms;
using Music_catalog.Repositories;
using Music_catalog.Services;
using Music_catalog.UI;

namespace Music_catalog.Services
{
    public class GenreAdder
    {
        private readonly IGenreRepository _genreRepository;
        private readonly GenreValidator _genreValidator;

        public GenreAdder(IGenreRepository genreRepository, GenreValidator genreValidator)
        {
            _genreRepository = genreRepository;
            _genreValidator = genreValidator;
        }

        // Метод для добавления жанра
        public void AddGenre(string genreName, TextBox genreTextBox)
        {
            try
            {
                genreName = genreName.Trim();

                _genreValidator.Validate(genreName);

                int genreId = _genreRepository.AddGenre(genreName);

                MessageBox.Show($"Жанр '{genreName}' успешно добавлен с ID {genreId}.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                genreTextBox.Clear();
            }
            catch (ArgumentException ex)
            {
                // Ловим ошибки валидации и показываем пользователю
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Ловим все остальные ошибки
                MessageBox.Show($"Ошибка при добавлении жанра: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}