using Ob = ObserverPattern.Observer;

namespace ObserverPattern;

public class Program {
  static void Main(string[] args) {
    Ob.IObserver ob = new Ob.Observer();

    ob.Subscribe(() => Console.WriteLine("hello word!"));
    ob.Subscribe(() => Console.WriteLine("No world!"));

    ob.Notify();
  }
}

public class A {

  public int I;

  private A(int i) => I = i;

  public static A Create(int i) => new A(i);

  public static void Update(ref A self, int i) => self.I = i;

}
