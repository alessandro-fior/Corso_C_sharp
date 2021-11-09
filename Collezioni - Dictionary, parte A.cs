using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Dictionary
{
  class Amico
  {
    public String Nome { get; set; }
    public String Telefono { get; set; }

    public Amico(string nome, string telefono)
    { Nome = nome; Telefono = telefono; }
  }

  class Gioco
  {
    public String Nome { get; set; }
    public int etaConsigliata { get; set; }

    public Gioco(string nome, int eta)
    { Nome = nome; etaConsigliata = eta; }
  }

  class Program
  {
    
    static void Main()
    {
      List<KeyValuePair<string, Amico>> listaAmici = new();
      listaAmici.Add(new KeyValuePair<string, Amico>("Giorgio", new Amico("Giorgio", "0345-82347")));
      listaAmici.Add(new KeyValuePair<string, Amico>("Massimo", new Amico("Massimo", "0345-234643")));

      Dictionary<String, Amico> amici = new(listaAmici); 

      Console.WriteLine( amici.TryAdd("Giorgio", new Amico("Giorgio", "02-82347")) );

      amici["Giorgio"] = new Amico("Giorgio", "02-82347");
      Console.WriteLine(amici["Giorgio"].Telefono);

      Dictionary<Gioco, Amico> abbinamenti = new();
      //Gioco g = new Gioco("Tennis", 12);
      abbinamenti.Add(new Gioco("Tennis", 12), amici["Massimo"]);
      
      Console.WriteLine(abbinamenti.ContainsKey(new Gioco("Tennis", 12)));
    }
  }
}
