using System;
using System.Globalization;

namespace format_parsing_A
{
  class Program
  {
    static void Main(string[] args)
    {
      string s = "";

      //TO_STRING
      int i = 100; 
      //Console.WriteLine( i.ToString());

      double d = 234.7954; 
      //Console.WriteLine(d.ToString());
      //Console.WriteLine(d.ToString("f2"));
      //Console.WriteLine($"{d:f2}");

      //Console.WriteLine($"{d*2:f2}");
      //Console.WriteLine($"{(d>200 ? d/2 : d*2):f2}");

      //Console.WriteLine($"#{d, -15:f2}#"); 

      //Console.WriteLine($"#{d,-15:00000.00}#");

      CultureInfo provider = new CultureInfo("en-EN");
      
      //Console.WriteLine($"{d.ToString("F2", provider)}");
      //Console.WriteLine($"{d.ToString("F2",  CultureInfo.InvariantCulture)}");

      NumberFormatInfo numberProvider = new NumberFormatInfo();
      numberProvider.NegativeSign = "|";
      numberProvider.NumberDecimalSeparator = ",";


      Console.WriteLine($"{d.ToString("F2", provider)}");

      d = -128.456; //e vogliamo ottenere |128,456
      provider.NumberFormat = numberProvider;
      
      Console.WriteLine($"{d.ToString("F1", provider)}");

      DateTimeFormatInfo dtProvider = new DateTimeFormatInfo();
        
      dtProvider.DayNames = new string[]
      {"DomDom", "Lunedicolo", "Martolino", "Mercolone", "Gioveddì", "Venerando", "SabatoPerTutti" };
      
      Console.WriteLine($"{DateTime.Now.ToString("D", dtProvider)}");

      //int.TryParse("-5", out int n1);
      int n1 = int.Parse("|5", numberProvider);
      Console.WriteLine(n1);

      decimal d1 = decimal.Parse("-5$", NumberStyles.AllowCurrencySymbol | NumberStyles.AllowLeadingSign, new CultureInfo("us-US"));
      Console.WriteLine(d1);

      DateTime dt1 = DateTime.Parse("31/07/2021 18:30");
      Console.WriteLine(dt1.ToLongDateString());

      dt1 = DateTime.Parse("sabato 31 luglio 2021 18:30");
      Console.WriteLine(dt1.ToLongDateString());
      Console.WriteLine(dt1.ToLongTimeString());

      dtProvider.MonthNames = new string[]
      {"Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto",
      "Settembre", "Ottobre", "Novembre", "Dicembre", ""};

      provider.DateTimeFormat = dtProvider;
      dt1 = DateTime.Parse("SabatoPerTutti 31 Luglio 2021 18:30", provider);
      Console.WriteLine(dt1.ToLongDateString());

      DateTimeStyles.


    }
  }
}
