using System;

namespace ScopingRules
{
  
  class ListaLinkata
  {

    Nodo head = null;
    double x = 3.8;
    static string desc = "V 1.1";
    

    public void AggiungiInTesta(Nodo nuovo) { }
    public void AggiungiInCoda(Nodo nuovo) { }
    public Nodo EstraiTesta() { return null; }

    public void F(Nodo n) { }
    
    public class Nodo
    {
      internal object data = null;
      internal Nodo next = null;

      public Nodo() { }

      public void F(ListaLinkata ll)
      {
 

        Console.WriteLine(ListaLinkata.desc);
        Console.WriteLine(ll.x);
        
      }
    }
  }


  class Program
  {
    static void Main(string[] args)
    {
      ListaLinkata.Nodo n = new ListaLinkata.Nodo();

      int z = 9;

      {
        int i = z;
      }

     /double x = 4.7;


      {
       int i = 999;
      }

      {
       int j = 999;
      }

     int m = 20;

      switch (z)
      {
        case 1:
          {
            int m = 9;
          }
        break;

        case 2:
          {
            int m = 9;
          }

          break;
      }

    }
  }
}
