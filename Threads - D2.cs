using System;
using System.IO;
using System.Threading;

namespace Threads_B
{
  class Program
  {
    static readonly object lucchetto = new object();

    static double CalcolaSomma(double[] v, int quanti)
    {
      double somma = 0;
      double sommaParziale = 0;

      for (int segmento = 0; segmento < 4; segmento++)
      {
        sommaParziale = 0;
        for (int i = 25000000 * segmento; i < 25000000 * (segmento + 1); i++)
          sommaParziale += v[i];
        somma += sommaParziale;
      }
      return somma;
    }

    static void CalcolaSommaThread(double[] v, int da, int quanti, ref double somma)
    {
      double sommaParziale = 0;

      for (int i = da; i < da + quanti; i++) sommaParziale += v[i];
     
      lock (lucchetto)
      {
        somma += sommaParziale;
      }
      
      Console.WriteLine($"Da indice {da} fino a indice {da + quanti - 1}");
    }

    static void Main(string[] args)
    {
      int quanti = 100000000;
      double[] v = new double[quanti];
      double somma = 0;

      Random generatore = new Random();
      for (int i = 0; i < quanti; i++) v[i] = generatore.NextDouble() * 10;

      DateTime start = DateTime.Now;
      somma = CalcolaSomma(v, quanti);
      Console.WriteLine($"Somma: {somma}");

      DateTime end = DateTime.Now;
      Console.WriteLine((end - start).TotalMilliseconds);

      somma = 0;
      Thread[] threads = new Thread[4];

      start = DateTime.Now;

      for (int i = 0; i < 4; i++)
      {
        int parti_da = i;
        threads[i] = new Thread(() => CalcolaSommaThread(v, parti_da * 25000000, 25000000,ref somma));
        threads[i].Start();
        //threads[i].Join();
      }
     
      foreach (Thread t in threads) t.Join();
      end = DateTime.Now;
      
      Console.WriteLine((end - start).TotalMilliseconds);
      Console.WriteLine($"Somma: {somma}");
    }
  }
}
