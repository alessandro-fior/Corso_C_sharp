using System;

namespace DateTime_A
{
  class Program
  {
    static void Main(string[] args)
    {
      //TimeSpan, DateTime, DateTimeOffset
      
      DateTime dt1 = DateTime.Now;
      DateTime dt2 = DateTime.Now;

      Console.WriteLine(dt1);
      DateTime dt3 = dt1 + TimeSpan.FromDays(5.5);
      Console.WriteLine(dt3);

      dt3 = dt3.AddDays(5);
      Console.WriteLine(dt3);
      TimeSpan ts1 = new TimeSpan(10000000); //1s = 10.000.000 di ticks da 100ns
      Console.WriteLine(dt3 + ts1);
      ts1 = dt3 - dt1 + TimeSpan.FromHours(11.999);

      Console.WriteLine(ts1.TotalDays);
      Console.WriteLine(ts1.Days);
      


      //Console.WriteLine(ts1.Ticks);



    }
  }
}
