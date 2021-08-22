using System;
using System.IO.Compression;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StreamZIP_A
{

  class Program
  {

    static void Main(string[] args)
    {
      //deflate, gzip, Brotli, zip

      //goto salto;

      Stopwatch watch = Stopwatch.StartNew();

      //DEFLATE, compressione (4.7 sec)
      using (FileStream origine = File.OpenRead("enwik8.txt"))
      using (FileStream destinazione = File.Create("compressoDeflate.bin"))
      using (DeflateStream compressore = new(destinazione, CompressionMode.Compress))
        origine.CopyTo(compressore);

      watch.Stop();
      Console.WriteLine($"Deflate compressione {watch.ElapsedMilliseconds}");

      watch.Start();
      //DEFLATE, DEcompressione
      using (FileStream origine = File.OpenRead("compressoDeflate.bin"))
      using (FileStream destinazione = File.Create("DEcompressoDeflate.txt"))
      using (DeflateStream DeCompressore = new (origine, CompressionMode.Decompress))
        DeCompressore.CopyTo(destinazione);
      watch.Stop();
      Console.WriteLine($"Deflate DEcompressione {watch.ElapsedMilliseconds}");


      //Brotli, compressione
      watch.Start();
      using (FileStream origine = File.OpenRead("enwik8.txt"))
      using (FileStream destinazione = File.Create("compressoBrotli.bin"))
      using (BrotliStream compressore = new(destinazione, CompressionLevel.Fastest))
        origine.CopyTo(compressore);

      watch.Stop();
      Console.WriteLine($"Brotli compressione {watch.ElapsedMilliseconds}");


      watch.Start();
      //Brotli, DEcompressione
      using (FileStream origine = File.OpenRead("compressoBrotli.bin"))
      using (FileStream destinazione = File.Create("DEcompressoBrotli.txt"))
      using (BrotliStream DeCompressore = new(origine, CompressionMode.Decompress))
        DeCompressore.CopyTo(destinazione);
      watch.Stop();
      Console.WriteLine($"Brotlin DEcompressione {watch.ElapsedMilliseconds}");

      watch.Start();
      using (FileStream destinazione = File.Create("compressoZIP.zip"))
      using (ZipArchive zip = new(destinazione, ZipArchiveMode.Create))
      {
        zip.CreateEntryFromFile("enwik8.txt", "enwik8.txt");
        zip.CreateEntryFromFile("StreamZIP_A.dll", "StreamZIP_A.dll");
        zip.CreateEntryFromFile("compressoBrotli.bin", "compressoBrotli.bin");
        zip.CreateEntryFromFile("compressoDeflate.bin", "compressoDeflate.bin");
      }
      watch.Stop();
      Console.WriteLine($"ZIP compressione {watch.ElapsedMilliseconds}");

      using (FileStream origine = new ("compressoZIP.zip", FileMode.Open, FileAccess.ReadWrite))
      using (ZipArchive zip = new(origine, ZipArchiveMode.Update))
      {
        //zip.ExtractToDirectory("zipFolder1");

        List<ZipArchiveEntry> daEliminare = new List<ZipArchiveEntry>();
        
        foreach(ZipArchiveEntry entry in zip.Entries)
        {
          if (!entry.FullName.EndsWith(".bin"))
            daEliminare.Add(entry);
        }

        foreach (ZipArchiveEntry entry in daEliminare)
          entry.Delete();


      }


      using (FileStream origine = new("compressoZIP.zip", FileMode.Open, FileAccess.ReadWrite))
      using (ZipArchive zip = new(origine, ZipArchiveMode.Update))
      {
        zip.ExtractToDirectory("."); 
      }
    salto:
      //ZipFile.CreateFromDirectory("zipFolder1", "compresso2.zip");
      ZipFile.ExtractToDirectory("compresso2.zip", "zipFolder2");
     
      }
    }
}
