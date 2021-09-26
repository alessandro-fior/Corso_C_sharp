using System;

namespace Collezioni_B_Array
{
  class Cliente
  {
    public string Cognome { get; set; }
    public int Eta { get; set; }
    public Cliente(string cognome, int eta) { Cognome = cognome; Eta = eta; }

    public override bool Equals(Object obj)
    {
      Cliente c = obj as Cliente;
      return c.Cognome == this.Cognome;
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      string[] elenco = { "Verdi", "Rossi", "Oboli", "Bianchi", "Sella", "Zanna", "Oboli", "Crespella", "Anione"};
      
      //Console.WriteLine(Array.IndexOf(elenco, "Oboli"));
     
      int ultimaPosizione = -1;
      //do
      //{
      //  ultimaPosizione = Array.IndexOf(elenco, "Oboli", ultimaPosizione+);
      //  if (ultimaPosizione != -1) Console.WriteLine(ultimaPosizione);
      //} while (ultimaPosizione != -1);

      //Console.WriteLine(Array.IndexOf(elenco, "Oboli", 3, 3)); //non trovato
      //Console.WriteLine(Array.IndexOf(elenco, "Oboli", 3, 4)); //trovato

      //Console.WriteLine(Array.IndexOf<String>(elenco, 123)); 
      //Console.WriteLine(Array.IndexOf(elenco, 123));

      //Console.WriteLine(Array.LastIndexOf(elenco, "Oboli"));


      Cliente[] clienti = {
        new ("Verdi", 45) , new ("Rossi", 19) , new ("Oboli", 35) , new ("Bianchi", 43) ,
        new ("Sella", 15) , new ("Zanna", 71) , new ("Oboli", 23) , new ("Crespella", 61) ,
        new ("Anione", 33) };

      //Cliente c1 = new("Zanna", 71);
      //Console.WriteLine(Array.IndexOf(clienti, c1));
      var clienteTrovato = Array.Find(clienti, x => x.Cognome == "Oboli");
      Console.WriteLine(clienteTrovato.Eta);

    }
  }
}
