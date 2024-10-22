namespace Music_catalog.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public string CollectionTitle { get; set; }
        public int? CollectionId { get; set; }
        public int Duration { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }

    }
}
