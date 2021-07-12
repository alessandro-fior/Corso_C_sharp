using System;
using System.Threading;
using System.Threading.Tasks;

namespace Async_Await_A
{
  class Program
  {
   
    static Task Download(string url)
    {
      return Task.Run(() =>
      {
        double x = 0;
        for (int i = 0; i <= 100000000; i++) x = Math.Atanh(x / 123);
        if ((new Random()).Next() % 3 == 0) while (true) ;
        Console.WriteLine($"Download da {url} completato");
      });
    }


    static void DownloadSync()
    {
      //Download("https://www.site1.com");
      //Download("https://www.site2.com");
      //Download("https://www.site3.com");
      //Download("https://www.site4.com");
      //Download("https://www.site5.com");
      //Download("https://www.site6.com");
      //Download("https://www.site7.com");
      //Download("https://www.site8.com");

      Task.Run(() => Download("https://www.site1.com"));
      Task.Run(() => Download("https://www.site2.com"));
      Task.Run(() => Download("https://www.site3.com"));
      Task.Run(() => Download("https://www.site4.com"));
      Task.Run(() => Download("https://www.site5.com"));
      Task.Run(() => Download("https://www.site6.com"));
      Task.Run(() => Download("https://www.site7.com"));
      Task.Run(() => Download("https://www.site8.com"));

    }


    static async void DownloadAsync()
    {
      //await Task.Run(() => Download("https://www.site1.com"));
      //await Task.Run(() => Download("https://www.site2.com"));
      //await Task.Run(() => Download("https://www.site1.com"));
      //await Task.Run(() => Download("https://www.site2.com"));
      //await Task.Run(() => Download("https://www.site1.com"));
      //await Task.Run(() => Download("https://www.site2.com"));
      //await Task.Run(() => Download("https://www.site1.com"));
      //await Task.Run(() => Download("https://www.site2.com"));

      await Download("https://www.site1.com");
      await Download("https://www.site2.com");
      await Download("https://www.site3.com");
      await Download("https://www.site4.com");
      await Download("https://www.site5.com");
      await Download("https://www.site6.com");
      await Download("https://www.site7.com");
      await Download("https://www.site8.com");
    }

    static void Main(string[] args)
    {
      DownloadAsync();

      string user = "";
      Console.WriteLine("User name: ");
      user = Console.ReadLine();
    }
  }
}
