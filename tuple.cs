using System;

namespace tuple_1
{
  struct TMinMax
  {
    public IComparable min;
    public IComparable max;

    public TMinMax(IComparable min, IComparable max) { this.min = min; this.max = max; }
  }

  class Program
  {
    //metodo 1  parametri out
    static void MinMax(IComparable a, IComparable b, 
                       out IComparable min,  out IComparable max)
    {
      min = a.CompareTo(b) <=0 ? a : b;
      max = a.CompareTo(b) >= 0 ? a : b;
    }



    //metodo 2 con struct
    //static TMinMax MinMax(IComparable a, IComparable b)
    //{
    //  return new TMinMax(a.CompareTo(b) <= 0 ? a : b, a.CompareTo(b) >= 0 ? a : b);
    //}


    //con le tuple
    static (IComparable min, IComparable max) MinMax(IComparable a, IComparable b)
    {
      return (a.CompareTo(b) <= 0 ? a : b, a.CompareTo(b) >= 0 ? a : b);
    }

    static void m( (int n, string s) parametro)
    { }

    static void Main(string[] args)
    {
      //con parametri out
      MinMax(3, 5, out IComparable minimo, out IComparable massimo);
      Console.WriteLine($"Minimo: {minimo} - Massimo: {massimo}");

      MinMax("Topolino", "Topolina", out IComparable par1, out IComparable par2);
      Console.WriteLine($"Minimo: {par1} - Massimo: {par2}");

      //con struct
      //TMinMax t1 = MinMax(3,3);
      //Console.WriteLine($"Minimo: {t1.min} - Massimo: {t1.max}");

      //TMinMax t2 = MinMax("Topolino", "Topolina");
      //Console.WriteLine($"Minimo: {t2.min} - Massimo: {t2.max}");

      //con le tuple
      Console.WriteLine("TUPLE");
      
      (IComparable ilMin, IComparable ilMax) r = MinMax(3, 5);

      Console.WriteLine($"Minimo: {r.ilMin} - Massimo: {r.ilMax}");

      (IComparable ilMin, IComparable ilMax) = MinMax(3, 5);
      Console.WriteLine($"Minimo: {ilMin}");

      IComparable ilMinimo = 0, ilMassimo = 0;
      (ilMinimo, ilMassimo) = MinMax(3, 5);
      Console.WriteLine($"Massimo: {ilMassimo}");

      (int soglia, string descrittore) t1 = (2, "Acidità");
      m(t1);

      (int soglia, string descrittore) t2 = t1;
      t2.soglia = 99;
      Console.WriteLine(t1.soglia);

      (int soglia, string descrittore) t3 = (2, "Acidità");
      Console.WriteLine(t1 == t3);

      var t4 = (DateTime.Now.Year, new string("ciao").Length);
      Console.WriteLine(t4.Year + t4.Length);

    }
  }
}
