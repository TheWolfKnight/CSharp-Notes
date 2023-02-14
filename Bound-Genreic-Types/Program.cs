
namespace Bound_Genreic_Types;

public class Program {
  static void Main(string[] args) {
    int a = 2, b = 5;
    float t = 0.99f;

    float l = sMath<float>.Lerp(a, b, t);
    System.Console.WriteLine(l);
  }
}
