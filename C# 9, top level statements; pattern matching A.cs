using System;

namespace patternMatching
{

  class Personaggio { }

  class Adepto : Personaggio { public int Protezione { get; set; } = 100; }
  class Druido : Personaggio { public int Esperienza { get; set; } = 200; }
  class Stregone : Personaggio  { public int Dominio { get; set; } = 300; }


    static class Program
    {

        //static public int MaxPotenziamentoApplicabile(this Personaggio p) 
        //{
        //    if (p is null) throw new ArgumentNullException();
        //    if (p is Adepto) return ((Adepto)p).Protezione + 10;
        //    if (p is Druido) return ((Druido)p).Esperienza + 100;
        //    if (p is Stregone) return ((Stregone)p).Dominio+ 10;

        //    throw new ArgumentException("Personaggio sconosciuto", nameof(Personaggio));
        //}


        //static public int MaxPotenziamentoApplicabile(this Personaggio p)
        //{
        //    if (p is null) throw new ArgumentNullException();
        //    if (p is Adepto a) return a.Protezione + 10;
        //    if (p is Druido d) return d.Esperienza + 100;
        //    if (p is Stregone s) return s.Dominio + 10;

        //    throw new ArgumentException("Personaggio sconosciuto", nameof(Personaggio));
        //}

        //static public int MaxPotenziamentoApplicabile(this Personaggio p)
        //{
        //    if (p is Adepto a) 
        //        return a.Protezione + 10;
        //    else
        //        if (p is Druido d) 
        //            return d.Esperienza + 100;
        //        else
        //            if (p is Stregone s) 
        //                return s.Dominio + 10;
        //            else
        //                if (p is null) 
        //                    throw new ArgumentNullException();
        //                else
        //                    throw new ArgumentException("Personaggio sconosciuto", nameof(Personaggio));
        //}
        //static public int MaxPotenziamentoApplicabile(this Personaggio p)
        //{
        //    switch (p)
        //    {
        //        case Adepto a:
        //            return a.Protezione + 10;
        //            break;

        //        case Druido d:
        //            return d.Esperienza+ 100;
        //            break;

        //        case Stregone s:
        //            return s.Dominio + 10;
        //            break;

        //        case null:
        //            throw new ArgumentNullException();
        //            break;

        //        case var _:
        //            throw new ArgumentException("Personaggio sconosciuto", nameof(Personaggio));
        //            break;
        //    }


        //static public int MaxPotenziamentoApplicabile(this Personaggio p) => p switch
        //{
        //    Adepto a => a.Protezione + 10,
        //    Druido d => d.Esperienza + 100,
        //    Stregone s => s.Dominio + 200,
        //    null => throw new ArgumentNullException(nameof(Personaggio)),
        //    _ => throw new ArgumentException("Personaggio sconosciuto", nameof(Personaggio))
        //};

       
        static void Main(string[] args)
        {
            Personaggio player = new Druido();
            Console.WriteLine($"Massimo potenziamento : {player.MaxPotenziamentoApplicabile()}");            

        }
    }
}
