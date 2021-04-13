using System;

namespace OOP5_Cerchio
{
 
  class Punto
  {
    public double X { get; set; } = 0;
    public double Y { get; set; } = 0;

    public Punto( double x, double y) { X = x; Y = y; }
  }

  class Cerchio
  {

    public Punto Centro { get; set; } = new Punto(0, 0);
    public int Colore { get; set; } = 0; //default = nero
    public int Spessore { get; set; } = 1;

    private double raggio = 1;
    public double Raggio { 
      get => raggio;
      set {
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

    public Cerchio() { }

    public double Perimetro() { return 2 * Math.PI * raggio; }
    public double Area() { return Math.PI * raggio * raggio; } // o * Math.Pow(raggio,2)
          
  }
  class Program
  {
    static void Main(string[] args)
    {
      Cerchio c1 = new Cerchio(3, -2, 4) {Colore = 0x0000FF, Spessore = 2 };
      Cerchio c1bis = new Cerchio ( x: 3, y:-2, r: 4) {Colore = 0x0000FF, Spessore = 2 };
      Cerchio c2 = new Cerchio() { Centro=new Punto(3, -2), Raggio=4, Colore = 0x0000FF, Spessore = 2 };
      
      Console.WriteLine($"Perimetro di c1={c1.Perimetro()}, area di c2={c2.Area()}");

      Punto x1 = new Punto(3, 8);
      Cerchio c3 = new Cerchio(x1.X, x1.Y, 4);
      //Cerchio c4 = new Cerchio(x1, 4);

    }
  }
}
