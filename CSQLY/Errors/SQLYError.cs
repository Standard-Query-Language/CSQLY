namespace CSQLY.Errors;

/// <summary>
/// Base exception class for all CSQLY-related errors.
/// </summary>
public class SQLYError : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SQLYError"/> class.
    /// </summary>
    public SQLYError() : base() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SQLYError"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public SQLYError(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SQLYError"/> class with a specified error message
    /// and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public SQLYError(string message, Exception innerException) : base(message, innerException) { }
}
