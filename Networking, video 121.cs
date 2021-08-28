using System;
using System.Net;
using System.Net.Http;
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
      client.DownloadProgressChanged += (sender, args) =>
        Console.Write($"\r{args.ProgressPercentage}%  ricevuti: {args.BytesReceived}/{args.TotalBytesToReceive}");

      await client.DownloadFileTaskAsync("https://www.camuso.it/DA_CANCELLARE/clip.mp4", "clip.mp4");

      Console.WriteLine("\nDownload completato");
      mre.Set();

    }

    static async Task ScaricaConHTTPClientToken()
    {
      using (HttpClient httpClient = new HttpClient())
      {
        CancellationTokenSource cts = new CancellationTokenSource();
        cts.CancelAfter(10000);

        httpClient.Timeout = TimeSpan.FromSeconds(5);

        string homePage = "";
        try
        {
          homePage = await httpClient.GetStringAsync("https://www.camuso.it:81", cts.Token);
        }
        catch (TaskCanceledException eccezione) 
        {
          if (eccezione.InnerException is TimeoutException)
            Console.WriteLine("Timeout scaduto ...");
          else
            Console.WriteLine("Download abortito su richiesta dell'utente");
        }
        finally
        {
          Console.WriteLine(homePage);
          mre.Set();
        }
      }
    }

    static async Task ScaricaConHTTPClient()
    {
      using (HttpClient httpClient = new HttpClient())
      {
        //httpClient.Timeout = TimeSpan.FromSeconds(5);

        string homePage = "";
        try
        {
          homePage = await httpClient.GetStringAsync("https://www.camuso.it");
          Console.WriteLine(homePage);
        }
        catch (TaskCanceledException eccezione) when (eccezione.InnerException is TimeoutException)
        {
          Console.WriteLine("Timeout scaduto ...");
        }
        finally {
          mre.Set();  
        }
        

      }
    }

    static void Main(string[] args)
    {
      //Download di un file, senza reporting
      WebClient client = new () { Proxy = null };
      //client.DownloadFile("https://www.camuso.it/index.asp", "index.asp");

      //try
      //{
      //  client.DownloadFile("https://www.camuso.it/cicli2.jpg", "cicli2.jpg");
      //}
      //catch (WebException e)
      //{
      //  Console.WriteLine("Errore 404: risorsa non trovata");
      //}

      //scaricamento in asincrono con possibilità di abortire
      //var t =Scarica(client);
      //Console.WriteLine("Io intanto continuo..."); 

      //Task task = Task.Factory.StartNew(() => FaiAltro());
      //task.Wait();

      //Thread.Sleep(5000);
      //Console.Clear();
      //Console.WriteLine("Download interrotto dall'utente ...");
      //client.CancelAsync();
      //mre.Set();

      //var t = ScaricaConHTTPClient();
      var t = ScaricaConHTTPClientToken();
      mre.WaitOne();

    }
  }
}
 