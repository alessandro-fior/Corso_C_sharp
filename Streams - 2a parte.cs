using System;
using System.IO;

namespace Streams_A
{
  class Program
  {
    static void Main(string[] args)
    {

      
      using (FileStream f = new FileStream("immagine.bmp", FileMode.Open, FileAccess.ReadWrite))
      {   
        Console.WriteLine(f.Length);
        Console.WriteLine($"Leggibile {f.CanRead}");
        Console.WriteLine($"Scrivibile {f.CanWrite}");
        Console.WriteLine($"Seekable {f.CanSeek}");
        Console.WriteLine($"Timeout {f.CanTimeout}");

        //string tipo_immagine = "";
        //byte[] buffer = new byte[2];
        //f.Read(buffer, 0, 2);
        //Console.WriteLine(System.Text.Encoding.UTF8.GetString(buffer, 0, 2));
        
        f.Seek(2, SeekOrigin.Current);
        byte[] dimensione_buffer = new byte[4];
        f.Read(dimensione_buffer, 0, 4);
        
        //if (BitConverter.IsLittleEndian)
        //  Array.Reverse(dimensione_buffer); //Little / Big Endian ??
        
        UInt32 dimensione = BitConverter.ToUInt32(dimensione_buffer, 0);
        Console.WriteLine($"Dimensione letta direttamente dal file: {dimensione}");

        f.Seek(-4, SeekOrigin.Current);
        f.Read(dimensione_buffer, 0, 4);
        dimensione = BitConverter.ToUInt32(dimensione_buffer, 0);
        Console.WriteLine($"Dimensione letta direttamente dal file: {dimensione}");

        f.Seek(0, SeekOrigin.Begin);
        byte[] buffWrite = new byte[2] {(byte)'F', (byte)'C' };
        f.Write(buffWrite);

        f.Seek(0, SeekOrigin.Begin);
        byte[] buffRead = new byte[2];
        f.Read(buffRead);
        Console.WriteLine(System.Text.Encoding.UTF8.GetString(buffRead, 0, 2));

        f.Seek(0, SeekOrigin.Begin);
        buffRead = new byte[100000];

        int byteAvanzatiDaLeggere = 100000;
        int byteLetti = 0;

        while(byteAvanzatiDaLeggere>0)
        {
          int letti = f.Read(buffRead, byteLetti, byteAvanzatiDaLeggere);
          Console.WriteLine(letti);

          if (letti == 0) break;
          byteLetti += letti;
          byteAvanzatiDaLeggere -= letti;
        }
      }
    }
  }
}
