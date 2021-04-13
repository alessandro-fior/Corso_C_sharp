using System;
using A.A1.A11;
using Progetto2;

namespace A
{
  interface ISwappable { }

  namespace A1
  {
    namespace A11
    {
      class Vector
      {
        readonly double x = 0;
        public int A { get; set; }

        public Vector() { }
        public void F()
        {        
          
          void G() 
          {
            //I();
            void H() 
            { 

               void I() { }
            }
          
          }


        }
      }
    }
  }
}

namespace ScopingRules
{
  interface ISwappable { }

  class ListaLinkata
  {
    Vector y = new Vector();
    sorgente2 s2 = new sorgente2();

    Classe cl = new Classe();

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
        string s = "ciao";

        //static 
        void MetodoLocale()
        {
          int n = 0;
          {
            while (true)
            {
              string ss = s;
            }

          }
          Console.WriteLine(s);
          Console.WriteLine(data.ToString());
        }

        int n = 0;

        void MetodoLocale2()
        {
          int n = 0;

          Console.WriteLine(s);
        }

        Console.WriteLine(ListaLinkata.desc);
        Console.WriteLine(ll.x);

        
      }
    }
  }


  class Program
  {
    static void Main(string[] args)
    {
      //ListaLinkata.Nodo n = new ListaLinkata.Nodo();

      //int z = 9;

      //{
      //  int i = z;
      //}

      //double x = 4.7;


      //{
      //  int i = 999;
      //}

      //{
      //  int j = 999;
      //}

      ////int m = 20;

      //switch (z)
      //{
      //  case 1:
      //    {
      //      int m = 9;
      //    }
      //  break;

      //  case 2:
      //    {
      //      int m = 9;
      //    }

      //    break;
      //}

      //int n = 8;

      if (true)
      {
        int n = 100;

        if (true)
        {
          //int k;
          //int z;
          //int n = 0; //int i = 10; NO conflitto con la n esterna 
        }
        {
          //int z;
          //z = 4000;
        }

        int k;
      }
      else
      {
        //int n = 300;

        while (true)
        {
          //int n = 6;
        }
      }

      int z;

      while (true)
      {
        
        int n = 0;
        break;

      }

      for (int n = 0; n < 100; n++)
      {
        
      }

      //double args = 0.0; 

    }
  }
}
