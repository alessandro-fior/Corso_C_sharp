using System;

namespace try_catch_A
{
  class Razzo
  {
    int AccelerazioneDaFermo { get; set; } // m/sec2

    public Razzo(int accelerazioneDaFermo)
    { AccelerazioneDaFermo = accelerazioneDaFermo; }

    //public double level1(int velocita) {
    //  double x=-1;
    //  try { x =  level2(velocita); }
    //  catch (DivideByZeroException e)
    //  {
    //    Console.WriteLine(e.StackTrace);
    //  }
    //  return x;

    //}

    //double level2(int velocita){ return level3(velocita); }

    //double level3(int velocita) { return Tempo(velocita); }

    public double Tempo(int velocita)
    {
      try
      {
        return velocita / AccelerazioneDaFermo;  //velocita = accelerazione * tempo
      }


      catch (DivideByZeroException e)
      {
        double x = velocita / AccelerazioneDaFermo;
        Console.WriteLine(e.StackTrace);
      }

      catch (OverflowException e)
      {

      }

      catch (ArithmeticException e)
      {

      }

      finally
      {

        Console.WriteLine("Finally eseguito");
      }

      return -1;
    }
  }
  
  class Program
  {
    static void Main(string[] args)
    {
      Razzo apollo = new Razzo(0);

      try
      {
        Console.WriteLine($"Servono {apollo.Tempo(10000)} secondi per " +
                           "arrivare alla velocità di 10km/s");
      }

      catch (DivideByZeroException e)
      { Console.WriteLine("Eccezione intercettata nel main"); }


      //try
      //{
      //  Console.WriteLine($"Servono {apollo.Tempo(10000)} secondi per arrivare alla velocità di 10km/s");
      //}

      //catch (Exception e) when (e.GetType() != typeof(DivideByZeroException))
      //{
      //  Console.WriteLine("Catturata nel main");
      //}
    }
  }
}
