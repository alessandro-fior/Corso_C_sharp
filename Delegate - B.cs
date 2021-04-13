using System;

namespace delegate_1
{

  //delegate void LogDelegate(string dati);
  class Cliente {
    public int matricola { get; set; }  = 2345;
    public void MetodoCliente(string s) { Console.WriteLine($"Metodo di un cliente: {s}"); }
  }

  class Transazione
  {
    Action<String> metodoLog = null;


    public Transazione(Action<String> metodo)
    { metodoLog = metodo; }

    public void RichiedeControllo()
    {
      Controllo();
    }
    
    public double Contabilizza(double acconto, 
                               Func<double, double> sconto,
                               Predicate<Cliente> HaDirittoSconto)
    { return HaDirittoSconto(new Cliente() ) ? acconto - sconto(acconto) : acconto; }


    void Controllo()
    {
      bool condizione = true;
      // ... controlli

      if (condizione) 
        metodoLog("dati");

      Console.WriteLine(((Cliente)metodoLog.Target).matricola);
    }

   }

 

  //I DELEGATE SONO MULTICAST
  public delegate int GestoreAllarmi();

  class SecuritySystem
  {
    private GestoreAllarmi Allerta = null;

    public SecuritySystem(GestoreAllarmi g)
    {
      Allerta = g;
    }

    public void SetAllarmeSupplementare(GestoreAllarmi allarmeSupplementare)
    {
      Allerta += allarmeSupplementare; //LISTA DI RIFERIMENTI A METODI!
    }

    public void Allarme()
    {
      Console.WriteLine(Allerta());
    }
  }

  public delegate void ClickHandler();

  class MyButton
  {
    public event ClickHandler Click; 

    public void Clicca() //simula il click sul bottone
    {
      //invoca tutti i metodi degli oggetti che sono interessati
      //a fare qualche cosa quando questo bottone viene cliccato
      Click();
    }
  }

  class Form1
  {
    public void MetodoForm1() 
    { Console.WriteLine("oggetto di classe Form1 ha ricevuto la notifica!"); }
  }

  class Form2
  {
    public void MetodoForm2()
    { Console.WriteLine("oggetto di classe Form2 ha ricevuto la notifica!"); }
  }

  class Program
  {
    static void UnTipoDiLog(string dati)
    { Console.WriteLine(dati);}
     
    static void UnAltroTipoDiLog(string dati)
    { Console.WriteLine($"----- {dati} ----------"); }

    static double ScontoStandard(double cifra)
    { return cifra / 100 * 5; }

    static bool ValutaClientePerSconto(Cliente ilCliente)
    { return true; }
    
    static int  AllertaAdmin() { Console.WriteLine("Admin avvisato!"); return 100; }
    static int  AllertaAutorita() { Console.WriteLine("Autorità competenti avvisate!"); return 200;}

    static void Main(string[] args)
    {

      Transazione tipo1 = new Transazione(UnTipoDiLog);
      Transazione tipo2 = new Transazione(UnAltroTipoDiLog);
      Transazione tipo3 = new Transazione( (new Cliente()).MetodoCliente);

      //tipo1.RichiedeControllo();
      //tipo2.RichiedeControllo();
      //Console.WriteLine(tipo2.Contabilizza(230.5, ScontoStandard, ValutaClientePerSconto));

      //tipo3.RichiedeControllo();

      //SecuritySystem sec = new SecuritySystem(AllertaAdmin);     
      //sec.SetAllarmeSupplementare(AllertaAutorita);

      //sec.Allarme();

      MyButton button = new MyButton();

      Form1 form1 = new Form1();
      Form2 form2 = new Form2();

      //iscriviamo i due oggetti per ricevere notifiche dal bottone
      button.Click += form1.MetodoForm1;
      button.Click += form2.MetodoForm2;

      //clicchiamo il bottone
      button.Clicca();



    }
  }
}
