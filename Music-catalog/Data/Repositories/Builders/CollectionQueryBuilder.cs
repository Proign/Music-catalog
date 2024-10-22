using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;

public class CollectionQueryBuilder
{
    private readonly StringBuilder _query;
    private readonly List<SqliteParameter> _parameters;

    public CollectionQueryBuilder()
    {
        _query = new StringBuilder("SELECT id AS collectionId, title AS collectionTitle FROM Collections");
        _parameters = new List<SqliteParameter>();
    }

    public CollectionQueryBuilder WhereTitleLike(string searchTerm)
    {
        if (!string.IsNullOrEmpty(searchTerm))
        {
            _query.Append(" WHERE title LIKE @searchTerm");
            _parameters.Add(new SqliteParameter("@searchTerm", $"%{searchTerm}%"));
        }
        return this;
    }

    public (string Query, SqliteParameter[] Parameters) Build()
    {
        return (_query.ToString(), _parameters.ToArray());
    }
}
