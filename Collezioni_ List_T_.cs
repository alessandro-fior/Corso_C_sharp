using System;
using System.Collections.Generic;

namespace Collezioni_List_LinkedList
{
  class Cliente : IComparable
  {
    public string Cognome { get; set; }
    public int Eta { get; set; }
    public Cliente(string cognome, int eta) { Cognome = cognome; Eta = eta; }

    public override bool Equals(Object obj)
    {
      Cliente c = obj as Cliente;
      return c.Cognome == this.Cognome;
    }

    public int CompareTo(object obj)
    {
      return Eta.CompareTo((obj as Cliente).Eta);
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      List<string> elencoStringhe = new List<string> { "Verdi", "Rossi", "Bianchi"};
      List<Cliente> elencoClienti = new List<Cliente> 
          {new ("Verdi", 67), new ("Rossi", 19), new ("Bianchi", 41) };

      //Aggiungere elementi singolarmente
      elencoStringhe.Add("Gialli");
      elencoClienti.Add(new("Gialli", 81));

      //Aggiungere elementi a blocchi
      elencoStringhe.AddRange(new[] { "Arancioni", "Viola"});
      elencoClienti.AddRange(new Cliente[] { new ("Arancioni", 15), new ("Viola", 19) });

      //Aggiungere elementi in un punto intermedio
      elencoStringhe.Insert(0, "ciao"); //o con InsertRange

      //Rimuovere elementi
        //elencoStringhe.Remove("Rossi");
        //elencoClienti.Remove( new("Rossi", 19) );
        //elencoStringhe.RemoveRange(1, 2);
        //elencoClienti.RemoveAt(1);
        //elencoStringhe.RemoveAll(x => x.Length < 7);
      //elencoStringhe.Clear();

      //Console.WriteLine(elencoStringhe[2]);

      var intervallo = elencoStringhe.GetRange(0, 2);
      var estratti = elencoClienti.GetRange(0, 2);
      estratti[0].Cognome = "XXX";
      Console.WriteLine(elencoClienti[0].Cognome);


    }
  }
}
