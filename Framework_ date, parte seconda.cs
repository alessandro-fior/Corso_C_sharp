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

      //Console.WriteLine(dt1);
      DateTime dt3 = dt1 + TimeSpan.FromDays(5.5);
      //Console.WriteLine(dt3);

      dt3 = dt3.AddDays(5);
      //Console.WriteLine(dt3);
      TimeSpan ts1 = new TimeSpan(10000000); //1s = 10.000.000 di ticks da 100ns
      //Console.WriteLine(dt3 + ts1);
      ts1 = dt3 - dt1 + TimeSpan.FromHours(11.999);

      //Console.WriteLine(ts1.TotalDays);
      //Console.WriteLine(ts1.Days);

      //Console.WriteLine(DateTime.Now);
      //Console.WriteLine(DateTimeOffset.Now);

      DateTimeOffset mezzogiornoLondra = new DateTimeOffset(2021, 5, 18, 12, 0, 0, TimeSpan.Zero);
      DateTimeOffset quattordiciRoma = new DateTimeOffset(new DateTime(2021, 5, 18,14,0,0));

      Console.WriteLine(mezzogiornoLondra);
      Console.WriteLine(quattordiciRoma);
      Console.WriteLine(mezzogiornoLondra == quattordiciRoma);

      Console.WriteLine(DateTime.Today);

      string[] elencoDate = { "18/08/2018", "8/2018","07:22:16",
                              "7 PM", "2018-08-18T07:22:16.0000000Z",
                              "2018-08-18T07:22:16.0000000-07:00",
                              "Sat, 18 Aug 2018 07:22:16 GMT"};
      foreach (string d in elencoDate)
      { dt3 = DateTime.Parse(d); Console.WriteLine(dt3.ToLongDateString()); }

      Console.WriteLine(dt3.DayOfWeek);
      Console.WriteLine(dt3.DayOfYear);

      //i warning di Giovanni De Rosa

      //1. Neutralizzare/bypassare la parte time quando non serve
      DateTime a = DateTime.Now; // Data di oggi
      DateTime b = new DateTime(2021, 5, 19); // Data di oggi
      if (a == b) Console.WriteLine("Date uguali"); // false
      if (a.Date == b.Date) Console.WriteLine("Date uguali"); // false

      //2 costi mensili
      //30 euro al mese = 360 euro anno.
      //360 euro / 365 giorni = 0,9863
      System.Globalization.GregorianCalendar calendar = new System.Globalization.GregorianCalendar();
      DateTime ora = DateTime.Now;
      decimal costoMensile = 30;
      int anno = ora.Year;
      int giorniAnno = calendar.GetDayOfYear(new DateTime(anno, 12, 31));
      decimal costoGiornaliero = costoMensile * 12 / giorniAnno;
      int mese = 2; // calcolo per febbraio
      int giorniDelMese = DateTime.DaysInMonth(anno, mese);
      decimal risultato = costoGiornaliero * giorniDelMese;
      Console.WriteLine(risultato);

      //3. numero di giorni in un certo intervallo
      dt1 = new DateTime(2021, 3, 1);
      dt2 = new DateTime(2021, 3, 31);
      Console.WriteLine($"Fatturati: {dt2 - dt1} giorni");
    
      //DateTimeOffset dtoff2 = new DateTimeOffset(dt3);
      //Console.WriteLine(dtoff1);
      //Console.WriteLine(dtoff2);

      //Console.WriteLine(ts1.Ticks);



    }
  }
}
