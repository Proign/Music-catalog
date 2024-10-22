using Music_catalog.Models;
using System.Collections.Generic;

namespace Music_catalog.Repositories
{
    public interface IArtistRepository
    {
        List<Artist> GetArtists(string searchTerm = "");
        int AddArtist(string artistName, int genreId);
        int GetArtistIdByName(string artistName);
    }
}