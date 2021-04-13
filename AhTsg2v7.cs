using System;
using System.Drawing;

namespace overload_op_funzioni
{
  class Frazione
  {
    public int Num { get; set; } = 0;

    private int den;
    public int Den
    {
      get => den;
      set
      {
        if (value == 0) throw new ArgumentException("Denominatore zero");
        den = value;
      }
    }
    public Frazione() { Den = 1; }
    public Frazione(int num, int den)
    { Num = num; Den = den; }

    public Frazione(int n) : this(n, 1) { }
    public Frazione(string s)
    {

      if (string.IsNullOrEmpty(s)) return;

      //if (s == null || s == "") return;

      string[] dati = s.Split('/'); //da "25ert/7" -> ["25", "7"]

      try
      {
        Num = int.Parse(dati[0]);
      }
      catch (FormatException e)
      {
        throw new FormatException("Stringa non nel formato 'numero/numero' o 'numero'");
      }

      if (dati.Length == 1) // "25"
        Den = 1;
      else
      {
        try
        {
          Den = int.Parse(dati[1]);
        }
        catch (FormatException e)
        {
          throw new FormatException("Stringa non nel formato 'numero/numero' o 'numero'");
        }
      }
    }

    public override string ToString() { return $"{Num}/{Den}"; }

    public static  Frazione operator +(Frazione f1, Frazione f2)
    {

      return new Frazione(f1.Num * f2.Den + f2.Num * f1.Den, f1.Den * f2.Den);

    }

    //public static Frazione operator +(Frazione f1, int n)
    //{
    //  return f1 + new Frazione(n, 1);
    //}

    public static implicit operator Frazione(int n) => new Frazione(n);
    
    public static explicit operator Frazione(string s) => new Frazione(s);

    class Program
    {
      static void Main(string[] args)
      {

        Frazione f1 = new Frazione(3, 2);    //  3/2
        Frazione f2 = new Frazione("4/5");  //  4/5

        
        Frazione f3 = f1 + f2;
        Frazione f4 = 6; // = new Frazione(6)
        
        Console.WriteLine(3 + f1);
        Console.WriteLine(f1 + 3);

        Frazione f5 = (Frazione)"4/5";
        Console.WriteLine(f1 + "paperino");

      }
    }
  }
}
