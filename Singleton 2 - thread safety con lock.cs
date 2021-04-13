using System;

namespace SingletonEasy
{
  //static class MyClassStatic
  //{
  //  static readonly double dati;
  //  public static double Dati { get { return dati; } }

  //  static MyClassStatic()
  //  {
  //    //altro codice di inizializzazione
  //    dati = 3.14;
  //  }
  //}

  class MyClass
  {
    static private readonly object forLock = new object();

    static private MyClass instance = null;
    static public MyClass Instance
    {
      get
      {
        if (instance == null)
        {
          lock (forLock)
          {
            if (instance == null) instance = new MyClass();
          }
        }

        return instance;

        //return instance ??= new MyClass(); //null-coalescing
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
