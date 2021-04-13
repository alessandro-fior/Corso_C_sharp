using System;

namespace Const_Enum
{
  class MyClass
  {
    public const double PiGreco = 3.14;
    public static readonly string VersioneApp;
    public static readonly bool SecurityFlag;

    static MyClass() { VersioneApp = "4.1"; SecurityFlag = true; }
  }

  enum Giorno { Lun=1, Mar, Mer, Gio, Ven, Sab, Dom };

  [Flags]
  enum Illuminazione  { Spento = 0, Giardino = 1,  Garage = Giardino << 1, 
                        Ingresso = Giardino << 2, Cucina = Giardino << 3, 
                        Sala = Giardino << 4, GiardinoGarage = Giardino | Garage
  };

                              

  class Program
  {
    static void M1(Giorno g) { }

    static Giorno G(int giorno)
    {
      if (Enum.IsDefined(typeof(Giorno), giorno))
        return (Giorno)giorno;
      else
        throw new InvalidCastException($"Il valore {giorno} non ha corrispondenze con la enum Giorno");
    }

    static void Main(string[] args)
    {
      Giorno mioCompleanno2021 = Giorno.Sab;
      Console.WriteLine(mioCompleanno2021);

      if (mioCompleanno2021 != Giorno.Dom)
        Console.WriteLine("Quest'anno il tuo compleanno non si sovrapporrà con la Pasqua");

      int n = (int)Giorno.Gio;
      Giorno g1 = (Giorno)6; //sab

      g1 = (Giorno)20;
      Console.WriteLine(g1);

      //g1 = G(20);

      //come ottenere giardino, sala cucina: 0b_0001_1001
      Illuminazione statoLuci = Illuminazione.Giardino | Illuminazione.Sala | Illuminazione.Cucina;
      Console.WriteLine(statoLuci);

      Console.WriteLine(statoLuci & Illuminazione.Giardino);
      Console.WriteLine(statoLuci & Illuminazione.Garage);

      statoLuci |= Illuminazione.Garage;
      Console.WriteLine(statoLuci);

      //Console.WriteLine(MyClass.PiGreco);

      //MyClass obj = new MyClass();
      //Console.WriteLine(obj.VERSIONE_APP);
    }

  }
}
