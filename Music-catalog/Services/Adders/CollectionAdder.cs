using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Music_catalog.Repositories;
using Music_catalog.Services;

namespace Music_catalog.Services
{
    public class CollectionAdder
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly CollectionValidator _collectionValidator;

        public CollectionAdder(ICollectionRepository collectionRepository, CollectionValidator collectionValidator)
        {
            _collectionRepository = collectionRepository;
            _collectionValidator = collectionValidator;
        }

        // Метод для добавления коллекции
        public int AddCollection(string collectionTitle, List<int> trackIds)
        {
            try
            {
                collectionTitle = collectionTitle.Trim();

                _collectionValidator.Validate(collectionTitle);

                _collectionValidator.ValidateTracks(trackIds);

                int collectionId = _collectionRepository.AddCollection(collectionTitle);

                foreach (var trackId in trackIds)
                {
                    _collectionRepository.UpdateTrackCollection(trackId, collectionId);
                }

                MessageBox.Show("Коллекция успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return collectionId; // Возвращаем ID добавленной коллекции
            }
            catch (Exception ex)
            {
                // Ловим все ошибки и показываем пользователю
                MessageBox.Show($"Ошибка при добавлении коллекции: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // Возвращаем -1 для обработки ошибки
            }
        }
    }
}