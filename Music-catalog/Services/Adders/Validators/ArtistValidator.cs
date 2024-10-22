using System;

namespace Music_catalog.Services
{
    public class ArtistValidator
    {
        public void Validate(string artistName)
        {
            if (string.IsNullOrWhiteSpace(artistName))
            {
                throw new ArgumentException("Имя артиста не может быть пустым или содержать только пробелы.");
            }

            if (artistName.Length < 3)
            {
                throw new ArgumentException("Имя артиста должно содержать не менее 3 символов.");
            }
        }
    }
}
