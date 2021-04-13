using System;

namespace Generics2
{
  class C<T> 
  {
    public static string Membro_statico { get; set; } = "";

    void F()
    {
      T[] elenco = new T[100];

      for (int i = 0; i < elenco.Length; i++) elenco[i] = default;
    }
  }

  class Cliente : IComparable
  {
    public string ragioneSociale { get; set; }
    
    public int CompareTo(object altro)
    {
      if (ragioneSociale.Length < ((Cliente)altro).ragioneSociale.Length)
        return -1;
      else
        if (ragioneSociale.Length == ((Cliente)altro).ragioneSociale.Length)
          return 0;
        else
          return 1;
    }
  }

  class Program
  {
    static T ValoreMassimo<T>(T[] v) where T: IComparable
    {
      T massimo = v[0];
      for (int i = 1; i < v.Length; i++)
        if (v[i].CompareTo(massimo)>0) massimo = v[i];

      return massimo;
    }

    static void Scambia<T>(ref T a, ref T b)
    {
      T temp = a;
      a = b;
      b = temp;
    }

    static void Main(string[] args)
    {
      C<int>.Membro_statico = "Ciao";
      C<bool>.Membro_statico = "Mondo";

      int x = 100, y = 200;
      Scambia(ref x, ref y);
      Console.WriteLine($"{x} - {y}");

      string s1 = "ciao", s2 = "mondo";
      Scambia(ref s1, ref s2);
      Console.WriteLine($"{s1} - {s2}");

      Cliente c1 = new Cliente(); c1.ragioneSociale = "Ernesto";
      Cliente c2 = new Cliente(); c2.ragioneSociale = "Sparalesto";
      Scambia(ref c1, ref c2);
      Console.WriteLine($"{c1.ragioneSociale} - {c2.ragioneSociale}");

      string[] v = new string[] { "a", "z", "m", "n" };
      Console.WriteLine($"Valore massimo nell'array: {ValoreMassimo(v)}");

      Cliente[] vcliente = new Cliente[] { c1, c2 };
      Console.WriteLine($"Valore massimo nell'array: {ValoreMassimo(vcliente).ragioneSociale}");

    }
  }








  class Derivata1<Txxx, T2> : C<Txxx>
  { 
  
  }
 
  class Derivata2 : C<int>
  {

  }
  
  

}
