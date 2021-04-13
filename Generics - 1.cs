using System;
using System.Collections.Generic;

namespace Generics1
{


  class Documento 
  {
    public string Testo { get; set; }
    public Documento(string testo) { Testo = testo; }
    public Documento Clona() { return new Documento("il clone"); }

  }

  class MyList<T>
  {
    int capacita { get; set; } = 2;
    T[] v = null;
    int inseriti = 0;
    public int count { get { return inseriti; } }

    public MyList() { v = new T[capacita];  }

    public void Add(T nuovo)
    {
      //nuovo.
      if (inseriti == capacita) Espandi();
      v[inseriti] = nuovo; inseriti++;

    }

    public void Espandi(int di_quanto = 2)
    {
      T[] nuovo = new T[capacita + di_quanto];
      v.CopyTo(nuovo, 0);
      v = nuovo;
      capacita += di_quanto;       
    }

    public T this [int posizione]
    {
      get { return v[posizione];  }
      set { v[posizione] = value; }
    }
  }


  class Program
  {
    static void Main(string[] args)
    {
      MyList<int> listaInteri = new MyList<int>();

      MyList<string> listaStringhe = new MyList<string>();
      listaStringhe.Add("prima");
      listaStringhe.Add("seconda");
      listaStringhe.Add("terza");

      for (int i = 0; i < listaStringhe.count; i++)
        Console.WriteLine(listaStringhe[i]);


      MyList<Documento> listaDocumenti = new MyList<Documento>();      
    }
  }
}
