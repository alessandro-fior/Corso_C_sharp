using System;

namespace Ereditarieta_conto_corrente
{
  class ContoCorrenteException : Exception
  {
    public ContoCorrenteException(string messaggio) { }
  }

  class ContoCorrente
  {
    //dati intestatario
    public String Cognome { get; set; } = "";
    public String Nome { get; set; } = "";

    //dati conto

    public string TipoConto { get; set; } = "normale";
    private double saldo = 0;
    private int NumeroConto { get; set; }
    public static int ProgressivoNumeroConto { get; set; } = 0;
    
    //operazioni sul conto
    public void SetSaldo(double nuovoSaldo)
    {
      if (nuovoSaldo >= 0)
        saldo = nuovoSaldo;
      else throw new ContoCorrenteException("Saldo negativo");
    }

    public void Deposita(double cifra)
    {
      if (cifra > 0)
        saldo += cifra;
      else throw new ContoCorrenteException($"Valore deposito non valido: {cifra}");
    }

    public bool Preleva(double cifra)
    {
      if (saldo >= cifra || TipoConto=="privilegiato")
      {
        saldo -= cifra;
        return true;
      }
      else return false;
    }

    //costruttore
    public ContoCorrente(string tipoConto, string cognome, string nome, double saldo_iniziale=0)
    {
      TipoConto = tipoConto; //normale oppure privilegiato

      Cognome = cognome; Nome = nome;
      SetSaldo(saldo_iniziale);
      NumeroConto = ++ProgressivoNumeroConto;
    }
  }
  
  class Madre
  {
    public Madre() { Console.WriteLine("Classe Madre"); }
  }

  class Figlia : Madre
  {
    
  }

  class Program
  {
    static void Main(string[] args)
    {
      
      ContoCorrente c1 = new ContoCorrente("privilegiato", "Gastone", "Paperone", 100);
      //c1.Deposita(-9);
      //Figlia f = new Figlia();

      if (c1.Preleva(101))
        Console.WriteLine("ok");
      else
        Console.WriteLine("Non puoi andare in rosso!");

       
    }
  }
}
