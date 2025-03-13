# CSQLY CLI Usage

The CSQLY Command Line Interface (CLI) allows you to execute YAML queries directly from the command line without writing any code.

## Installation

Install the CLI tool globally using the .NET CLI:

```bash
dotnet tool install --global CSQLY.CLI
```

## Basic Usage

The basic syntax for using the CLI:

```bash
csqly --file <path-to-yaml-file> --connection <connection-string> --type <database-type>
```

Abbreviated options are also available:

```bash
csqly -f <path-to-yaml-file> -c <connection-string> -t <database-type>
```

## Options

| Option | Abbreviation | Description |
|--------|--------------|-------------|
| `--file` | `-f` | Path to the YAML query file |
| `--connection` | `-c` | Database connection string |
| `--type` | `-t` | Database type (sqlite, mysql, postgres, sqlserver, oracle) |
| `--help` | `-h` | Show help information |
| `--version` | `-v` | Show version information |

## Examples

### Query a SQLite Database

```bash
csqly -f query.yaml -c "Data Source=mydb.sqlite" -t sqlite
```

### Query a MySQL Database

```bash
csqly -f query.yaml -c "Server=localhost;Database=mydb;User ID=user;Password=password;" -t mysql
```

### Query a PostgreSQL Database

```bash
csqly -f query.yaml -c "Host=localhost;Database=mydb;Username=user;Password=password;" -t postgres
```

### Query a SQL Server Database

```bash
csqly -f query.yaml -c "Server=localhost;Database=mydb;User ID=user;Password=password;" -t sqlserver
```

### Query an Oracle Database

```bash
csqly -f query.yaml -c "Data Source=MyOracleDB;User Id=user;Password=password;" -t oracle
```

## YAML Query File Example

Here's a simple example of a YAML query file:

```yaml
# query.yaml
select:
  columns:
    - id
    - name
    - email
  from: users
  where:
    active: true
  limit: 10
```

## Output Formats

By default, query results are displayed in a tabular format. Support for JSON, CSV, and other formats is planned for future releases.

## Advanced Usage

### Using Environment Variables

You can use environment variables for sensitive information like connection strings:

```bash
# Set environment variable
export DB_CONNECTION="Server=localhost;Database=mydb;User ID=user;Password=password;"

# Use it in the command
csqly -f query.yaml -c "$DB_CONNECTION" -t mysql
```

### Piping Results to Other Commands

```bash
csqly -f query.yaml -c "Data Source=mydb.sqlite" -t sqlite | grep "specific-data"
```

### Using in Shell Scripts

```bash
#!/bin/bash
# Script to run daily reports

REPORT_DATE=$(date +%Y-%m-%d)
echo "Running report for $REPORT_DATE"

csqly -f daily_report.yaml -c "$DB_CONNECTION" -t postgres
```

## Troubleshooting

### Common Issues

1. **Connection string format is incorrect**:
   - Make sure the connection string follows the correct format for your database type

2. **YAML syntax errors**:
   - Validate your YAML structure using a YAML validator
   - Check for proper indentation and spacing

3. **Database permissions**:
   - Ensure the user specified in the connection string has sufficient permissions

4. **Command not found error**:
   - Ensure the .NET CLI tools path is added to your system PATH
   - Try reinstalling the tool with `dotnet tool update --global CSQLY.CLI`
