using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Enum2
{
  class Program
  {
    static void Main(string[] args)
    {
      DocumentoTipo tipo = DocumentoTipo.NotaDiCredito;
      Console.WriteLine($"Val: {tipo}");
      //Console.WriteLine($"Val: {tipo.GetString()}"); //extension method
    
      Prova p = new Prova();
      //MyExtensions.F(p, 8);

      string s = "topolino";
      //Console.WriteLine(s.xxx());

      Console.ReadKey();
    }
  }

  public enum DocumentoTipo
  {
    Fattura,
    NotaDiCredito
  }
 
  public class Prova
  {
    public void F(object obj) { Console.WriteLine("metodo classe"); }
    string s = "privata";
  }

  static public class MyExtensions
  {
    public static string GetString(this DocumentoTipo e)
    {
      //  switch ((int)e)
      //  {
      //    case 0: return "Fattura";
      //    case 1: return "Nota Di Credito";
      //    default: return "Tipo Documento non riconosciuto";
      //  }

      Dictionary<int, string> strings = new Dictionary<int, string> {
                { 0, "Fatture" },
                { 1, "Nota Di Credito" }
            };
      return strings[(int)e];
    }
  }
}

