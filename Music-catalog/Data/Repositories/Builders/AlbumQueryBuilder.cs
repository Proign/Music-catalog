using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;

public class AlbumQueryBuilder
{
    private readonly StringBuilder _query;
    private readonly List<SqliteParameter> _parameters;
    private int _parameterCounter;

    public AlbumQueryBuilder()
    {
        _query = new StringBuilder(@"
            SELECT 
                Albums.id AS albumId, 
                Albums.name AS albumName, 
                Artists.id AS artistId, 
                Artists.name AS artistName, 
                Genres.id AS genreId, 
                Genres.name AS genreName
            FROM Albums 
            LEFT JOIN Artists ON Albums.artist_id = Artists.id 
            LEFT JOIN Genres ON Albums.genre_id = Genres.id");

        _parameters = new List<SqliteParameter>();
        _parameterCounter = 0;
    }

    public AlbumQueryBuilder Where(string condition, string value)
    {
        var parameterName = $"@param{_parameterCounter++}";

        if (_parameters.Count == 0)
        {
            _query.Append(" WHERE ");
        }
        else
        {
            _query.Append(" OR ");
        }

        _query.Append(condition.Replace("@searchTerm", parameterName));
        _parameters.Add(new SqliteParameter(parameterName, $"%{value}%"));
        return this;
    }

    public (string Query, SqliteParameter[] Parameters) Build()
    {
        return (_query.ToString(), _parameters.ToArray());
    }
}
