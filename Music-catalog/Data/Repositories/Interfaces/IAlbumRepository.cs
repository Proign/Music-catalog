using Music_catalog.Models;
using System.Collections.Generic;

namespace Music_catalog.Repositories
{
    public interface IAlbumRepository
    {
        int AddAlbum(string albumName, int artistId, int genreId);
        List<Album> GetAlbums(string searchTerm = "");
        int GetAlbumIdByName(string albumName);
    }
}