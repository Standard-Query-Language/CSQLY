using System.Collections;

namespace CSQLY.Connectors;

/// <summary>
/// Interface for database connectors.
/// </summary>
public interface IDBConnector
{
    /// <summary>
    /// Execute a SQL query constructed from the given dictionary.
    /// </summary>
    /// <param name="query">A dictionary representing the query to be executed.</param>
    /// <returns>The result of the executed query.</returns>
    object ExecuteQuery(IDictionary query);

    /// <summary>
    /// Execute a given SQL statement with the provided parameters.
    /// </summary>
    /// <param name="sql">The SQL statement to be executed.</param>
    /// <param name="parameters">The parameters to be used with the SQL statement.</param>
    /// <returns>The result of the executed query.</returns>
    object Execute(string sql, IList<object> parameters);

    /// <summary>
    /// Get the database type for this connector.
    /// </summary>
    /// <returns>String representing the database type.</returns>
    string GetDbType();
}
