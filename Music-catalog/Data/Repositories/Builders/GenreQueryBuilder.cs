using Microsoft.Data.Sqlite;

public class GenreQueryBuilder
{
    private readonly string _query;

    public GenreQueryBuilder()
    {
        _query = "SELECT id, name FROM Genres";
    }

    public string Build()
    {
        return _query;
    }
}