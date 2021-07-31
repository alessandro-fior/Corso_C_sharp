using System;
using System.IO;

namespace StreamAdapters_A
{
  class Program
  {
    static void Main(string[] args)
    {

      StreamReader test = new StreamReader("test.txt");
      string s = test.ReadLine();

      //commento da scartare in lettura
      //using (FileStream fs = new FileStream("..//..//../Program.cs", 
      //                                         FileMode.Open, FileAccess.Read))
      //{        
      //  using (StreamReader leggi = new StreamReader(fs))
      //  {


      //  }
      //}

      using (StreamReader leggi = new StreamReader("..//..//../Program.cs"))
      {
        using (StreamWriter scrivi = new StreamWriter("ProgramSenzaCommenti.cs", true))
        {
          string rigaLetta = "";
          while ((rigaLetta = leggi.ReadLine()) != null)
            if (!rigaLetta.TrimStart().StartsWith("//"))
              scrivi.WriteLine(rigaLetta);
        }
      } 
     
      
    }
  }
}
