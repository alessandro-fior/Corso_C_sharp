using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Generics1
{
  interface IDuplicabile
  {
    public IDuplicabile Clona();
  }

  class Documento : IDuplicabile
  {
    public string Testo { get; set; }
    public Documento(string testo) { Testo = testo; }
    public IDuplicabile Clona() { return new Documento("il clone"); }

  }

  class FigliaDiDocumento : Documento
  {
    public FigliaDiDocumento(string testo) : base(testo) { }
    public FigliaDiDocumento() : base("") { }
  }

  class NipoteDiDocumento : FigliaDiDocumento
  {
    public NipoteDiDocumento(string testo) : base(testo) { }
    public NipoteDiDocumento() : base("") { }
  }

  class MyList<T, U> where T: IDuplicabile , new()
                     where U : T
  {
    int capacita { get; set; } = 2;
    T[] v = null;
    int inseriti = 0;
    public int count { get { return inseriti; } }

    public MyList() { v = new T[capacita];  }

    public void Add(T nuovo)
    {
      nuovo.Clona();
      if (inseriti == capacita) Espandi();
      v[inseriti] = nuovo; inseriti++;

    }

    public void Espandi(int di_quanto = 2)
    {
      T[] nuovo = new T[capacita + di_quanto];
      v.CopyTo(nuovo, 0);
      v = nuovo;
      capacita += di_quanto;       
    }

    public T this [int posizione]
    {
      get { return v[posizione];  }
      set { v[posizione] = value; }
    }
  }

  //Credits: Giovanni De Rosa
  public interface IEntity
  {
    int Id { get; set; }
  }
  
 
  public abstract class Entity : IEntity
  {
    public int Id { get; set; }
  }

  public class Studente : Entity
  {
  }

  public class Repository<T> where T : IEntity, new()
  {
    private readonly IList<T> records = Array.Empty<T>();

    public T Get(int id)
    {
      // Possiamo accedere alla proprietà Id perchè T rispetta IEntity
      return records.FirstOrDefault(e => e.Id == id);
    }

    public void Remove(int id)
    {
      T entity = records.FirstOrDefault(e => e.Id == id);
      records.Remove(entity);
    }

    public void Add(T entity) { }
    public void Update(int id, T entity) { }
    public IEnumerable<T> List() => records;
    public T Create() { return new T(); }
  }

  //Doppio parametro generic per non essere vincolati al tipo int per la chiave primaria
  public interface IEntity<T>
  {
    T Id { get; set; }
  }

  public abstract class Entity2<T> : IEntity<T>
  {
    public T Id { get; set; }
  }

  public class Studente2 : Entity2<string>
  {
  }

  public class Repository2<TId, TEntity> where TEntity : IEntity<TId>, new()  // DOPPIO SEGNAPOSTO
  {
    private readonly IList<TEntity> records = Array.Empty<TEntity>();
    public TEntity Get(TId id)
    {
      // Possiamo accedere alla proprietà Id perchè T rispetta IEntity
      return records.FirstOrDefault(e => e.Id.Equals(id));
    }
    public void Remove(TId id)
    {
      TEntity entity = records.FirstOrDefault(e => e.Id.Equals(id));
      records.Remove(entity);
    }
    public void Add(TEntity entity) { }
    public void Update(TId id, TEntity entiity) { }
    public IEnumerable<TEntity> List() => records;
    public TEntity Create() { return new TEntity(); }
  }


  class Program
  {
    static void Main(string[] args)
    {
      //MyList<int> listaInteri = new MyList<int>();

      //MyList<string> listaStringhe = new MyList<string>();
      //listaStringhe.Add("prima");
      //listaStringhe.Add("seconda");
      //listaStringhe.Add("terza");

      //for (int i = 0; i < listaStringhe.count; i++)
      //  Console.WriteLine(listaStringhe[i]);


      MyList<FigliaDiDocumento, NipoteDiDocumento> listaDocumenti = 
                new MyList<FigliaDiDocumento, NipoteDiDocumento>();

      Repository<Studente> studentiRepository = new Repository<Studente>();
      Studente studente = studentiRepository.Create();
      Console.ReadKey();

      Repository2<string, Studente2> studentiRepository2 = new Repository2<string, Studente2>();
      Studente2 studente2 = studentiRepository2.Create();
      Console.ReadKey();
    }
  }
}
