using System;

namespace Lambda1
{

  class SecuritySystem
  {
    Func<int> Allerta = null;

    public SecuritySystem(Func<int> g)
    {
      Allerta = g;
    }

    public void SetAllarmeSupplementare(Func<int> allarmeSupplementare)
    {
      Allerta += allarmeSupplementare; //LISTA DI RIFERIMENTI A METODI!
    }

    public void Allarme()
    {
      Console.WriteLine(Allerta());
    }
  }
  class Program
  {
    static void UnTipoDiLog(string dati)
    { Console.WriteLine(dati); }

    static void UnAltroTipoDiLog(string dati)
    { Console.WriteLine($"----- {dati} ----------"); }

    static double ScontoStandard(double cifra)
    { return cifra / 100 * 5; }

    static Func<int, int> MetodoFunc()
    {
      int IWillSurvive = 100;
      return x => { IWillSurvive++; return IWillSurvive * x; };
    }
    
    static void Main(string[] args)
    {
      //Func<int, int> Fattoriale = () => x==0 ? 1 : x * 

      Func<int, int> F = MetodoFunc();
      Console.WriteLine(F(3));
      Console.WriteLine(F(3));

      string messaggio = "Admin Avvisato";
      int id = 100;

      SecuritySystem sec = new SecuritySystem( () => { 
        Console.WriteLine(messaggio); return id;
      });

      messaggio = "Autorità competenti avvisate!";
      id = 200;

      sec.SetAllarmeSupplementare(() =>
      {
        Console.WriteLine(messaggio); return id;
      });

      sec.Allarme();

      int n = 100;
      Func<int, int> Quadrato = (int x) => { n++; return x * x; };
      Console.WriteLine(Quadrato(6));
      Console.WriteLine(n);

      Func<int>[] Funzioni = new Func<int>[4];
      int i = 0;
      for (i = 0; i < 4; i++)
      {
        int local_i = i;
        Funzioni[local_i] = () =>  local_i * local_i;
      }

      //qui la i vale 4

      foreach (Func<int> f in Funzioni) Console.WriteLine(f());
      Console.WriteLine(Funzioni[1]());


    }
  }
}
