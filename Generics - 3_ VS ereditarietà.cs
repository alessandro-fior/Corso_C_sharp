using System;

namespace genericsVSereditarieta
{
  class Program
  {

    class Documento
    {
      public string Testo { get; set; }
      public Documento(string testo) { Testo = testo; }
     
      public override string ToString()
      {
        return Testo;
      }
    }

    class MyList 
    {
      int capacita { get; set; } = 2;
      object[] v = null;
      int inseriti = 0;
      public int count { get { return inseriti; } }

      public MyList() { v = new object[capacita]; }

      public void Add(object nuovo)
      {
        if (inseriti == capacita) Espandi();
        v[inseriti] = nuovo; inseriti++;
      }

      public void Espandi(int di_quanto = 2)
      {
        object[] nuovo = new object[capacita + di_quanto];
        v.CopyTo(nuovo, 0);
        v = nuovo;
        capacita += di_quanto;
      }

      public object this[int posizione]
      {
        get { return v[posizione]; }
        set { v[posizione] = value; }
      }
    }

    class Intruso 
    { 
      
    }

    static void Main(string[] args)
    {
      MyList listaDocumenti = new MyList();
      listaDocumenti.Add(new Documento("doc1"));
      listaDocumenti.Add(new Documento("doc2"));
      listaDocumenti.Add(new Documento("doc3"));
      listaDocumenti.Add(3);
      //listaDocumenti.Add(new Intruso());


      //for (int i = 0; i < listaDocumenti.count; i++)
      //  Console.WriteLine(listaDocumenti[i]);

      Documento d1 = (Documento)listaDocumenti[1];

      object obj = 3;   //boxing
      int n = (int)obj; //unboxing 
    }
  }
}
