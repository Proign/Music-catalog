using System.Collections.Generic;
using Microsoft.Data.Sqlite;

public class ViewerQueryBuilder
{
    private readonly List<string> _conditions;
    private readonly string _baseQuery;

    public ViewerQueryBuilder()
    {
        _baseQuery = @"
            SELECT 
                Tracks.id, 
                Tracks.title, 
                Artists.id AS artistId, 
                Artists.name AS artistName, 
                Albums.id AS albumId, 
                Albums.name AS albumName, 
                Tracks.duration, 
                Collections.id AS collectionId, 
                Collections.title AS collectionTitle,
                Albums.genre_id AS genreId,
                Genres.name AS genreName
            FROM Tracks 
            LEFT JOIN Artists ON Tracks.artist_id = Artists.id 
            LEFT JOIN Albums ON Tracks.album_id = Albums.id
            LEFT JOIN Collections ON Tracks.collection_id = Collections.id
            LEFT JOIN Genres ON Albums.genre_id = Genres.id";

        _conditions = new List<string>();
    }

    public ViewerQueryBuilder WhereLike(string searchTerm)
    {
        if (!string.IsNullOrEmpty(searchTerm))
        {
            _conditions.Add("(Tracks.title LIKE @searchTerm " +
                            "OR Artists.name LIKE @searchTerm " +
                            "OR Albums.name LIKE @searchTerm " +
                            "OR Collections.title LIKE @searchTerm " +
                            "OR Genres.name LIKE @searchTerm)");
        }
        return this;
    }

    public string Build(out SqliteParameter[] parameters, string searchTerm)
    {
        string query = _baseQuery;

        // Добавляем условия, если они есть
        if (_conditions.Count > 0)
        {
            query += " WHERE " + string.Join(" OR ", _conditions);
        }

        // Подготовка параметров
        parameters = new[]
        {
            new SqliteParameter("@searchTerm", $"%{searchTerm}%")
        };

        return query;
    }
}