using System;
using System.Collections.Generic;

namespace ClassiAstratte
{

  abstract class Figura
  {
    protected Figura() { }

    public abstract ConsoleColor Colore { get; set; }

    //abstract protected int spessoreTratto = 0; NO

    public abstract void Disegna();
  }

  abstract class Quadrato : Figura
  {
    public override ConsoleColor Colore { get; set; } = ConsoleColor.Black;
    
    //public override void Disegna()
    //{
    //  Console.WriteLine("Disegna Quadrato");
    //}
  }

  class QuadratoFilled : Quadrato
  {
    public override void Disegna()
    {
      Console.WriteLine("Disegna QuadratoFilled");
    }
  }

  class Cerchio : Figura
  {
    public override ConsoleColor Colore { get; set; } = ConsoleColor.Red;
    public double Raggio { get; set; } = 0;

    public override void Disegna()
    {
      Console.WriteLine("Disegna Cerchio");
    }

    public double crf() => 2 * Math.PI * Raggio;
  }

  class Figura2
  {
    virtual public void Disegna() { }
  }

  sealed class Quadrato2 : Figura2
  {
    public override void Disegna()
    {
      Console.WriteLine("Disegna Quadrato");
    }

  }

  class QuadratoFilled2 : Quadrato2 //NO se la classe madre intera è sealed
  {
    //public override void Disegna()
    //{
    //  Console.WriteLine("Disegna QuadratoFilled");
    //}
  }

  class Cerchio2 : Figura2
  {
    public double Raggio { get; set; } = 0;

    public override void Disegna()
    {
      Console.WriteLine("Disegna Cerchio");
    }

    public double crf() => 2 * Math.PI * Raggio;
  }


  class Program
  {
    static void Main(string[] args)
    {

     //Figura f = new Figura(); NO, astratta

      List<Figura> disegno = new List<Figura>() 
         { new Cerchio(),
           /* new Quadrato(), non se Quadrato è abstract */  
           new QuadratoFilled()
         };

      foreach (Figura f in disegno) f.Disegna();

    }
  }
}
