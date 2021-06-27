using System;
using System.Collections.Generic;
using System.Text;

namespace fw_supportoString
{
  class Program
  {
    static void Main(string[] args)
    {
      string s = new String('*', 80);
      Console.WriteLine(s);

      string s1 = null;
      //Console.WriteLine(s1.Length); NO, l'oggetto non è istanziato -> eccezione!

      s1 = "";
      Console.WriteLine(s1.Length);

      if (string.IsNullOrEmpty(s1))
        Console.WriteLine("Stringa non utilizzabile");

      s1 = "Topolino & ";
      string s2 = "Minnie";
      string s3 = s1 + s2 + s1 + s2;
      string s4 = String.Concat(s1, s2, s1, s2);

      Cliente cliente1 = new Cliente(); ;
      string s5 = String.Concat(cliente1, cliente1);
      Console.WriteLine(s5);

      List<string> elenco = new List<string> { "uno ", "due " , "tre "};
      s5 = String.Concat(elenco);
      Console.WriteLine(s5);

      DateTime start = DateTime.Now;
      s5 = "";
      for (int i = 0; i < 50000; i++)
        s5 = String.Concat(s5, " abc ");
      DateTime end = DateTime.Now;
      Console.WriteLine($"Tempo - Concat: {end - start}");

      start = DateTime.Now;
      s5 = "";

      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < 1000000; i++)
        sb.Append(" abc ");
      end = DateTime.Now;
      Console.WriteLine($"Tempo - StrBld: {end - start}");

      start = DateTime.Now;
      int n = 10;
      s5 = String.Concat("ciao a ", n, "persone ", n, " volte!");
      end = DateTime.Now;
      Console.WriteLine($"Tempo - Concat2: {end - start}");

      StringBuilder sb2 = new StringBuilder();
      sb2.Append("ciao a ");
      sb2.Append(n);
      sb2.Append("persone ");
      sb2.Append(n);
      sb2.Append(" volte!");
      end = DateTime.Now;
      Console.WriteLine($"Tempo - StrBld2: {end - start}");

    }
  }

  class Cliente
  {
    string cognome = "Mario";
    string nome = "Rossi";
    int eta = 36;
    public Cliente() { }

    public override string ToString()
    {
      return $"{cognome} {nome} {eta}";
    }
  }
}
