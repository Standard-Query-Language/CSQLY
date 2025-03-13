# API Reference

This document provides a reference for the main classes and interfaces in the CSQLY library.

## Core Classes

### SQLYUtils

Static utility methods for CSQLY operations.

```csharp
namespace CSQLY.Core;

public static class SQLYUtils
{
    // Parse YAML string into a dictionary
    public static IDictionary ParseYaml(string yaml);

    // Convert a query dictionary to SQL and parameters
    public static (string, IList<object>) TranslateToSql(IDictionary query, string dbType);
}
```

### SQLYParser

Handles parsing of YAML strings into query dictionaries.

```csharp
namespace CSQLY.Core;

public static class SQLYParser
{
    // Parse YAML string into a dictionary structure
    public static IDictionary Parse(string yaml);
}
```

### SQLYExecutor

Executes CSQLY queries against a specific database.

```csharp
namespace CSQLY.Core;

public class SQLYExecutor
{
    // Constructor
    public SQLYExecutor(DatabaseConnector connector);

    // Execute a YAML query string
    public object ExecuteYamlQuery(string yamlQuery);

    // Execute a query from a dictionary
    public object ExecuteQueryDict(IDictionary query);

    // Execute a YAML query asynchronously
    public Task<object> ExecuteYamlQueryAsync(string yamlQuery);
}
```

## Connector Classes

### DatabaseConnector

Primary factory and manager for database connectors.

```csharp
namespace CSQLY.Connectors;

public class DatabaseConnector
{
    // Properties
    public BaseDBConnector? Connector { get; set; }

    // Constructors
    public DatabaseConnector(string dbType, object connection);

    // Factory method
    public static DatabaseConnector Create(DatabaseType dbType, string connectionString);

    // Query execution methods
    public object ExecuteQuery(IDictionary query);
    public Task<object> ExecuteQueryAsync(string yamlQuery);
}
```

### DatabaseType Enum

Supported database types.

```csharp
namespace CSQLY.Connectors;

public enum DatabaseType
{
    SQLite,
    MariaDB,
    PostgreSQL,
    Oracle,
    SQLServer
}
```

### IDBConnector Interface

Interface for all database connectors.

```csharp
namespace CSQLY.Connectors;

public interface IDBConnector
{
    object ExecuteQuery(IDictionary query);
    object Execute(string sql, IList<object> parameters);
    string GetDbType();
}
```

### BaseDBConnector

Base class for all database connectors.

```csharp
namespace CSQLY.Connectors;

public abstract class BaseDBConnector : IDBConnector
{
    // Constructor
    protected BaseDBConnector(object connection);

    // Implemented methods
    public object ExecuteQuery(IDictionary query);
    public virtual string GetDbType();

    // Abstract methods
    public abstract object Execute(string sql, IList<object> parameters);

    // Helper methods
    protected static IList<object[]> ConvertDataReaderToObjectList(DbDataReader reader);
}
```

## Database-Specific Connectors

### SQLiteConnector

```csharp
namespace CSQLY.Connectors;

public class SQLiteConnector : BaseDBConnector
{
    public SQLiteConnector(object connectionString) : base(connectionString);
    public override object Execute(string sql, IList<object> parameters);
}
```

### MariaDBConnector

```csharp
namespace CSQLY.Connectors;

public class MariaDBConnector : BaseDBConnector
{
    public MariaDBConnector(object connectionString) : base(connectionString);
    public override object Execute(string sql, IList<object> parameters);
}
```

### PostgresConnector

```csharp
namespace CSQLY.Connectors;

public class PostgresConnector : BaseDBConnector
{
    public PostgresConnector(object connectionString) : base(connectionString);
    public override object Execute(string sql, IList<object> parameters);
}
```

### MSSQLConnector

```csharp
namespace CSQLY.Connectors;

public class MSSQLConnector : BaseDBConnector
{
    public MSSQLConnector(object connectionString) : base(connectionString);
    public override object Execute(string sql, IList<object> parameters);
}
```

### OracleConnector

```csharp
namespace CSQLY.Connectors;

public class OracleConnector : BaseDBConnector
{
    public OracleConnector(object connectionString) : base(connectionString);
    public override object Execute(string sql, IList<object> parameters);
}
```

## Error Classes

### SQLYError

Base exception class for all CSQLY errors.

```csharp
namespace CSQLY.Errors;

public class SQLYError : Exception
{
    public SQLYError();
    public SQLYError(string message);
    public SQLYError(string message, Exception innerException);
}
```

### SQLYParseError

Exception for YAML parsing errors.

```csharp
namespace CSQLY.Errors;

public class SQLYParseError : SQLYError
{
    public SQLYParseError();
    public SQLYParseError(string message);
    public SQLYParseError(string message, Exception innerException);
}
```

### SQLYExecutionError

Exception for query execution errors.

```csharp
namespace CSQLY.Errors;

public class SQLYExecutionError : SQLYError
{
    public SQLYExecutionError();
    public SQLYExecutionError(string message);
    public SQLYExecutionError(string message, Exception innerException);
}
```

### SQLYConnectorError

Exception for database connector errors.

```csharp
namespace CSQLY.Errors;

public class SQLYConnectorError : SQLYError
{
    public SQLYConnectorError();
    public SQLYConnectorError(string message);
    public SQLYConnectorError(string message, Exception innerException);
}
```

For detailed information on method parameters and return values, please refer to the XML documentation comments in the source code.
