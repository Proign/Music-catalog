namespace Music_catalog.Services
{
    public class GenreValidator
    {
        public void Validate(string genreName)
        {
            if (string.IsNullOrWhiteSpace(genreName))
            {
                throw new ArgumentException("Пожалуйста, введите название жанра.");
            }
        }
    }
}