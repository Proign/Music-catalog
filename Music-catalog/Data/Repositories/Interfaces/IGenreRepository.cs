using System.Collections.Generic;
using Music_catalog.Models;

namespace Music_catalog.Repositories
{
    public interface IGenreRepository
    {
        int AddGenre(string genreName);
        int GetGenreIdByName(string genreName);
        List<Genre> GetAllGenres();
    }
}