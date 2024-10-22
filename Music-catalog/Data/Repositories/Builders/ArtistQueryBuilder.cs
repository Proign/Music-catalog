using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;

public class ArtistQueryBuilder
{
    private readonly StringBuilder _query;
    private readonly List<SqliteParameter> _parameters;
    private int _parameterCounter;

    public ArtistQueryBuilder()
    {
        _query = new StringBuilder(@"
            SELECT Artists.id, Artists.name, Genres.id AS genreId, Genres.name AS genreName 
            FROM Artists 
            LEFT JOIN Genres ON Artists.genre_id = Genres.id 
            LEFT JOIN Albums ON Artists.id = Albums.artist_id");

        _parameters = new List<SqliteParameter>();
        _parameterCounter = 0; 
    }

    public ArtistQueryBuilder Where(string condition, string value)
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
