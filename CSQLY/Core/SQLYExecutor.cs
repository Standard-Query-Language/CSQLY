using System.Collections;
using CSQLY.Connectors;
using CSQLY.Errors;

namespace CSQLY.Core;

/// <summary>
/// Executes CSQLY queries against the specified database.
/// </summary>
public class SQLYExecutor
{
    private readonly DatabaseConnector _connector;

    /// <summary>
    /// Creates a new instance of the SQLYExecutor class.
    /// </summary>
    /// <param name="connector">The database connector to use.</param>
    public SQLYExecutor(DatabaseConnector connector)
    {
        _connector = connector ?? throw new ArgumentNullException(nameof(connector));
    }

    /// <summary>
    /// Executes a CSQLY query in YAML format.
    /// </summary>
    /// <param name="yamlQuery">The query in YAML format.</param>
    /// <returns>The result of the executed query.</returns>
    /// <exception cref="SQLYExecutionError">Thrown when the query cannot be executed.</exception>
    public object ExecuteYamlQuery(string yamlQuery)
    {
        try
        {
            IDictionary queryDict = SQLYUtils.ParseYaml(yamlQuery);
            return ExecuteQueryDict(queryDict);
        }
        catch (SQLYParseError ex)
        {
            throw new SQLYExecutionError("Failed to parse YAML query", ex);
        }
        catch (Exception ex) when (!(ex is SQLYError))
        {
            throw new SQLYExecutionError($"Unexpected error executing query: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Executes a CSQLY query from a dictionary structure.
    /// </summary>
    /// <param name="query">The query as a dictionary.</param>
    /// <returns>The result of the executed query.</returns>
    /// <exception cref="SQLYExecutionError">Thrown when the query cannot be executed.</exception>
    public object ExecuteQueryDict(IDictionary query)
    {
        try
        {
            return _connector.ExecuteQuery(query);
        }
        catch (SQLYConnectorError ex)
        {
            throw new SQLYExecutionError("Database connector error", ex);
        }
        catch (Exception ex) when (!(ex is SQLYError))
        {
            throw new SQLYExecutionError($"Unexpected error executing query: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Executes a CSQLY query asynchronously.
    /// </summary>
    /// <param name="yamlQuery">The query in YAML format.</param>
    /// <returns>A task representing the asynchronous operation with the query result.</returns>
    public async Task<object> ExecuteYamlQueryAsync(string yamlQuery)
    {
        // This is a placeholder for a real async implementation
        return await Task.FromResult(ExecuteYamlQuery(yamlQuery));
    }
}
