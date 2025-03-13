# CSQLY - SQL with YAML

[![Build and Test](https://github.com/Standard-Query-Language/CSQLY/actions/workflows/build.yml/badge.svg)](https://github.com/Standard-Query-Language/CSQLY/actions/workflows/build.yml)
[![NuGet](https://img.shields.io/nuget/v/CSQLY.svg)](https://www.nuget.org/packages/CSQLY/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

CSQLY is a simplified query language for multiple databases that allows you to write database queries in YAML format and execute them against different database engines.

## Features

- Write database queries in easy-to-read YAML format
- Support for multiple database types:
  - SQLite
  - MySQL/MariaDB
  - PostgreSQL
  - Oracle
  - Microsoft SQL Server
- Simplified query syntax with type safety
- Connection pooling and management
- Easily extensible architecture
- Command-line interface for quick queries

## Installation

### Package Manager Console

```
Install-Package CSQLY
```

### .NET CLI

```bash
dotnet add package CSQLY
```

## Basic Usage

```csharp
using CSQLY.Core;
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

## Command-Line Interface

CSQLY also provides a command-line interface for quick queries:

```bash
# Install the CLI tool
dotnet tool install --global CSQLY.CLI

# Execute a query from a file
csqly -f query.yaml -c "Data Source=mydb.sqlite" -t sqlite
```

## Documentation

For detailed documentation, see:

- [Getting Started](docs/getting-started.md)
- [Query Syntax](docs/query-syntax.md)
- [Database Connectors](docs/database-connectors.md)
- [CLI Usage](docs/cli-usage.md)
- [API Reference](docs/api-reference.md)

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

See [CONTRIBUTING.md](CONTRIBUTING.md) for detailed guidelines.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
