using System;
using System.Threading;

namespace threads_share_pass_return_B
{
  class Program
  {
    static int fattoriale = 0;

    class Punto
    {
      public int X { get; set; }
      public int Y { get; set; }
      public Punto(int x, int y) { X = x; Y = y; }
    }

    static void Metodo(Object obj)
    {
      Punto p = (Punto)obj;
      Console.WriteLine(p.X + p.Y);
    }

    static void Fattoriale(Object obj)
    {
      int n = (int)obj;
     
      int risultato = n==0 ? 1 : n;

      while (n > 1)
        risultato *= --n;

      fattoriale = risultato;
    }

    static int MetodoPerLambda(int a, int b)
    {
      int risultato;
      try
      {
        return a + b/0;
      }
      catch (DivideByZeroException err) {
        Console.WriteLine($"Divisione per zero nel thread");
      }
      
      return -1;

    }

    static void Main(string[] args)
    {
      Thread t1 = new Thread(Fattoriale);
      t1.Start(5);
      t1.Join();
      Console.WriteLine(Program.fattoriale);

      int risultato = 0;
      Thread t2 = new Thread( () => risultato = MetodoPerLambda(10, 20) );

      try
      {
        t2.Start();
        t2.Join();
      }
      catch (DivideByZeroException err) { }
      Console.WriteLine(risultato);

    }
  }
}
