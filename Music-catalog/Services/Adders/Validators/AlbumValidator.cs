using System;

namespace Music_catalog.Services
{
    public class AlbumValidator
    {
        public void Validate(string albumName)
        {
            if (string.IsNullOrWhiteSpace(albumName))
            {
                throw new ArgumentException("Название альбома не может быть пустым или содержать только пробелы.");
            }

            if (albumName.Length < 3)
            {
                throw new ArgumentException("Название альбома должно содержать не менее 3 символов.");
            }
        }
    }
}