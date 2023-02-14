
using System.Numerics;

namespace Bound_Genreic_Types;

public static class sMath<T>
where T: INumber<T>, IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>, IMultiplyOperators<T, float, T>
{
  public static T Lerp(T a, T b, float t) {
    return a + (b - a) * t;
  }
}
