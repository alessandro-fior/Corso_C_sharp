using System;

namespace oop_3_properties_B
{
  class Libro
  {
    //private string titolo = "I promessi sposi";
    public readonly string autore = "Manzoni";

    //public string Titolo
    //{
    //  private get => titolo;
    //  set => titolo = value;
    //}
    private double costoSenzaIva = 12.9;
    private int IVA = 4;

    public double CostoIvaInclusa => CostoSenzaIva * (1 + IVA / 100);
    

    public string Titolo { get; private set; } = "I promessi sposi";
    public string Autore { get => autore; } // NO field read only ... set => autore = value; }
    public double CostoSenzaIva { get => costoSenzaIva; set => costoSenzaIva = value; }
  }

    class Program
  {
    static void Main(string[] args)
    {
      Libro l = new Libro();
      //l.Titolo = "ciaco"; //NO: la property è read only all`esterno della classe

      Console.WriteLine(l.autore);

      //l.SetCostoSenzaIva(15.2);
    }
  }
}
