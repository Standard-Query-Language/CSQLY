namespace CSQLY.Errors;

/// <summary>
/// Exception raised when a database connector operation fails.
/// </summary>
public class SQLYConnectorError : SQLYError
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SQLYConnectorError"/> class.
    /// </summary>
    public SQLYConnectorError() : base() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SQLYConnectorError"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public SQLYConnectorError(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SQLYConnectorError"/> class with a specified error message
    /// and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public SQLYConnectorError(string message, Exception innerException) : base(message, innerException) { }
}
