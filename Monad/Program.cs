
namespace Monad;

public class Program {
  static void Main(string[] args) {
    int i = 10;
    Option<int> o = new Option<int>(i);
    Option<int> n = new Option<int>(null);

    System.Console.WriteLine(o.IsSome);
    System.Console.WriteLine(o.IsNone);

    try {
      int l = n.Unwrap();
    }
    catch (ArgumentNullException) {
      System.Console.WriteLine("n could not be unwraped");
    }

    System.Console.WriteLine(n.UnwrapOr(-1));
    System.Console.WriteLine(o.Unwrap());

  }
}
