using System;

namespace SingletonFull
{

  //class MyClass
  //{
  //  static private readonly Lazy<int> valore = new Lazy<int>(() => Sum(1, 2));
  //  static public int Valore => valore.Value;
  //  static public int Sum(int a, int b)
  //  {
  //    Console.WriteLine($"Esecuzione Sum {a} - {b}");
  //    return a + b;
  //  }

  //  static MyClass() { Console.WriteLine("costruttore statico"); }

  //}


  class MyClassNoLazy
  {
    static public readonly MyClassNoLazy Instance = new MyClassNoLazy();
    //public static int valore = 0; //forza inizializzazione eager di Instance
    private MyClassNoLazy() { Console.WriteLine("costruttore"); }
    static MyClassNoLazy() { }
  }

  class MyClassLazy
  {
    static private readonly Lazy<MyClassLazy> instance = new Lazy<MyClassLazy>(() => new MyClassLazy());
    static public MyClassLazy Instance => instance.Value;

    public static int valore = 0;
    private MyClassLazy() { Console.WriteLine("costruttore"); }
  }

  //Credits: Jon Skeet https://csharpindepth.com/Articles/Singleton#nested-cctor
  public sealed class Singleton
  {
    public static int valore = 0;
    private Singleton() { Console.WriteLine("costruttore"); }

    public static Singleton Instance => Nested.instance; 

    private class Nested
    {
      internal static readonly Singleton instance = new Singleton();
    }
  }


  class Program
  {
    static void Main(string[] args)
    {
      int d = Singleton.valore;
    }
  }
}
