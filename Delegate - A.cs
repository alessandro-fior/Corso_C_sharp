using System;

namespace delegate_1
{

  //delegate void LogDelegate(string dati);

  class Transazione
  {
    LogDelegate metodoLog = null;
    
    public Transazione(LogDelegate metodo  ) 

    { metodoLog = metodo; }

    public void RichiedeControllo()
    {
      Controllo();
    }
    
    void Controllo()
    {
      bool condizione = true;
      // ... controlli

      if (condizione) 
        metodoLog("dati");
    }

   }


  class Program
  {
    static void UnTipoDiLog(string dati)
    { Console.WriteLine(dati);}
     
    static void UnAltroTipoDiLog(string dati)
    { Console.WriteLine($"----- {dati} ----------"); }

    static void Main(string[] args)
    {

      Transazione tipo1 = new Transazione(UnTipoDiLog);
      Transazione tipo2 = new Transazione(UnAltroTipoDiLog);

      tipo1.RichiedeControllo();
      tipo2.RichiedeControllo();
       

    }
  }
}
