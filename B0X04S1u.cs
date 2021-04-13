using System;

namespace OOP_4_Costruttori_1
{
  class Data
  {// membri interni

    static string[] nomiMese = {"Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno",
                        "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"};
    
    //field
    private int g=1;
    private int m=1;
    private int a=1;



    public Data(int _g, int _m, int _a) {
      A = _a; M = _m; G = _g;
    }
    
    
    public Data() : this(1,1,1) { }

    static int MeseInt(string mm) 
    { 
      return Array.IndexOf(nomiMese, Char.ToUpper(mm[0]) + mm.Substring(1).ToLower()) + 1; 
    }

    public Data(int gg, string mm, int aa) : this(gg, MeseInt(mm), aa) { }

    public Data(string laData)
    {
      //accettiamo giorni e mesi a una o due cifre, anno a due o 4 cifre
      //int posTrattino = laData.IndexOf('-');
      //if (posTrattino == -1) throw new InvalidOperationException("Formato data non valido");
      //string g  = laData.Substring(0, posTrattino); //"1O-10-19"

      //posTrattino = laData.IndexOf('-', posTrattino + 1);
      //if (posTrattino == -1) throw new InvalidOperationException("Formato data non valido");
      //string m = laData.Substring(g.Length + 1, posTrattino - g.Length - 1); //"10-10-19"
      //string a = laData.Substring(posTrattino + 1, laData.Length - posTrattino - 1); //"10-10-19"

      //A = int.Parse(a);
      //M = int.Parse(m);
      //G = int.Parse(g);


      string[] n = laData.Split('-');
      if (n.Length != 3 || n[0].Length == 0 || n[1].Length == 0 || n[2].Length != 4) 
         throw new InvalidOperationException();
      A = int.Parse(n[2]);
      M = int.Parse(n[1]);
      G = int.Parse(n[0]);
    }
    
    public int G
    {
      get => g;
      set
      {
        if (value > GiorniMese() || value < 1)
          throw new InvalidOperationException("Valore giorno non valido");
        else g = value;
      }
    }

    public int M
    {
      get => m;
      set
      {
        if (value > 12 || value < 1)
          throw new InvalidOperationException("Valore mese non valido");
        else m = value;
      }
    }

    public int A
    {
      get => a;
      set
      {
        if (value < 1)
          throw new InvalidOperationException("L'anno non può essere minore di 1");
        else a = value;
      }
    }


    //metodi

    int GiorniMese() //parametri formali
    {
      switch (m)
      {
        case 4:
        case 6:
        case 9:
        case 11:
          return 30;

        case 2:
          return 28 + (a % 400 == 0 || (a % 4 == 0 && a % 100 != 0) ? 1 : 0);

        default:
          return 31;
      }
    }

    public void SettaData(int gg, int mm, int aa )
    {
      G = gg; M = mm; A = aa;
    }

    override public string ToString()
    {
      return $"{G}-{M}-{A}";
    }

  }
  class Program
  {
    static void Main(string[] args)
    {
      Data d = new Data(15,10,10);

      try
      {
        Data d2 = new Data("29-2-2019");
      }
      catch (InvalidOperationException errore)
      {
        Console.WriteLine(errore.Message);
      }

     Data d3 = new Data(15, "", 2020);
     Console.WriteLine(d3);

      //d.SettaData(15, 10, 10);


      //Console.WriteLine(d);

      //Cerchio c = new Cerchio(???);
      //Console.WriteLine(c.Area()/Perimetro())

      //GeneratorePassword g = new GeneratorePassword(???)
      //string psw = g.Genera(???);
    }
  }
}
