
namespace Monad;

public class Result<TValue, TError> {

  private object? InnerValue, InnerError;

  /// <summary>
  /// 
  /// </summary>
  public bool IsValue;

  /// <summary>
  /// 
  /// </summary>
  public bool IsError;

  /// <summary>
  /// 
  /// </summary>
  /// <param name="value"></param>
  /// <returns></returns>
  public static Result<TValue, TError> Ok(TValue value) =>
    new Result<TValue, TError>(value, null, isValue: true);

  /// <summary>
  /// 
  /// </summary>
  /// <param name="error"></param>
  /// <returns></returns>
  public static Result<TValue, TError> Error(TError error) =>
    new Result<TValue, TError>(null, error, isValue: false);


  private Result(object? value, object? error, bool isValue) {
    InnerValue = value;
    InnerError = error;
    IsValue = isValue;
    IsError = !isValue;
  }

  /// <summary>
  /// 
  /// </summary>
  /// <returns></returns>
  /// <exception cref="Exception"></exception>
  public TValue GetValue() {
    if (InnerValue == null) throw new ResultValueNullException("Cannot get Value, when a Error was returned");
    return (TValue)InnerValue;
  }

  /// <summary>
  /// 
  /// </summary>
  /// <returns></returns>
  /// <exception cref="Exception"></exception>
  public TError GetError() {
    if (InnerError == null) throw new ResultErrorNullException("Cannot get Error, when the Value was returned");
    return (TError)InnerError;
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

public class UnrechableCodeExceptio: Exception {
  public UnrechableCodeExceptio() : base() {}
  public UnrechableCodeExceptio(string? message): base(message) {}
  public UnrechableCodeExceptio(string? message, Exception? inner): base(message, inner) {}
}
