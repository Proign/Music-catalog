namespace Music_catalog.Models
{
    public class Album
    {
        public int Id { get; set; }        
        public string Title { get; set; }   
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }

    }
}
