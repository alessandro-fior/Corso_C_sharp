using System;

namespace Conversioni
{
  class Figura
  {
    public virtual void Disegna() { }
  }

  class Quadrato : Figura
  {
    public override void Disegna()
    {
      Console.WriteLine("Disegna Quadrato");
    }
  }

  class Cerchio : Figura
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
      
      //CONVERSIONI IMPLICITE
      int n = 39888;
      double x = n; //conversione sicura, automatica = implicita

      Quadrato q = new Quadrato();
      Figura f = q;


      //CONVERSIONI ESPLICITE (CAST)
      x = 3000000000.14;       
      checked
      {
        //n = (int)x;
      }

      string s = "";
      //n = (int)s;
      //n=Convert.ToInt32(s);


      //Console.WriteLine(x);
      //Console.WriteLine(n);
      //Console.WriteLine(f);

      f = new Cerchio();
      //q = (Quadrato)f;            
      //q = f as Quadrato;

      if (f is Quadrato q2) 
        { Console.WriteLine(q2); }
      else
        { Console.WriteLine("Conversione impossibile"); }

      Quadrato q3 = null; ;
      if (f is Quadrato)
      { q3 = (Quadrato)f; }
      else
      { Console.WriteLine("Conversione impossibile"); }
      //Console.WriteLine(q == null);


    }
  }
}
