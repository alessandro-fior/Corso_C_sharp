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
    protected double saldo = 0;
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
      if (saldo >= cifra)
      {
        saldo -= cifra;
        return true;
      }
      else return false;
    }

    //costruttore
    public ContoCorrente(string cognome, string nome, double saldo_iniziale = 0)
    {
      Cognome = cognome; Nome = nome;
      SetSaldo(saldo_iniziale);
      NumeroConto = ++ProgressivoNumeroConto;
    }
  }

  class ContoCorrentePrivilegiato : ContoCorrente
  {
    private double tolleranza = 0;
    public double Tolleranza {
      get { return tolleranza; }

      set {
        if (value >= 0) tolleranza = value; else throw new ContoCorrenteException("Tolleranza negativa"); 

      } 
    }

    public ContoCorrentePrivilegiato(string Cognome, string Nome, double tolleranza, double saldo_iniziale = 0) 
      : base(Cognome, Nome)
    {
      Tolleranza = tolleranza;

    }

    public bool Preleva(double cifra)
    {

      if (cifra - saldo <= tolleranza)
      {
        saldo -= cifra;
        return true;
      }
      else return false;

    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      
      //ContoCorrente c1 = new ContoCorrente("Gastone", "Paperone", 100);
      //c1.Deposita(-9);
      //Figlia f = new Figlia();

      //if (c1.Preleva(101))
      //  Console.WriteLine("ok");
      //else
      //  Console.WriteLine("Non puoi andare in rosso!");

      ContoCorrentePrivilegiato cpriv1 = 
        new ContoCorrentePrivilegiato("super", "boss", 5000, 1000000);

      cpriv1.Deposita(1000);
      Console.WriteLine(cpriv1.Preleva(5500));

      cpriv1.Preleva(10000);
       
    }
  }
}
