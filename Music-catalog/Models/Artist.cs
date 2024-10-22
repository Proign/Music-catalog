namespace Music_catalog.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public string Genre { get; set; }
    }
}