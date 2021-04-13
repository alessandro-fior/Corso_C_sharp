using System;

namespace funzioni2
{
  struct Animazione {
    string dato1;
    string dato2;

    double fattoreScala;
    bool canaleAlfa;
    //ecc.
  }
  struct Img {
    public string descrizioneBreve;
    string descrizioneLunga;

    byte[] header;
    //ecc.
  }

  class Program
  {

    static void MinMax1(int[] v, out int posMin, out int posMax, int partiDa=0, int quantiElementi=0)
    {
      posMin = 100;
      posMax = 999;

      Console.WriteLine($"partiDa: {partiDa} -- quantiElementi{quantiElementi}");
    }

    static Animazione Morph(in Img Partenza, in Img Destinazione)
    {
      Animazione risultato = new Animazione();
      //... istruzioni
      
      //Partenza.descrizioneBreve = NO! VIETATO

      return risultato;
    }

    static void f(int n) { }
    static void f(string s) { }
    static void f(string s, int n) { }
    static void f(int n, string s) { 

    }



    static int Sommatoria(params int[] numeri)
    {
      int somma = 0;
      foreach (int numero in numeri) somma += numero;
      return somma; 
    }

    static string Sommatoria(params string [] stringhe)
    {
      string somma = "";
      foreach (string stringa in stringhe) somma += stringa;
      return somma;
    }


    static void Main(string[] args)
    {

      int posizioneMin, posizioneMax;

      MinMax1(new int[] { 1, 5, 6, 7 }, out posizioneMin, out posizioneMax, quantiElementi:9);
      Console.WriteLine(posizioneMin);

      int s1 = Sommatoria(1,2,3);
      int s2 = Sommatoria(1, 2, 3, 9, 7, 8, 8, 12, 1, 2, 3, 9, 7, 8, 8, 12, 1, 2, 3, 9, 7, 8, 8, 12);
      Console.WriteLine($"s1: {s1}  s2: {s2}");

      Console.WriteLine(Sommatoria("ciao ", "a ", "tutti!"));

     



    }
  }
}