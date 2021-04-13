using System;

namespace OOP_decostruttori
{
  class Triangolo
  {
    private double lato1 = 0, lato2 = 0, lato3 = 0;

    public double Lato1 { get => lato1; set => lato1 = value; }
    public double Lato2 { get => lato2; set => lato2 = value; }
    public double Lato3 { get => lato3; set => lato3 = value; }

    public Triangolo(double lato1, double lato2, double lato3) {
      this.lato1 = lato1; this.lato2 = lato3;
    }

    //decostruttore
    public void Deconstruct (out double l1, out double l2, out double l3)
    {
      l1 = lato1; l2 = lato2; l3 = lato3;
    }

    public Triangolo PerimetroMax(Triangolo t) {
      if (lato1 + lato2 + lato3 > t.lato1 + t.lato2 + t.lato3)
        return this;
      else
        return t;
    }
     
  }

  class Program
  {
    static void Main(string[] args)
    {
      Triangolo t1 = new Triangolo(10, 15, 10);
      Triangolo t2 = new Triangolo(3, 4, 5);

      Console.WriteLine(t1.PerimetroMax(t2).Lato1);

      var (l1, l2, l3) = t2;
      Console.WriteLine(l2);
    }
  }
}
