
namespace Monad;

public class Option<T> where T: struct
{
  private Nullable<T> Value;

  /// <summary>
  /// Shows wether or not there is a value present
  /// </summary>
  public bool IsSome => Value.HasValue;

  /// <summary>
  /// Shows wether or not the value is missing
  /// </summary>
  public bool IsNone => !Value.HasValue;

  /// <summary>
  /// Constructs a new Option instance
  /// </summary>
  /// <param name="val"> The value that will be containd in the option </param>
  public Option(Nullable<T> val) => Value = val;

  /// <summary>
  /// Returns the unrelying value, will throw an error if the value is not pressent
  /// </summary>
  /// <returns> Returns the contained value if it is pressent </returns>
  /// <exception cref="ArgumentNullException"> The error is thrown if the user tries to unwrap and empty option </exception>
  public T Unwrap() {
    if (!Value.HasValue) throw new ArgumentNullException("Cannot unwrap an empty value");
    return Value.Value;
  }

  /// <summary>
  /// Returns the value stored in the option, ot the value given by the user.
  /// </summary>
  /// <param name="backup"> The value that will be returned if the Option is empty </param>
  /// <returns>
  /// An instance of T that is either the internal value of the Option, or the given value in <paramref name="backup"/>
  /// </returns>
  public T UnwrapOr(T backup) {
    if (!Value.HasValue) return backup;
    return Value.Value;
  }

  public T UnwrapOrDefault() {
    if (!Value.HasValue) return default(T);
    return Value.Value;
  }
}
