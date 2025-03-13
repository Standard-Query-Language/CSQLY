# Getting Started with CSQLY

This guide will help you get started with CSQLY in your .NET application.

## Installation

### Package Manager Console

```powershell
Install-Package CSQLY
```

### .NET CLI

```bash
dotnet add package CSQLY
```

## Basic Usage

### Setting Up a Database Connection

```csharp
using CSQLY.Core;
using CSQLY.Connectors;

// For SQLite:
var sqliteConnector = DatabaseConnector.Create(DatabaseType.SQLite, "Data Source=mydb.sqlite");

// For MySQL/MariaDB:
var mysqlConnector = DatabaseConnector.Create(
    DatabaseType.MariaDB,
    "Server=localhost;Database=mydb;User ID=user;Password=password;"
);

// For PostgreSQL:
var postgresConnector = DatabaseConnector.Create(
    DatabaseType.PostgreSQL,
    "Host=localhost;Database=mydb;Username=user;Password=password;"
);

// For SQL Server:
var sqlServerConnector = DatabaseConnector.Create(
    DatabaseType.SQLServer,
    "Server=localhost;Database=mydb;User ID=user;Password=password;Integrated Security=True;"
);

// For Oracle:
var oracleConnector = DatabaseConnector.Create(
    DatabaseType.Oracle,
    "Data Source=MyOracleDB;User Id=user;Password=password;"
);
```

### Executing a Simple Query

```csharp
// YAML query string
var yamlQuery = @"
select:
  columns:
    - id
    - name
    - email
  from: users
  where:
    active: true
    role: Admin
  orderBy:
    - field: name
      direction: asc
  limit: 10
";

// Parse the YAML and execute the query
var result = connector.ExecuteQuery(SQLYUtils.ParseYaml(yamlQuery));

// Process results
foreach (var row in result)
{
    Console.WriteLine($"ID: {row["id"]}, Name: {row["name"]}, Email: {row["email"]}");
}
```

### Using the SQLYExecutor

For more control over execution:

```csharp
// Create an executor
var executor = new SQLYExecutor(connector);

// Execute a YAML query
var result = executor.ExecuteYamlQuery(yamlQuery);

// Or execute asynchronously
var asyncResult = await executor.ExecuteYamlQueryAsync(yamlQuery);
```

### Error Handling

```csharp
try
{
    var result = executor.ExecuteYamlQuery(yamlQuery);
    // Process results
}
catch (SQLYParseError ex)
{
    // Handle YAML parsing errors
    Console.WriteLine($"Parse error: {ex.Message}");
}
catch (SQLYExecutionError ex)
{
    // Handle execution errors
    Console.WriteLine($"Execution error: {ex.Message}");
}
catch (SQLYConnectorError ex)
{
    // Handle database connection errors
    Console.WriteLine($"Connection error: {ex.Message}");
}
catch (SQLYError ex)
{
    // Handle other CSQLY errors
    Console.WriteLine($"CSQLY error: {ex.Message}");
}
catch (Exception ex)
{
    // Handle unexpected errors
    Console.WriteLine($"Unexpected error: {ex.Message}");
}
```

## Next Steps

- Learn more about [Query Syntax](query-syntax.md)
- See advanced features in [Database Connectors](database-connectors.md)
- Try the [CLI tool](cli-usage.md)
- Explore the [API Reference](api-reference.md)
