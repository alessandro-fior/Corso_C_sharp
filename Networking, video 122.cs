using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Networking_B
{
  class Program
  {
    static async Task ScaricaConHTTPClient()
    {

      using HttpClient client = new ();
      var rispostaServer = await client.GetAsync("https://www.camuso.it/DA_CANCELLARE/test.pdf");
      using var fs = new FileStream("test.pdf", FileMode.Create);
      await rispostaServer.Content.CopyToAsync(fs);

      Thread.Sleep(5000);
      Console.WriteLine("Download completato ...");
     }

    static async Task<HttpContent> UploadDatiForm()
    {
      var client = new HttpClient(); 
      var campi = new Dictionary<string, string> { 
        { "idArticolo", "XY009PQ" }, 
        { "descrizione", "manicotto XL" } };
      
      var datiForm = new FormUrlEncodedContent(campi);
      var rispostaServer= await client.PostAsync("http://localhost/php/testuploadYT/form.php", datiForm); 
      rispostaServer.EnsureSuccessStatusCode();
      return rispostaServer.Content;
    }

    
    static async Task Main()
    {
      //await ScaricaConHTTPClient(); 

      //upload dati a una form
      HttpContent rispostaServer = await UploadDatiForm();
      Console.WriteLine(await rispostaServer.ReadAsStringAsync());

    }
  }
}
