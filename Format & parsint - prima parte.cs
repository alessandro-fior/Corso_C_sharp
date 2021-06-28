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
      Console.WriteLine( i.ToString());

      double d = 234.7954; 
      Console.WriteLine(d.ToString());
      Console.WriteLine(d.ToString("f2"));
      Console.WriteLine($"{d:f2}");

      Console.WriteLine($"{d*2:f2}");
      Console.WriteLine($"{(d>200 ? d/2 : d*2):f2}");

      Console.WriteLine($"#{d, -15:f2}#"); 

      Console.WriteLine($"#{d,-15:00000.00}#");

      CultureInfo provider = new CultureInfo("en-US");
      Console.WriteLine($"{d.ToString("F2", provider)}");
      Console.WriteLine($"{d.ToString("F2",  CultureInfo.InvariantCulture)}");

      NumberFormatInfo numberProvider = new NumberFormatInfo();
      numberProvider.NegativeSign = "|";
      Console.WriteLine($"{d.ToString("F2", numberProvider)}");

      d = -128.456;
      Console.WriteLine($"{d.ToString("F1", numberProvider).ToString(provider)}");

      DateTimeFormatInfo dtProvider = new DateTimeFormatInfo();
      dtProvider.DayNames = new string[]
         { "Lunedicolo", "Martolino", "Mercolone", "Gioveddì", "Venerando", "SabatoPerTutti", "DomDom"};
      Console.WriteLine($"{DateTime.Now.ToString("D", dtProvider)}");


      DateTime dt = new DateTime(2021, 5, 25);
      Console.WriteLine(dt.ToString());

      Console.WriteLine(true);


    }
  }
}
