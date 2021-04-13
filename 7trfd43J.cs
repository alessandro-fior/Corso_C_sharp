using System;
using System.Drawing;

namespace OOP6_Struct
{
  struct Punto
  {
    //private int n = 9; NO: field e property non possono avere inizializzatori

    public  double X { get; set; }
    public  double Y { get; set; }

    //public string Nome { get; set; } NO! non mischiare value type con reference type; SOLO value type

    //public Punto() { } //VIETATO
    public Punto(double x, double y) { X = x; Y = x; } // Nome = "topolino"; }
    //public void f() { X = 12; }
  }

  class Cerchio
  {
    public Punto Centro { get; set; } = new Punto(0,0);
    public int Colore { get; set; } = 0; //default = nero
    public int Spessore { get; set; } = 1;

    private double raggio = 1;
    public double Raggio
    {
      get => raggio;
      set
      {
        if (value > 0)
          raggio = value;
        else
          throw new ArgumentOutOfRangeException("Il raggio deve essere maggiore di zero");
      }
    }

    public Cerchio(double x, double y, double r)
    {
      Centro = new Punto(x, y);
      Raggio = r;
    }

    public Cerchio() { raggio = 500; }

    public Cerchio(Punto p, double r) //: this(p.X, p.Y, r) {}
    {
   
      Centro = p;

      p = new Punto(-34, p.Y);
      //p.X = -34;
      //Centro.X = -34;


      p = new Punto(777, 777);
    }

    public double Perimetro() { return 2 * Math.PI * raggio; }
    public double Area() { return Math.PI * raggio * raggio; } // o * Math.Pow(raggio,2)

  }
  class Program
  {
    static void Main(string[] args)
    {
      Point pp = new Point(3, 4);
      pp.X = 89;
      
      Punto p = new Punto(3, 4);
      Cerchio c = new Cerchio(p, 6);
      
      //la modifica al punto nel costruttore del cerchio NON
      //modifica il punto esterno
      Console.WriteLine(p.X); //3 e non 777

      //il cerchio ha ora una sua copia del punto esterno
      //e modificare quest`ultimo non sporca il cerchio
      p = new Punto(-10, -10);
      Console.WriteLine(c.Centro.X); //sempre 3 e non -10

    }
  }
}
