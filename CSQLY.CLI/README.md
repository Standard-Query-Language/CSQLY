# CSQLY Command Line Interface

CSQLY CLI is a command-line tool for executing YAML-based SQL queries against various database systems.

## Installation

```bash
dotnet tool install --global CSQLY.CLI
```

## Usage

```bash
csqly --file <path-to-yaml-file> --connection <connection-string> --type <database-type>
```

Abbreviated options:

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

### SQLite Example

```bash
csqly -f query.yaml -c "Data Source=mydb.sqlite" -t sqlite
```

### MySQL Example

```bash
csqly -f query.yaml -c "Server=localhost;Database=mydb;User ID=user;Password=password;" -t mysql
```

## YAML Query Example

```yaml
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

## More Information

For full documentation, visit the [GitHub repository](https://github.com/Standard-Query-Language/CSQLY).
