# Database Connectors

CSQLY provides connectors for various database systems. Each connector handles the specific requirements of its database type while providing a unified interface for executing queries.

## Supported Database Types

CSQLY currently supports these databases:

1. SQLite
2. MySQL/MariaDB
3. PostgreSQL
4. Microsoft SQL Server
5. Oracle

## Creating Database Connections

You can create a database connection using the `DatabaseConnector` factory:

```csharp
using CSQLY.Connectors;

// Create a connector with enum
var connector = DatabaseConnector.Create(DatabaseType.SQLite, "Data Source=mydb.sqlite");

// Or with a string type name
var connector = new DatabaseConnector("sqlite", "Data Source=mydb.sqlite");
```

## Connection String Examples

### SQLite

```csharp
// Basic connection
"Data Source=mydb.sqlite"

// In-memory database
"Data Source=:memory:"

// With password
"Data Source=mydb.sqlite;Password=myPassword;"
```

### MySQL/MariaDB

```csharp
// Basic connection
"Server=localhost;Database=mydb;User ID=user;Password=password;"

// With specific port
"Server=localhost;Port=3307;Database=mydb;User ID=user;Password=password;"

// With SSL
"Server=localhost;Database=mydb;User ID=user;Password=password;SslMode=Required;"
```

### PostgreSQL

```csharp
// Basic connection
"Host=localhost;Database=mydb;Username=user;Password=password;"

// With specific port
"Host=localhost;Port=5433;Database=mydb;Username=user;Password=password;"

// With SSL
"Host=localhost;Database=mydb;Username=user;Password=password;SSL Mode=Require;"
```

### SQL Server

```csharp
// Using SQL authentication
"Server=localhost;Database=mydb;User ID=user;Password=password;"

// Using Windows authentication
"Server=localhost;Database=mydb;Integrated Security=True;"

// Express instance
"Server=localhost\\SQLEXPRESS;Database=mydb;User ID=user;Password=password;"
```

### Oracle

```csharp
// Basic connection
"Data Source=MyOracleDB;User Id=user;Password=password;"

// TNS name
"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=MyHost)(PORT=MyPort))(CONNECT_DATA=(SERVICE_NAME=MyService)));User Id=user;Password=password;"
```

## Advanced Connector Features

### Custom Configuration

You can customize connectors by extending the base connector classes:

```csharp
public class CustomSQLiteConnector : SQLiteConnector
{
    public CustomSQLiteConnector(object connectionString) : base(connectionString)
    {
        // Custom initialization
    }

    public override object Execute(string sql, IList<object> parameters)
    {
        // Custom execution logic
        Console.WriteLine($"Executing: {sql}");
        return base.Execute(sql, parameters);
    }
}

// Using your custom connector
var customConnector = new DatabaseConnector("sqlite", "Data Source=mydb.sqlite")
{
    Connector = new CustomSQLiteConnector("Data Source=mydb.sqlite")
};
```

### Connection Pooling

CSQLY leverages the built-in connection pooling of the underlying ADO.NET providers. No special configuration is required, but you can adjust pooling behavior through connection string parameters:

```csharp
// SQL Server with custom pooling settings
"Server=localhost;Database=mydb;User ID=user;Password=password;Min Pool Size=5;Max Pool Size=100;Connection Timeout=30;"
```

### Async Operations

All connectors support asynchronous operations:

```csharp
// Execute a query asynchronously
var result = await connector.ExecuteQueryAsync(yamlQuery);
```

### Transactions

Transaction support will be added in a future release.

## Extending CSQLY with New Connectors

To add support for a new database system, follow these steps:

1. Create a new connector class that extends `BaseDBConnector`:

```csharp
public class MyDatabaseConnector : BaseDBConnector
{
    public MyDatabaseConnector(object connectionString) : base(connectionString)
    {
        // Initialize your database-specific connection
    }

    public override object Execute(string sql, IList<object> parameters)
    {
        // Implement execution logic for your database
        // Return query results in a format compatible with CSQLY
    }

    public override string GetDbType()
    {
        return "mydatabase";
    }
}
```

2. Register your connector in the `CreateConnector` method of the `DatabaseConnector` class.

3. Implement any database-specific query translation logic if needed.

## Performance Considerations

- Connection pooling is used by default for optimal performance
- Consider using parameterized queries to avoid SQL injection and improve query plan caching
- For large result sets, use streaming capabilities (to be added in a future release)
- Monitor connection usage to avoid connection leaks
