using System;

namespace funzioni_1
{
  class Program
  {

    static int GiorniMese1(int mese,int anno) //parametri formali
    {
      if (mese == 4 || mese == 6 || mese == 9 || mese == 11)
        return 30;
      else
        if (mese == 2)
          return 28 + (anno % 400 == 0 || (anno % 4 == 0 && anno % 100 != 0) ? 1 : 0);
      else
        return 31;
    }

    static int GiorniMese1Difensiva(int mese, int anno) //parametri formali
    {
      //check parametri
      if (mese < 1 || mese > 12 || anno < 1900)
      {
        //NO!! MAI COMANDARE INPUT/OUTPUT IN FUNZIONI NON SPECIFICHE PER INPUT/OUTPUT
        Console.WriteLine("un messaggio bello esaustivo e informativo");
        return -1;
      }
      else
        if (mese == 4 || mese == 6 || mese == 9 || mese == 11)
        return 30;
      else
          if (mese == 2)
        return 28 + (anno % 400 == 0 || (anno % 4 == 0 && anno % 100 != 0) ? 1 : 0);
      else
        return 31;
    }

    static int GiorniMese(int mese, int anno) //parametri formali
    {
      switch (mese)
      { 
        case 4: case 6: case 9: case 11: 
          return 30;

        case 2:
          return 28 + (anno % 400 == 0 || (anno % 4 == 0 && anno % 100 != 0) ? 1 : 0);

        default:
          return 31;
      }
    }

    static int GiorniMese2Difensiva(int mese, int anno) //parametri formali
    {
      //check parametri
      if (mese < 1 || mese > 12 || anno < 1900)
        return -1;
      else
        switch (mese)
        {
          case 4:
          case 6:
          case 9:
          case 11:
            return 30;

          case 2:
            return 28 + (anno % 400 == 0 || (anno % 4 == 0 && anno % 100 != 0) ? 1 : 0);

          default:
            return 31;
        }
    }

    static int GiorniMese3(int mese, int anno) //parametri formali
    {
      int [] giorni = {31,28,31,30,31,30, 31,31,30,31,30,31};
      return giorni[mese - 1] +
        (mese == 2 && (anno % 400 == 0 || (anno % 4 == 0 && anno % 100 != 0)) ? 1 : 0);
    }

    static bool DataCorretta(int g, int m, int a)
    {
      return a > 0 && m > 0 && m < 13 && g > 0 && g <= GiorniMese(m, a);
    }

    static int DifferenzaDateInGiorni(int g1, int m1, int a1, int g2, int m2, int a2)
    {
      if (m1 == m2 && a1 == a2) return Math.Abs(g2 - g1);
      
      int differenza = GiorniMese(m1, a1) - g1; //a fine mese

      //sommo i giorni dei mesi intermedi
      for (int mese = m1 + 1; mese < m2; mese++) differenza += GiorniMese(mese, a1);

      //sommo i giorni restanti
      return differenza + g2;
    }

    static int LeggiIntero(string messaggio)
    {
      bool esito = false;
      int n = 0;

      do
      {
        Console.Write(messaggio + "-> ");

        if (!(esito = int.TryParse(Console.ReadLine(), out n)))
        {
          Console.WriteLine("Non è un numero intero, riprova ... premi un tasto per continuare");
          Console.ReadKey(true);
        }
      } while (!esito);

      return n;
    }

    static int[] LeggiData(string messaggio)
    {
      int[] laData = new int[3];

      do
      {
        laData[0] = LeggiIntero("Giorno");
        laData[1] = LeggiIntero("Mese");
        laData[2] = LeggiIntero("Anno");

        if (DataCorretta(laData[0], laData[1], laData[2])) break;

        Console.WriteLine("Data errata ... Riprova, premi un tasto per continuare");
        Console.ReadKey(true);
      } while (true);

      return laData;
    }

    static void Main(string[] args)
    {
      //Una ditta di noleggi affitta biciclette elettriche a un tot al giorno anc > he per lunghi periodi.
      //Per ogni cliente saranno registrate le date di inizio e fine noleggio.
      //Inseriti come dati il prezzo giornaliero di noleggio e le date del periodo 
      //di noleggio calcolare l`importo totale dovuto.

      //12-6-2020  e 18-10-2020

      //for (int anno = 1995; anno < 2101; anno++)
      //  if (GiorniMese3(2, anno) == 29) Console.WriteLine($"Anno {anno}: bisestile");

      int[] data1 = { 1, 1, 2020 }; //LeggiData("Inserire una data");
      int[] data2 = { 1, 1, 2020 }; //LeggiData("Inserire una data");

      Console.WriteLine(DifferenzaDateInGiorni(data1[0], data1[1], data1[2],
                                                data2[0], data2[1], data2[2]));

      

    }
  }
}