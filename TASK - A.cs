using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_A
{
  class Program
  {

    static void MetodoGenerico()
    {
      for (int i = 0; i < 100; i++) Console.WriteLine(i);
    }

    static int Sommatore(int[] v)
    {
      int somma = 0;
      foreach (int n in v) { somma += n; Thread.Sleep(50); }
      return somma;
    }

    static void Main(string[] args)
    {
      int[] v = { 1, 2, 3, 4 };

      //Task t1 = Task.Run(() => MetodoGenerico());
      //t1.Wait();

      Task<int> t2 = Task<int>.Run(() => Sommatore(v));
      while (true)
      { 
        Console.WriteLine($"Stato: {t2.Status}");
        if (t2.Status == TaskStatus.RanToCompletion) break;
        Thread.Sleep(50); 
      }

      Console.WriteLine(t2.Result);


      Console.WriteLine("main terminato");
    }
  }
}
