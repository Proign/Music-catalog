using System;
using System.Windows.Forms;
using Music_catalog.Repositories;
using Music_catalog.Services;
using Music_catalog.UI;

namespace Music_catalog.Services
{
    public class TrackAdder
    {
        private readonly ITrackRepository _trackRepository;
        private readonly TrackValidator _trackValidator;

        public TrackAdder(ITrackRepository trackRepository, TrackValidator trackValidator)
        {
            _trackRepository = trackRepository;
            _trackValidator = trackValidator;
        }

        // Метод для добавления трека
        public void AddTrack(string trackTitle, int artistId, int albumId, int duration, TextBox trackTextBox, TextBox trackDurationTextBox, int? collectionId = null)
        {
            try
            {
                trackTitle = trackTitle.Trim();

                _trackValidator.Validate(trackTitle, duration);

                _trackRepository.AddTrack(trackTitle, artistId, albumId, duration, collectionId);

                MessageBox.Show($"Трек '{trackTitle}' успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                trackTextBox.Clear();
                trackDurationTextBox.Clear();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении трека: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}