using System.Collections;
using System.Data;
using System.Data.Common;
using CSQLY.Core;
using CSQLY.Errors;

namespace CSQLY.Connectors;

/// <summary>
/// A base class for database connectors that provides methods to execute SQL queries.
/// </summary>
public abstract class BaseDBConnector : IDBConnector
{
    /// <summary>
    /// The database connection object used by the connector.
    /// </summary>
    protected readonly object Connection;

    /// <summary>
    /// Initialize the BaseDBConnector with a database connection.
    /// </summary>
    /// <param name="connection">The database connection object.</param>
    protected BaseDBConnector(object connection)
    {
        Connection = connection;
    }

    /// <summary>
    /// Execute a SQL query constructed from the given dictionary.
    /// </summary>
    /// <param name="query">A dictionary representing the query to be executed.</param>
    /// <returns>The result of the executed query.</returns>
    public object ExecuteQuery(IDictionary query)
    {
        var (sql, parameters) = SQLYUtils.TranslateToSql(query, GetDbType());
        return Execute(sql, parameters);
    }

    /// <summary>
    /// Get the database type for this connector.
    /// </summary>
    /// <returns>String representing the database type</returns>
    public virtual string GetDbType()
    {
        var className = GetType().Name.ToLower();

        if (className.Contains("sqlite")) return "sqlite";
        if (className.Contains("mariadb") || className.Contains("mysql")) return "mariadb";
        if (className.Contains("postgres")) return "postgres";
        if (className.Contains("oracle")) return "oracle";
        if (className.Contains("mssql") || className.Contains("sqlserver")) return "mssql";

        throw new InvalidOperationException($"Unknown database type for {className}");
    }

    /// <summary>
    /// Execute a given SQL statement with the provided parameters.
    /// </summary>
    /// <param name="sql">The SQL statement to be executed.</param>
    /// <param name="parameters">The parameters to be used with the SQL statement.</param>
    /// <returns>If the SQL statement is a SELECT query, returns the fetched results. Otherwise returns a success message.</returns>
    public abstract object Execute(string sql, IList<object> parameters);

    /// <summary>
    /// Helper method to convert a DbDataReader to a list of object arrays.
    /// </summary>
    protected static IList<object[]> ConvertDataReaderToObjectList(DbDataReader reader)
    {
        var result = new List<object[]>();
        int fieldCount = reader.FieldCount;

        while (reader.Read())
        {
            var row = new object[fieldCount];
            reader.GetValues(row);
            result.Add(row);
        }

        return result;
    }
}
