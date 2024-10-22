using Music_catalog.Repositories;
using System.Windows.Forms;

namespace Music_catalog.Services
{
    public class DataDeleter
    {
        public void DeleteItem(DataGridView dataGridView, ArtistRepository artistRepository)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var rowIndex = dataGridView.SelectedRows[0].Index;
                var artistId = (int)dataGridView.Rows[rowIndex].Cells["Id"].Value;

                artistRepository.Delete(artistId);

                MessageBox.Show("Исполнитель удалён", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void DeleteItem(DataGridView dataGridView, AlbumRepository albumRepository)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var rowIndex = dataGridView.SelectedRows[0].Index;
                var albumId = (int)dataGridView.Rows[rowIndex].Cells["Id"].Value;

                albumRepository.Delete(albumId);

                MessageBox.Show("Альбом удалён", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void DeleteItem(DataGridView dataGridView, CollectionRepository collectionRepository)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var rowIndex = dataGridView.SelectedRows[0].Index;
                var collectionId = (int)dataGridView.Rows[rowIndex].Cells["Id"].Value; 

                collectionRepository.Delete(collectionId);

                MessageBox.Show("Сборник удалён", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void DeleteItem(DataGridView dataGridView, TrackRepository trackRepository)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var rowIndex = dataGridView.SelectedRows[0].Index;
                var trackId = (int)dataGridView.Rows[rowIndex].Cells["Id"].Value; 

                trackRepository.Delete(trackId);

                MessageBox.Show("Трек удалён", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void DeleteItem(DataGridView dataGridView, GenreRepository genreRepository)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var rowIndex = dataGridView.SelectedRows[0].Index;
                var genreId = (int)dataGridView.Rows[rowIndex].Cells["Id"].Value;

                genreRepository.Delete(genreId);

                MessageBox.Show("Жанр удалён", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
