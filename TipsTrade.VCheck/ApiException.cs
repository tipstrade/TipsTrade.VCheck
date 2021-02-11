using System;
using System.Net;
using TipsTrade.VCheck.Model;

namespace TipsTrade.VCheck {
  /// <summary>Represents an error thrown by the <see cref="VCheckClient"/>.</summary>
  public class ApiException : Exception {
    /// <summary>The error returned by the VCheck API.</summary>
    public ErrorResponse Error { get; internal set; }

    /// <summary>The HTTP status code returned by the VCheck API.</summary>
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>Initializes a new instance of the System.Exception class.</summary>
    public ApiException() {
    }

    /// <summary> Initializes a new instance of the System.Exception class with a specified error message.</summary>
    /// <param name="message">The message that describes the error.</param>
    public ApiException(string message) : base(message) {
    }

    /// <summary>
    /// Initializes a new instance of the System.Exception class with a specified error
    /// message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference.</param>
    public ApiException(string message, Exception innerException) : base(message, innerException) {
    }
  }
}
