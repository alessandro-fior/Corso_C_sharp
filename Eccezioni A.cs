using System;

namespace try_catch_A
{
  class Razzo
  {
    int AccelerazioneDaFermo { get; set; } // m/sec2

    public Razzo(int accelerazioneDaFermo)
    { AccelerazioneDaFermo = accelerazioneDaFermo; }

    public double Tempo(int velocita)
    {
      return velocita / AccelerazioneDaFermo;  //velocita = accelerazione * tempo
      //try
      //{
      //  return velocita / AccelerazioneDaFermo;  //velocita = accelerazione * tempo
      //}
      
      //catch (DivideByZeroException e)
      //{
      //  Console.WriteLine("Catturata in Tempo");
      //  return -1;
      //}    

      //finally
      //{
      //  Console.WriteLine("Finally eseguito");
      //}
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
    }
  }
}
