using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkingC
{
  class Program
  {
    static void GoogleSearchWebClient(string stringaRicerca)
    {
      var client = new System.Net.WebClient { Proxy = null }; 
      client.QueryString.Add("q", stringaRicerca);

      client.DownloadString("http://www.google.com/search");
      
      client.DownloadFile ("http://www.google.com/search", "results.html");
    }

    static void DownloadFTP()
    {
      //string[] credenziali = File.ReadAllLines("g:\\cred.txt");

      string username = "vostra_user_name"; //credenziali[0];
      string password = "vostra_password"; //credenziali[1];

      // oggetto con cui comunicare con il server 
      var richiestaFTP = (FtpWebRequest)WebRequest.Create("ftp://ftp.camuso.it");
      richiestaFTP.Proxy = null;

      //tipo operazione richiesta
      richiestaFTP.Method = WebRequestMethods.Ftp.ListDirectory;
      // credenziali
      richiestaFTP.Credentials = new System.Net.NetworkCredential(username, password);

      using (WebResponse rispostaServer = richiestaFTP.GetResponse())
      using (StreamReader stream = new (rispostaServer.GetResponseStream()))
      Console.WriteLine(stream.ReadToEnd());

      //return;

      //upload file
      richiestaFTP = (FtpWebRequest)WebRequest.Create("ftp://ftp.camuso.it/DA_CANCELLARE/clip/test.txt");
      richiestaFTP.Method = WebRequestMethods.Ftp.UploadFile;
      richiestaFTP.Credentials = new System.Net.NetworkCredential(username, password);

      byte[] sorgente;
      //creare preventivamente nella cartella dell'eseguibile un file "testLocale.txt"
      using (StreamReader stream = new ("testLocale.txt"))
      {
        sorgente = System.Text.Encoding.UTF8.GetBytes(stream.ReadToEnd());
      }

      richiestaFTP.ContentLength = sorgente.Length;
      richiestaFTP.Proxy = null;
      //richiestaFTP.AuthenticationLevel = System.Net.Security.AuthenticationLevel.None;
      //richiestaFTP.PreAuthenticate = true;
      //richiestaFTP.UseBinary = true;
      //richiestaFTP.UsePassive = true;                             

      using (Stream requestStream = richiestaFTP.GetRequestStream())
      {
        requestStream.Write(sorgente, 0, sorgente.Length);
      }

      using FtpWebResponse response = (FtpWebResponse)richiestaFTP.GetResponse();
      Console.WriteLine($"Upload File Completato, stato: {response.StatusDescription}");
    }  
      
     
    static void Main(string[] args)
    {
      //GoogleSearchWebClient("cani e gatti");
      DownloadFTP();
    }
  }
}
