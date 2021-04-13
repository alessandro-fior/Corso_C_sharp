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
      Console.WriteLine($"Val: {MyHelpers.GetEnumDescription(tipo)}");

      Prova p = new Prova();
      //MyExtensions.F(p, 8);

      string s = "topolino";
      //Console.WriteLine(s.xxx());

      Allarme allarme = Allarme.InteraCasa;
      Console.WriteLine(MyHelpers.GetEnumDescription(allarme));

      Console.ReadKey();
    }
  }

  public enum Allarme : byte
  {
    [Description("Tutti gli allarmi spenti")]
    Spento = 0,

    [Description("Solo Giardino")]
    Giardino = 1,

    [Description("Solo Garage")]
    Garage = 2,

    [Description("Allarmi tutti accesi")]
    InteraCasa = 3
  };

  public enum DocumentoTipo
  {
    //[Description("Fattura")] // non necessario se la costante coincide con ciò che vogliamo visualizzare
    Fattura,

    [Description("Nota Di Credito")]
    [DefaultValue(10)]
    NotaDiCredito
  }
 
  public class Prova
  {
    public void F(object obj) { Console.WriteLine("metodo classe"); }
    string s = "privata";
  }


  static public class MyExtensions
  {
    static private readonly Dictionary<DocumentoTipo, string> DocStrings = new Dictionary<DocumentoTipo, string> {
                { DocumentoTipo.Fattura, "Fatture" },
                { DocumentoTipo.NotaDiCredito, "Nota Di Credito" }
            };


    //public static double xxx(this String s) { return 5.89; }

    ////public static void F(this Prova p, int n) { Console.WriteLine(p.s); }

    public static string GetString(this DocumentoTipo e)
    {

      return (MyExtensions.DocStrings )[e];
            

      //  switch ((int)e)
      //  {
      //    case 0: return "Fattura";
      //    case 1: return "Nota Di Credito";
      //    default: return "Tipo Documento non riconosciuto";
      //  }

      //return strings[e];
    }
  }

      static public class MyHelpers
  {
    // Il metodo verifica la presenza dell'attributo Description, 
    //altrimenti necessario attributo nell'enumeratore
    static public string GetEnumDescription(object enumObj)
    {
      FieldInfo fi = enumObj.GetType().GetField(enumObj.ToString());

      DescriptionAttribute[] attributes = 
          (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
      
      return (attributes.Length > 0) ? attributes[0].Description : enumObj.ToString();
    }
  }
}

