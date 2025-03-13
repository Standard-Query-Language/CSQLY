namespace CSQLY.Errors;

/// <summary>
/// Exception raised for errors in the parsing of a CSQLY query.
/// </summary>
public class SQLYParseError : SQLYError
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SQLYParseError"/> class.
    /// </summary>
    public SQLYParseError() : base() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SQLYParseError"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public SQLYParseError(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SQLYParseError"/> class with a specified error message
    /// and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public SQLYParseError(string message, Exception innerException) : base(message, innerException) { }
}
