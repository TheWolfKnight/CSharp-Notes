
using System.Numerics;

namespace Monad;

public class Option<T>
{
  private object? _Value;

  /// <summary>
  /// Shows wether or not there is a value present
  /// </summary>
  public bool IsSome => _Value != null;

  /// <summary>
  /// Shows wether or not the value is missing
  /// </summary>
  public bool IsNone => _Value == null;

  /// <summary>
  /// Creates a Option instance with a value of type <paramref name="T"/>
  /// </summary>
  /// <param name="val"> The value to be put into the Option instance </param>
  public Option(object? val) {
    _Value = val;
  }

  /// <summary>
  /// Returns the unrelying value, will throw an error if the value is not pressent
  /// </summary>
  /// <returns> Returns the contained value if it is pressent </returns>
  /// <exception cref="ArgumentNullException"> The error is thrown if the user tries to unwrap and empty option </exception>
  public T Unwrap() {
    if (_Value == null) throw new ArgumentNullException("Cannot unwrap an empty value");
    return (T) _Value;
  }

  /// <summary>
  /// Returns the value stored in the option, ot the value given by the user.
  /// </summary>
  /// <param name="backup"> The value that will be returned if the Option is empty </param>
  /// <returns>
  /// An instance of <paramref name="T"/> that is either the internal value of the Option, or the given value in <paramref name="backup"/>
  /// </returns>
  public T UnwrapOr(T backup) {
    if (_Value == null) return backup;
    return (T) _Value;
  }

  /// <summary>
  /// Returns the value in the Option instance, or the default value for the type <br/>
  /// <b>WARNING:</b> this can be a null value.
  /// </summary>
  /// <returns> The value in the Option, or the default for <paramref name="T"/> </returns>
  public T? UnwrapOrDefault() {
    if (_Value == null) return default(T);
    return (T) _Value;
  }

  /// <summary>
  /// Returns the value containd in the option, or throws an exception with at given message.
  /// </summary>
  /// <param name="message"> The message to be throw if the Option is empty </param>
  /// <returns> The value contained in the Options instance </returns>
  /// <exception cref="Exception"> The base exception class, thrown with the given message </exception>
  public T UnwrapOrPanic(string message) {
    if (_Value == null) throw new Exception(message);
    return (T)_Value;
  }

  /// <summary>
  /// Returns the value containd in the option, or throws an exception with at given message.
  /// </summary>
  /// <param name="exception"> The exception to be thrown if the Option is null </param>
  /// <returns> The value contained in the Options instance </returns>
  public T UnwrapOrPanic(Exception exception) {
    if (_Value == null) throw exception;
    return (T)_Value;
  }
}
