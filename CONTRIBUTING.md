# Contributing to CSQLY

Thank you for considering contributing to CSQLY! This document outlines the guidelines for contributing to the project.

## Code of Conduct

This project adheres to a Code of Conduct. By participating, you are expected to uphold this code.

## How Can I Contribute?

### Reporting Bugs

- Check if the bug is already reported in the [Issues](https://github.com/Standard-Query-Language/CSQLY/issues)
- If not, create a new issue with details:
  - A clear title
  - A detailed description
  - Steps to reproduce
  - Expected behavior vs. actual behavior
  - Environment details (OS, .NET version, etc.)

### Suggesting Enhancements

- Check if the enhancement is already suggested in the [Issues](https://github.com/Standard-Query-Language/CSQLY/issues)
- If not, create a new issue with details:
  - A clear title
  - A detailed description explaining the enhancement and its benefits
  - Any design considerations or implementation details

### Pull Requests

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Make your changes
4. Run tests and ensure they pass (`./run_tests.sh` or `run_tests.bat`)
5. Update documentation if necessary
6. Commit your changes following our [commit message guidelines](#commit-messages)
7. Push to your branch (`git push origin feature/amazing-feature`)
8. Open a Pull Request with a clear description of the changes

## Development Setup

1. Install .NET SDK 9.0 or later
2. Clone the repository
3. Run `dotnet restore` to restore dependencies
4. Run `dotnet build` to build the solution
5. Run `./run_tests.sh` or `run_tests.bat` to run tests

## Project Structure

- `/CSQLY` - Core library
- `/CSQLY.Tests` - Unit tests
- `/CSQLY.CLI` - Command-line interface
- `/docs` - Documentation

## Coding Guidelines

- Follow C# coding conventions
- Write unit tests for new features
- Document public APIs with XML comments
- Keep code maintainable and readable

## Commit Messages

Follow the [Conventional Commits](https://www.conventionalcommits.org/) specification:

```bash
<type>(<scope>): <description>

[optional body]

[optional footer]
```

Examples:

- `feat(sqlite): add support for BLOB data`
- `fix(parser): correct handling of null values`
- `docs(readme): update installation instructions`

## Review Process

Pull requests will be reviewed by maintainers. The review process includes:

- Code review for quality, maintainability, and adherence to project standards
- Verification that tests pass and coverage is maintained
- Documentation review if applicable
- Ensuring the PR addresses a specific issue or enhancement

## License

By contributing to this project, you agree that your contributions will be licensed under the project's MIT License.
