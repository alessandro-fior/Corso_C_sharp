using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Networking_A
{
  class Program
  {
    static ManualResetEvent mre = new ManualResetEvent(false);
    
    static void FaiAltro()
    {
      for (int i = 0; i < 100; i++)
        Console.WriteLine("Lavoro ...");

      //Thread.Sleep(25000);
    }

    static async Task Scarica(WebClient client)
    {
      await client.DownloadFileTaskAsync("https://www.camuso.it/DA_CANCELLARE/clip.mp4", "clip.mp4");
      mre.Set();
      
      Console.WriteLine("Download completato");
    }

    static void Main(string[] args)
    {
      //Download di un file, senza reporting
      WebClient client = new () { Proxy = null }; 
      client.DownloadFile("https://www.camuso.it/index.asp", "index.asp");

      //try
      //{
      //  client.DownloadFile("https://www.camuso.it/cicli2.jpg", "cicli2.jpg");
      //}
      //catch (WebException e)
      //{
      //  Console.WriteLine("Errore 404: risorsa non trovata");
      //}

      //scaricamento in asincrono con possibilità di abortire
      var t =Scarica(client);
      Console.WriteLine("Io intanto continuo..."); 
      
      Task task = Task.Factory.StartNew(() => FaiAltro());
      task.Wait();

      mre.WaitOne();

    }
  }
}
 