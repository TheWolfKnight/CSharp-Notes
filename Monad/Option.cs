
using System.Numerics;

namespace Monad;

public class Option<T>
{
  private object? _Inner;

  /// <summary>
  /// Shows wether or not there is a value present
  /// </summary>
  public bool IsSome => _Inner != null;

  /// <summary>
  /// Shows wether or not the value is missing
  /// </summary>
  public bool IsNone => _Inner == null;

  /// <summary>
  /// 
  /// </summary>
  /// <param name="value"></param>
  /// <returns></returns>
  public static Option<T> Some(T value) {
    Option<T> result = new Option<T>(value);
    return result;
  }

  /// <summary>
  /// 
  /// </summary>
  /// <returns></returns>
  public static Option<T> None() {
    Option<T> result = new Option<T>(null);
    return result;
  }

  /// <summary>
  /// Creates a Option instance with a value of type <paramref name="T"/>
  /// </summary>
  /// <param name="val"> The value to be put into the Option instance </param>
  private Option(object? val) {
    _Inner = val;
  }

  /// <summary>
  /// Returns the unrelying value, will throw an error if the value is not pressent
  /// </summary>
  /// <returns> Returns the contained value if it is pressent </returns>
  /// <exception cref="ArgumentNullException"> The error is thrown if the user tries to unwrap and empty option </exception>
  public T Unwrap() {
    if (_Inner == null) throw new ArgumentNullException("Cannot unwrap an empty value");
    return (T) _Inner;
  }

  /// <summary>
  /// Returns the value stored in the option, ot the value given by the user.
  /// </summary>
  /// <param name="backup"> The value that will be returned if the Option is empty </param>
  /// <returns>
  /// An instance of <paramref name="T"/> that is either the internal value of the Option, or the given value in <paramref name="backup"/>
  /// </returns>
  public T UnwrapOr(T backup) {
    if (_Inner == null) return backup;
    return (T) _Inner;
  }

  /// <summary>
  /// Returns the value in the Option instance, or the default value for the type <br/>
  /// <b>WARNING:</b> this can be a null value.
  /// </summary>
  /// <returns> The value in the Option, or the default for <paramref name="T"/> </returns>
  public T? UnwrapOrDefault() {
    if (_Inner == null) return default(T);
    return (T) _Inner;
  }

  /// <summary>
  /// Returns the value containd in the option, or throws an exception with at given message.
  /// </summary>
  /// <param name="message"> The message to be throw if the Option is empty </param>
  /// <returns> The value contained in the Options instance </returns>
  /// <exception cref="Exception"> The base exception class, thrown with the given message </exception>
  public T UnwrapOrPanic(string message) {
    if (_Inner == null) throw new Exception(message);
    return (T)_Inner;
  }

  /// <summary>
  /// Returns the value containd in the option, or throws an exception with at given message.
  /// </summary>
  /// <param name="exception"> The exception to be thrown if the Option is null </param>
  /// <returns> The value contained in the Options instance </returns>
  public T UnwrapOrPanic(Exception exception) {
    if (_Inner == null) throw exception;
    return (T)_Inner;
  }

  /// <summary>
  /// Handels the path where the Option has a value
  /// </summary>
  /// <param name="func"> The actions to be preformed on the <paramref name="_Inner"/> value </param>
  /// <returns> Returns the original instance for chaining </returns>
  public Option<T> IfSome(Action<T> func) {
    if (_Inner == null) return this;
    func((T)_Inner);
    return this;
  }

  /// <summary>
  /// Handles the path where the Option has a value, and the user will use more variables in the function
  /// </summary>
  /// <typeparam name="TResult"> The resulting type for the excetion </typeparam>
  /// <param name="func"> The actions to be preformed on the <paramref name="_Inner"/> value </param>
  /// <param name="args"> The other args to be used in the function call </param>
  /// <returns> Returns the original instance for chaining </returns>
  public Option<T> IfSome(Action<T, object[]> func, params object[] args) {
    if (_Inner == null) return this;
    func((T)_Inner, args);
    return this;
  }

  /// <summary>
  /// Handels the path where the Option has a value
  /// </summary>
  /// <param name="func"> The actions to be preformed on the inner value </param>
  /// <returns> Returns the original instance for chaining </returns>
  public Option<T> IfNone(Action func) {
    if (_Inner != null) return this;
    func();
    return this;
  }

  /// <summary>
  /// Handels the path where the Option has a value
  /// </summary>
  /// <param name="func"> The actions to be preformed on the inner value </param>
  /// <param name="args"> The other args to be used in the function call </param>
  /// <returns> Returns the original instance for chaining </returns>
  public Option<T> IfNone(Action<object[]> func, params object[] args) {
    if (_Inner != null) return this;
    func(args);
    return this;
  }

}
