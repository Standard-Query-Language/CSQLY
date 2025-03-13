using System.CommandLine;
using CSQLY.Core;
using CSQLY.Connectors;

namespace CSQLY.CLI;

public class Program
{
    public static int Main(string[] args)
    {
        // Create a root command
        var rootCommand = new RootCommand("CSQLY Command Line Interface");

        // Add options and commands here
        var fileOption = new Option<FileInfo?>(
            name: "--file",
            description: "The YAML query file to execute");
        fileOption.AddAlias("-f");

        var connectionOption = new Option<string>(
            name: "--connection",
            description: "Database connection string");
        connectionOption.AddAlias("-c");

        var dbTypeOption = new Option<string>(
            name: "--type",
            description: "Database type (sqlite, mysql, postgres, etc.)");
        dbTypeOption.AddAlias("-t");

        // Add options to root command
        rootCommand.AddOption(fileOption);
        rootCommand.AddOption(connectionOption);
        rootCommand.AddOption(dbTypeOption);

        // Define the handler for the command
        rootCommand.SetHandler((file, connection, dbType) =>
        {
            Console.WriteLine($"File: {file?.FullName ?? "None"}");
            Console.WriteLine($"Connection: {connection}");
            Console.WriteLine($"Database Type: {dbType}");

            try
            {
                // Create database connector if connection and dbType are provided
                if (!string.IsNullOrEmpty(connection) && !string.IsNullOrEmpty(dbType))
                {
                    var connector = new DatabaseConnector(dbType, connection);

                    // Execute query from file or standard input
                    string yamlQuery;
                    if (file != null && file.Exists)
                    {
                        yamlQuery = File.ReadAllText(file.FullName);
                        var query = SQLYUtils.ParseYaml(yamlQuery);
                        var result = connector.ExecuteQuery(query);
                        Console.WriteLine("Query executed successfully:");
                        Console.WriteLine(result);
                    }
                    else
                    {
                        Console.WriteLine("No valid query file provided.");
                    }
                }
                else
                {
                    Console.WriteLine("Both connection string and database type are required.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                // Don't return a value here in the void handler
            }

        }, fileOption, connectionOption, dbTypeOption);

        // Parse and invoke the command
        return rootCommand.Invoke(args);
    }
}
