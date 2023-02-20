
namespace Monad;

public class Result<TValue, TError> {

  private object? _Inner;

  /// <summary>
  /// Returns a true if the Result instance contains a value, else return false.
  /// </summary>
  public bool IsOk;

  /// <summary>
  /// Returns a true if the Result instance contains a error, else return false.
  /// </summary>
  public bool IsError;

  /// <summary>
  /// Creates a instance of the Result class that contains a value.
  /// </summary>
  /// <param name="value"> The value to be inserted into the <paramref name="_Inner"/> field </param>
  /// <returns> A new instance of the Result class containing the <paramref name="value"/> </returns>
  public static Result<TValue, TError> Ok(TValue value) =>
    new Result<TValue, TError>(value, isValue: true);

  /// <summary>
  /// Creates a instance of the Result class that contains a error
  /// </summary>
  /// <param name="error"> The value of the error inserted into the <paramref name="_Inner"/> field </param>
  /// <returns> A new instance of the Result class containing the <paramref name="error"/> </returns>
  public static Result<TValue, TError> Error(TError error) =>
    new Result<TValue, TError>(error, isValue: false);


  private Result(object? inner, bool isValue) {
    _Inner = inner;
    IsOk = isValue;
    IsError = !isValue;
  }

  /// <summary>
  /// Returns the value from the Result instance, else throws a exception
  /// </summary>
  /// <returns> Returns the underlying value of the Result instance </returns>
  /// <exception cref="ResultValueNullException"> An exception telling the user that you cannot extract a error using the value getter </exception>
  public TValue GetValue() {
    if (_Inner == null || IsError) throw new ResultValueNullException("Cannot get Value, when a Error was returned");
    return (TValue)_Inner;
  }

  /// <summary>
  /// Returns the error from the Result instance, else throws a exception
  /// </summary>
  /// <returns> Returns the underlying error of the Result instance</returns>
  /// <exception cref="ResultErrorNullException"> An exception telling the user that you cannot extract a value using the error getter </exception>
  public TError GetError() {
    if (_Inner == null || IsOk) throw new ResultErrorNullException("Cannot get Error, when the Value was returned");
    return (TError)_Inner;
  }
}

public class ResultValueNullException: Exception {
  public ResultValueNullException() : base() {}
  public ResultValueNullException(string? message): base(message) {}
  public ResultValueNullException(string? message, Exception? inner): base(message, inner) {}
}

public class ResultErrorNullException: Exception {
  public ResultErrorNullException() : base() {}
  public ResultErrorNullException(string? message): base(message) {}
  public ResultErrorNullException(string? message, Exception? inner): base(message, inner) {}
}
