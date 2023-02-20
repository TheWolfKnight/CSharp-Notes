using System.Diagnostics;

namespace Monad;

public class Program {
  static void Main(string[] args) {
    OptionTests();
  }

  static void OptionTests() {
    int i = 10;

    Option<int> o = new Option<int>(i);
    Option<int> n = new Option<int>(null);

    Option<string> t = new Option<string>("Hello, World!");
    Option<string> l = new Option<string>(null);

    System.Console.WriteLine(o.IsSome);
    System.Console.WriteLine(o.IsNone);

    try {
      string m = l.Unwrap();
    }
    catch (ArgumentNullException) {
      System.Console.WriteLine("m could not be unwraped");
    }

    System.Console.WriteLine(n.UnwrapOr(-1));
    System.Console.WriteLine(o.Unwrap());

    int test = o.IsSome switch
    {
      true => o.Unwrap(),
      false => -1,
    };

    Debug.Assert(test == i);
  }
}
