using Microsoft.Data.Sqlite;

public class TrackQueryBuilder
{
    private readonly string _query;

    public TrackQueryBuilder()
    {
        _query = "SELECT * FROM Tracks";
    }

    public string Build()
    {
        return _query;
    }
}