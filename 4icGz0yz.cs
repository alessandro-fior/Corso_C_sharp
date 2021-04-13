using System;

namespace OOP_4_Costruttori_1
{
  class Data
  {// membri interni

    //field
    private int g;
    private int m;
    private int a;

    public Data(int _g, int _m, int _a) {

      G = _g; M = _m; A = _a;
    }
    
    
    public Data() { }

    public Data(string laData)
    {
      //accettiamo giorni e mesi a una o due cifre, anno a due o 4 cifre
      int posTrattino = laData.IndexOf('-');
      if (posTrattino == -1) throw new InvalidOperationException("Formato data non valido");

      string g = laData.Substring(0, posTrattino); //"1O-10-19"
      G = int.Parse(g);

      posTrattino = laData.IndexOf('-', posTrattino+1);
      if (posTrattino == -1) throw new InvalidOperationException("Formato data non valido");

      string m = laData.Substring(g.Length+1, posTrattino-g.Length-1); //"10-10-19"
      M = int.Parse(m);

      string a = laData.Substring(posTrattino+1, laData.Length - posTrattino - 1); //"10-10-19"
      A = int.Parse(a);
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

     Data d2 = new Data("1-7-2020");
     //Data d3 = new Data(15, "Ottobre", 20);

      //d.SettaData(15, 10, 10);


      //Console.WriteLine(d);

      //Cerchio c = new Cerchio(???);
      //Console.WriteLine(c.Area()/Perimetro())

      //GeneratorePassword g = new GeneratorePassword(???)
      //string psw = g.Genera(???);
    }
  }
}
