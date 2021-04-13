using System;

namespace interfacce_1
{

  class Program
  {
    static void Main(string[] args)
    {
      Allarme obj = new Allarme(new GestoreMessaggistica());
      Allarme objPEC = new Allarme(new PEC());

      obj.Notifica();
      objPEC.Notifica();
    }
  }

  
  interface ISendEmail
  {
    void InviaEmail(string indirizzoMail, string oggetto, string testoMail);
  }

  class GestoreMessaggistica : ISendEmail
  {
    public void InviaEmail(string indirizzoMail, string oggetto, string testoMail) 
    { Console.WriteLine("Email inviata"); }
  }

  class PEC : ISendEmail
  {
    public void InviaEmail(string indirizzoMail, string oggetto, string testoMail)
    { Console.WriteLine("Email PEC inviata"); }
  }

  class Allarme
  {
    ISendEmail gestoreEmail = null;

    public Allarme(ISendEmail gestore) {
      gestoreEmail = gestore;
    }

    public void Notifica()
    {
      gestoreEmail.InviaEmail("fcamuso@gmail.com", "test", "questo è un test");
    }
  }

  //COMPOSIZIONE SENZA INTERFACCE: meno problemi ma si può ancora migliorare!
  //class GestoreMessaggistica
  //{
  //  public void InviaEmail(string indirizzoMail, string oggetto, string testoMail) { }
  //}

  //class Allarme
  //{
  //  GestoreMessaggistica gestoreMessaggistica = new GestoreMessaggistica();

  //  void Notifica()
  //  {
  //    //...
  //    gestoreMessaggistica.InviaEmail("fcamuso@gmail.com", "test", "questo è un test");
  //  }
  //}
  // ************************************************************************************


  //NO! Cattivo esempio di ereditarietà
  //class Allarme : GestoreMessaggistica
  //{
  //  //public void InviaEmail(string indirizzoMail, string oggetto, string testoMail) { }


  //}














  abstract class Conto
  {
    public long NumeroConto { get; set; } = 0;
    abstract public double InteresseAnnuo { get; set; }
    abstract public void Preleva(decimal value);
  }

  class ContoCorrente : Conto
  {
    private double interesseAnnuo = 0;
    public override double InteresseAnnuo { 
      get => interesseAnnuo;
      set { 
        //logica che lo determina in base al tipo di cliente,
        //operatività prevista sul conto e altre variabili
      } }

    public override void Preleva(decimal value)
    {
      Console.WriteLine("Prelievo da un conto corrente");
    }
  }

  class ContoDeposito : Conto
  {
    private double interesseAnnuo = 0;
    public override double InteresseAnnuo
    {
      get => interesseAnnuo;
      set
      {
        //logica che lo determina in base al tipo di cliente,
        //operatività prevista sul conto e altre variabili
      }
    }

    public override void Preleva(decimal value)
    {
      Console.WriteLine("Prelievo da un conto deposito");
    }
  }

}
