using Modul1415Demo.Extentsions;
using System.Linq;

namespace Modul1415Demo
{
    internal class Program
    {
        private static IList<Person> personenListe = new List<Person>();
        static void Main(string[] args)
        {
            #region Was ist eine Erweiterungsmethode (Extentionsmethod) 
            Person person = new(1, "Otto Walkes", 59);
            person.SavePerson("Person.json");
            #endregion


            #region Linq und Lambda
            //Linq 101 Samples 
            //https://linqsamples.com/linq-to-objects/element/First-conditional
            //https://github.com/dotnet/try-samples/tree/main/101-linq-samples


            //Linq und Lambda wird verwendet um mit List zu arbeiten -> Es ist wie SQL für Listen zu sehen
            //Mit System.Linq bieten sich bei jedem Array, IList, List, ICollection etc... zusätzliche Linq-Funktionen an.

           
            personenListe.Add(new Person(1, "Otto", 44));
            personenListe.Add(new Person(2, "Eva", 21));
            personenListe.Add(new Person(3, "Karl", 34));

            personenListe.Add(new Person(4, "Hannes", 56));
            personenListe.Add(new Person(5, "Andre", 78));
            personenListe.Add(new Person(6, "Bill", 12));

            personenListe.Add(new Person(7, "James", 32));
            personenListe.Add(new Person(8, "Anna", 23));
            personenListe.Add(new Person(9, "Lena", 29));

            //Ganz früher gab es noch die Linq-Statements

            IList<Person> personenUnter30 = (from p in personenListe
                                             where p.Alter < 30
                                             orderby p.Name
                                             select p).ToList();

            //Heute gibt es Linq-Functionen die als Parameter Lambdas verwenden
            personenUnter30 = personenListe.Where(p => p.Alter < 30)
                                           .OrderBy(p => p.Name)
                                           .ToList();


            GetPersonsByWhereStatement(p => p.Alter < 30);
            //Linq-Statements und Linq-Functionen sind beide genauso schnell -> Es werden aber Linq-Functions verwendet. 

            #endregion

            #region Weitere Linq Methoden
            double altersdurschnittAllerPersonen = personenListe.Average(p => p.Alter);

            double altersdurschnittAllerPersonenUeber30 = personenListe.Where(p => p.Alter > 30)
                                                                       .Average(p => p.Alter);

            int gesamtesAlterAllerPersonen = personenListe.Sum(s => s.Alter);
            #endregion

            #region Einzelene Datensätze ermitteln
            //Eine Person MUSS in der Liste sein
            Person erstePersonInListe = personenListe.First();

            //Es kann auch eine Leere Liste vorhanden sein, dann so ->
            Person? erstePersonOderDefault = personenListe.FirstOrDefault(); //Default ist nullable Person 

            Person letztePerson = personenListe.Last(); //LastOrDefault -> wie bei FirstOrDefault

            //GetById
            Person nurEinePerson = personenListe.Single(p => p.Id == 1);

            #endregion


            #region Anzahl von Datensätzen

            //Schnellste Variante um deine Anzahl an Datensätzen in einer kompletten Liste zu ermitteln
            int count = personenListe.Count;

            //wenn wir nach einem Kriterium die Anzahl abfragen -> z.B Anzahl der Personen über 30  
            count = personenListe.Count(p => p.Alter > 30);

            //Allgemein können wir fragen, ob überhaupt nach einem Kriterium Personen vorhanden sind

            bool jemandDa = personenListe.Any(p => p.Alter > 200);
            #endregion

            #region Paging
            IList<Person> seite1 = PagingMethode(1, 3);
            IList<Person> seite2 = PagingMethode(2, 3);
            IList<Person> seite3 = PagingMethode(3, 3);


            IList<Person> seite1Aber5Datensätze = PagingMethode(1, 5);
            #endregion

        }

        public static IList<Person> GetPersonsByWhereStatement(Func<Person, bool> predicate)
            => personenListe.Where(predicate).ToList();


        /// <summary>
        /// Paging Methode gibt Paketweise Datensätze zurück 
        /// </summary>
        /// <param name="pagingNumder">Seiten-Nummer</param>
        /// <param name="pagingSize">Anzahl der gelieferten Datensätze pro Seite</param>
        /// <returns></returns>
        public static IList<Person> PagingMethode(int pagingNumder, int pagingSize=3)
        {
            return personenListe.Skip((pagingNumder - 1) * pagingSize).Take(pagingSize).ToList();
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Alter { get; set; }

        public Person(int id, string name, int alter)
        {
            Id = id;
            Name = name;
            Alter = alter;
        }
    }
}