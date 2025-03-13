namespace CSQLY.Errors;

/// <summary>
/// Exception raised when a CSQLY query fails to execute.
/// </summary>
public class SQLYExecutionError : SQLYError
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SQLYExecutionError"/> class.
    /// </summary>
    public SQLYExecutionError() : base() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SQLYExecutionError"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public SQLYExecutionError(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SQLYExecutionError"/> class with a specified error message
    /// and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public SQLYExecutionError(string message, Exception innerException) : base(message, innerException) { }
}
