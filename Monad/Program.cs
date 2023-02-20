using System.Diagnostics;


namespace Monad;

public class Program {
  static void Main(string[] args) {
    OptionTests();
    ResultTests();
  }

  static void ResultTests()
  {

    Test a = new Test(1);

    Result<int, string> result = a.GetA();

    int val = result.IsOk switch
    {
      true => result.GetValue(),
      false => throw new Exception(result.GetError()),
    };

    System.Console.WriteLine(val);

    Test b = new Test(null);
    Result<int, string> l = b.GetA();

    int p = l.IsOk switch
    {
      true => l.GetValue(),
      false => throw new Exception(l.GetError()),
    };

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

public class Test {
  public int? A;

  public Test(int? a) => A = a;

  public Result<int, string> GetA() {
    if (A == null) return Result<int, string>.Error("Could not get A");
    return Result<int, string>.Ok((int)A);
  }
}
