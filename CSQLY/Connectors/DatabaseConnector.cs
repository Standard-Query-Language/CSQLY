using System.Collections;
using CSQLY.Errors;

namespace CSQLY.Connectors;

/// <summary>
/// A class that manages connections to various database types and executes CSQLY queries.
/// </summary>
public class DatabaseConnector
{
    private readonly string _dbType;
    private readonly object _connection;

    /// <summary>
    /// Gets or sets the connector instance used to execute database operations.
    /// </summary>
    public BaseDBConnector? Connector { get; set; }

    /// <summary>
    /// Initialize the DatabaseConnector with the database type and connection information.
    /// </summary>
    /// <param name="dbType">The type of database (e.g., "sqlite", "mariadb", "postgres", "oracle", "mssql")</param>
    /// <param name="connection">The connection object or parameters required to establish the database connection</param>
    public DatabaseConnector(string dbType, object connection)
    {
        _dbType = dbType;
        _connection = connection;
    }

    /// <summary>
    /// Create a new DatabaseConnector instance.
    /// </summary>
    /// <param name="dbType">The database type enum</param>
    /// <param name="connectionString">Connection string for the database</param>
    /// <returns>A new DatabaseConnector instance</returns>
    public static DatabaseConnector Create(DatabaseType dbType, string connectionString)
    {
        return new DatabaseConnector(dbType.ToString().ToLower(), connectionString);
    }

    /// <summary>
    /// Ensure that a connector instance exists, creating it if necessary.
    /// </summary>
    /// <returns>The database connector instance.</returns>
    private BaseDBConnector EnsureConnector()
    {
        if (Connector == null)
        {
            Connector = CreateConnector(_dbType, _connection);
        }
        return Connector;
    }

    /// <summary>
    /// Create and return a database connector instance based on the database type.
    /// </summary>
    /// <param name="dbType">The type of the database</param>
    /// <param name="connection">The connection object or parameters</param>
    /// <returns>An instance of the corresponding database connector class</returns>
    /// <exception cref="SQLYExecutionError">If the specified database type is not supported</exception>
    private static BaseDBConnector CreateConnector(string dbType, object connection)
    {
        return dbType.ToLower() switch
        {
            "sqlite" => new SQLiteConnector(connection),
            "mariadb" or "mysql" => new MariaDBConnector(connection),
            "postgres" or "postgresql" => new PostgresConnector(connection),
            "oracle" => new OracleConnector(connection),
            "mssql" or "sqlserver" => new MSSQLConnector(connection),
            _ => throw new SQLYExecutionError($"Unsupported database type: {dbType}"),
        };
    }

    /// <summary>
    /// Execute a CSQLY query against a specified database.
    /// </summary>
    /// <param name="query">The query dictionary</param>
    /// <returns>The result of the executed query</returns>
    public object ExecuteQuery(IDictionary query)
    {
        var connector = EnsureConnector();
        return connector.ExecuteQuery(query);
    }

    /// <summary>
    /// Execute a CSQLY query asynchronously.
    /// </summary>
    /// <param name="yamlQuery">The query in YAML format</param>
    /// <returns>The result of the executed query</returns>
    public async Task<object> ExecuteQueryAsync(string yamlQuery)
    {
        // This is a placeholder implementation
        // In a real implementation, this would parse the YAML query and execute it asynchronously
        return await Task.FromResult(new object());
    }
}

/// <summary>
/// Enumeration of supported database types.
/// </summary>
public enum DatabaseType
{
    /// <summary>SQLite database.</summary>
    SQLite,
    /// <summary>MySQL/MariaDB database.</summary>
    MariaDB,
    /// <summary>PostgreSQL database.</summary>
    PostgreSQL,
    /// <summary>Oracle database.</summary>
    Oracle,
    /// <summary>Microsoft SQL Server database.</summary>
    SQLServer
}
