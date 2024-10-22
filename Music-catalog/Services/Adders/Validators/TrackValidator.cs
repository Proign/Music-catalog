using System;

namespace Music_catalog.Services
{
    public class TrackValidator
    {
        // Метод для проверки корректности данных трека
        public void Validate(string trackTitle, int duration)
        {
            // Проверяем, что название трека не пустое или не состоит только из пробелов
            if (string.IsNullOrWhiteSpace(trackTitle))
            {
                throw new ArgumentException("Название трека не может быть пустым или содержать только пробелы.");
            }

            // Проверяем минимальную длину названия трека
            if (trackTitle.Length < 3)
            {
                throw new ArgumentException("Название трека должно содержать не менее 3 символов.");
            }

            // Проверяем, что продолжительность трека больше нуля
            if (duration <= 0)
            {
                throw new ArgumentException("Продолжительность трека должна быть больше нуля.");
            }
        }
    }
}