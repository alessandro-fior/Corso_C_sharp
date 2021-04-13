using System;

namespace interfacce_1
{

  class Program
  {
    static void Main(string[] args)
    {
      Allarme obj = new Allarme(new GestoreMessaggistica());
      Allarme objPEC = new Allarme(new PEC());

      //obj.Notifica();
      //objPEC.Notifica();

      PEC unaPec = new PEC();
      ((IPrintable) unaPec).Descrivi();
      ((IEmail)unaPec).Descrivi();

      ((IPrintable)unaPec).Setup();
      ((IEmail)unaPec).Setup();

      
      //solo se pubblici nell`interface
      //Console.WriteLine($"{IPrintable.LoadOEMData()} - {IPrintable.versioneDriver}");
    }
  }

  interface IPrintable {

    private static string versioneDriver = "1.07";
    private static string LoadOEMData() { return "Dati OEM"; }

    bool Setup();

    void Print();
    void Descrivi() => Console.WriteLine($"{versioneDriver} da IPrintable; {LoadOEMData()}");
  }

  interface IPrintable3D : IPrintable
  {
    void Print3D();
  }

  interface IEmail
  {
    bool Setup();

    void InviaEmail(string indirizzoMail, string oggetto, string testoMail);
    void Descrivi() => Console.WriteLine("Descrizione dettagliata non disponibile");
  }

  class GestoreMessaggistica : IEmail
  {
    public void InviaEmail(string indirizzoMail, string oggetto, string testoMail)
    { Console.WriteLine("Email inviata"); }

    public void Descrivi() => Console.WriteLine("Protocolli supportati: bla bla bla");
    public bool Setup() { Console.WriteLine("Setup Gestore Messaggistica"); return true; }

  }

  class PEC : IEmail, IPrintable
  {
    bool IEmail.Setup() { Console.WriteLine("Setup PEC - IEmail"); return true; }
    bool IPrintable.Setup() { Console.WriteLine("Setup PEC - IPrintable"); return true; }

    public virtual void InviaEmail(string indirizzoMail, string oggetto, string testoMail)
    { Console.WriteLine("Email PEC inviata"); }

    public void Print() { }
  }

  class PECLevel2 : PEC
  {
    public override void InviaEmail(string indirizzoMail, string oggetto, string testoMail)
    { Console.WriteLine("Email PEC inviata"); }

    public new void Print() { Console.WriteLine("Metodo reimplementato"); }
  }

  class Allarme
  {
    IEmail gestoreEmail = null;

    public Allarme(IEmail gestore) {
      gestoreEmail = gestore;
    }

    public void Notifica()
    {
      gestoreEmail.Setup();

      //gestoreEmail.InviaEmail("fcamuso@gmail.com", "test", "questo è un test");
      //gestoreEmail.Descrivi();

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
