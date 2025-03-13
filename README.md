# CSQLY - SQL with YAML

CSQLY is a simplified query language for multiple databases that allows you to write database queries in YAML format and execute them against different database engines.

## Features

- Write database queries in easy-to-read YAML format
- Support for multiple database types (SQLite, MySQL/MariaDB, PostgreSQL, Oracle, MS SQL Server)
- Simplified query syntax
- Connection pooling and management
- Easily extensible architecture

## Installation

Install the CSQLY package from NuGet:

```bash
dotnet add package CSQLY
```

## Basic Usage

```csharp
using CSQLY;
using CSQLY.Connectors;

// Create a database connection
var connector = DatabaseConnector.Create(DatabaseType.SQLite, "Data Source=mydb.sqlite");

// Execute a CSQLY query
var result = await connector.ExecuteQueryAsync(@"
select:
  columns:
    - name
    - email
  from: users
  where:
    active: true
");

// Process results
foreach (var row in result)
{
    Console.WriteLine($"Name: {row["name"]}, Email: {row["email"]}");
}
```

## Documentation

For detailed documentation, visit [our wiki](https://github.com/Standard-Query-Language/CSQLY/wiki).

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details.
