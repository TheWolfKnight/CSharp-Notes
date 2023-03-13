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

    int i = l.UnwrapOrElse(err => throw new Exception(err));

  }

  static void OptionTests() {
    int i = 10;

    Option<int> o = Option<int>.Some(i);
    Option<int> n = Option<int>.None();

    Option<string> t = Option<string>.Some("Hello, World!");
    Option<string> l = Option<string>.None();

    System.Console.WriteLine(o.IsSome);
    System.Console.WriteLine(o.IsNone);

    o.IfSome(item => System.Console.WriteLine(item))
     .IfNone(() => System.Console.WriteLine("None"));

    n.IfSome(item => System.Console.WriteLine(item))
     .IfNone(() => System.Console.WriteLine("None"));

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
