using System;
using System.Collections.Generic;

namespace indexers
{
  class Cliente
  {
    public string Cognome { get; set; }
    public string Nome { get; set; }

    public Cliente(string cognome, string nome)
    {
      Cognome = cognome; Nome = nome;
    }
  }

  struct AccessoAgente
  {
    public int Indice { get; set; }
    public string PassCode { get; set; }

    public AccessoAgente(int i, string psw) { Indice = i; PassCode = psw; }


  }

  class AgenteDiZona
  {
    string passCode = "xyz";

    //dati anagrafici che salto per brevità...
    List<Cliente> clienti = new List<Cliente>();

    public Cliente this[AccessoAgente accesso]
    {
      get
      {
        if (accesso.PassCode == passCode) 
          return clienti[accesso.Indice];
        else
          return new Cliente("Accesso Negato", "");
      }
    }
    
    public Cliente this[int indice]
    {
      get
      { if (indice < clienti.Count)
          return clienti[indice];
        else
          return new Cliente("Errore! Indice fuori dai limiti", "");
      }

      set
      {
        if (indice < clienti.Count)  //modifica esistente
          clienti[indice] = value;
        else //aggiunta di uno nuovo
          clienti.Add(value);
      }
    }

    public void stampaClienti()
    { foreach (Cliente c in clienti) { Console.WriteLine(c.Cognome); } }
  }

  class Program
  {
    static void Main(string[] args)
    {
      AgenteDiZona agente = new AgenteDiZona();
      
      //inserimento di nuovi clienti
      agente[0] = new Cliente("Rossi", "Mario");
      agente[1] = new Cliente("Verdi", "Giovanni");
      agente[2] = new Cliente("Gialli", "Sandro");

      agente.stampaClienti();

      //modifica del secondo
      agente[1] = new Cliente("Neri", "Giorgio");

      Console.WriteLine("dopo la modifica:");
      agente.stampaClienti();

      Console.WriteLine(agente[10].Cognome);
      Console.WriteLine(agente[new AccessoAgente(2, "uwd")].Cognome);
      Console.WriteLine(agente[new AccessoAgente(2, "xyz")].Cognome);


    }
  }
}
