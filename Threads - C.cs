using System;
using System.Threading;

namespace threads_share_pass_return
{
  class Dati
  {
    static int condivisa_static = 0;

    int condivisa = 0;

    public void f() {
      Random generatore = new Random();
      Console.WriteLine($"Invocata dal thread {Thread.CurrentThread.Name}");
      condivisa = generatore.Next(100);
      Console.WriteLine($"Ora la variabile condivisa vale: {condivisa}");
    }

    public static void f_static()
    {
      Random generatore = new Random();
      Console.WriteLine($"Static. Invocata dal thread {Thread.CurrentThread.Name}");
      condivisa_static = generatore.Next(100);
      Console.WriteLine($"Ora la variabile condivisa statica vale: {condivisa_static}");
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      Dati d = new Dati();

      //con variabile di istanza condivisa
      Thread t1 = new Thread(d.f);
      t1.Name = "thread 1";

      Thread t2 = new Thread(d.f);
      t2.Name = "thread 2";

      t1.Start(); t2.Start();
      t1.Join(); t2.Join();
      Console.WriteLine(new string('-', 80));
      
      //con variabile statica condivisa
      t1 = new Thread(Dati.f_static);
      t1.Name = "thread 1";

      t2 = new Thread(Dati.f_static);
      t2.Name = "thread 2";

      t1.Start(); t2.Start();
      t1.Join(); t2.Join();
      Console.WriteLine(new string('-', 80));

      //con closure su variabile locale
      int condivisa_main = 0;
      Random generatore = new Random();

      t1 = new Thread(() =>
      {
        Console.WriteLine($"Main: thread1");
        condivisa_main = generatore.Next(100);
        Console.WriteLine($"Main: ora la variabile locale al main vale: {condivisa_main}");
      });

      t1.Name = "thread 1";

      t2 = new Thread(() =>
      {
        Console.WriteLine($"Main: thread2");
        condivisa_main = generatore.Next(100);
        Console.WriteLine($"Main: ora la variabile locale al main vale: {condivisa_main}");
      });

      t1.Start(); t2.Start();
      t1.Join(); t2.Join();

      for (int i = 0; i < 10; i++)
      {
        int temp = i;
        new Thread(() => Console.Write(temp)).Start();
      }
      


    }
  }
}
