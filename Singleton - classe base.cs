using System;

namespace SingletonEasy
{
  class MyClass
  {
    static private MyClass instance = null;
    static public MyClass Instance
    {
      get
      {
        //if (instance == null) instance = new MyClass();
        //return instance;
        return instance ??= new MyClass(); //null-coalescing
      }
    }

    public void Metodo() { Console.WriteLine("metodo richiamato"); }

    private MyClass() { Console.WriteLine("Oggetto creato"); }
  }

  class Program
  {
    static void Main(string[] args)
    {
      MyClass.Instance.Metodo();
      MyClass.Instance.Metodo();
    }
  }
}
