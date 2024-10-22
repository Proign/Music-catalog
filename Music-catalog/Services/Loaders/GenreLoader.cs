using System;
using System.Windows.Forms;
using Music_catalog.Models;
using Music_catalog.Repositories;

namespace Music_catalog.Services
{
    public class GenreLoader : IDataLoader
    {
        private readonly IGenreRepository _genreRepository;

        public GenreLoader(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public void LoadData(DataGridView genreGridView, string searchTerm)
        {
            List<Genre> genreData = _genreRepository.GetAllGenres();

            // Если указан поисковый запрос, фильтруем данные по названию жанра
            if (!string.IsNullOrEmpty(searchTerm))
            {
                genreData = genreData.FindAll(g => g.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            genreGridView.DataSource = genreData;

            // Настройка отображаемых столбцов
            genreGridView.Columns["Name"].HeaderText = "Жанр";
            genreGridView.Columns["Id"].Visible = false; // Скрываем столбец с ID
        }

        public void LoadGenresIntoComboBox(ComboBox genreComboBox)
        {
            try
            {
                var genres = _genreRepository.GetAllGenres();  // Получаем жанры через репозиторий

                genreComboBox.Items.Clear();

                foreach (var genre in genres)
                {
                    genreComboBox.Items.Add(new GenreComboBoxItem(genre.Id, genre.Name));
                }

                if (genres.Count > 0)
                {
                    genreComboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке жанров: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class GenreComboBoxItem
    {
        public int Id { get; }
        public string Name { get; }

        public GenreComboBoxItem(int id, string name)
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
