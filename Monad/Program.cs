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

    Option<Test> t = new Option<Test>(new Test(1));
    Option<Test> l = new Option<Test>(null);

    System.Console.WriteLine(o.IsSome);
    System.Console.WriteLine(o.IsNone);

    try {
      Test m = l.Unwrap();
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
