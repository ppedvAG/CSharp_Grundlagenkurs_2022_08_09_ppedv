namespace Modul007Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Dekonstruktor
            TestDekonstruktor();
            GC.Collect();
            #endregion

            //statische Methoden, Variablen und Properties hängen nicht an der Instanz
            Lebewesen lebewesen1 = new Lebewesen(DateTime.Now, "Amsel", 1, "schwarz", UmweltTyp.Luft, Gender.Männlich);

            Lebewesen lebewesen2 = new Lebewesen(DateTime.Now, "Ameise", 0.1, "schwarz", UmweltTyp.Land, Gender.Weiblich);


            #region statische Member einer Klasse
            Lebewesen.ZeigeAnzahlLebewesen(); // 2 Lebewesen müssen dargestellt werden 

            string str = "Hallo";
            string str2 = string.Empty;
            if(string.IsNullOrEmpty(str))
                Console.WriteLine("IsNullOrEmpty ist eine schöne Hilfsmethode für die String-Klasse");
            #endregion

            //Instanziierung von Bsp-Objekten
            PersonC classP = new PersonC(30, "Anna");
            PersonS structP = new PersonS(30, "Hugo");
            //Ausgabe der Alter
            Console.WriteLine($"{classP.Name}: {classP.Alter}");
            Console.WriteLine($"{structP.Name}: {structP.Alter}");

            //Übergabe des Klassenobjekts (Referenztyp):
            ///Da bei der Übergabe die Referenz des Objektes an die Methode übergeben wird, wird innerhalb der Methode
            ///das Alter des Objekts manipuliert. Im Ergebnis ist das Objekt nach der Methode ein Jahr älter geworden.
            Altern(classP);
            Console.WriteLine($"{classP.Name}: {classP.Alter}"); //alter wurde um 1 erhöht

            //Übergabe des Structobjekts (Wertetyp):
            ///Als Wertetyp wird das Objekt bei der Übergabe an die Methode kopiert. Die Methode manipuliert nur die Kopie.
            ///In dem Originalobjekt sind keine Veränderungen zu beobachten. Dieses Verhalten findet sich bei allen Wertetypen.
            Altern(structP);
            Console.WriteLine($"{structP.Name}: {structP.Alter}"); //alter wurde nicht um 1 erhöht

            //Übergabe eines Wertetypen mittels ref
            ///Ducrh ref wird auch bei Wertetypen die Referenz übergeben, wodurch hier eine Manipulation des Originalobjekts durchgeführt wird.
            Altern(ref structP);
            Console.WriteLine($"{structP.Name}: {structP.Alter}"); //alter wurde um 1 erhöht

        }

        //Ein Versuch
        public static void TestDekonstruktor()
        {
            //Object gilt nur in der Methode -> TestDekonstruktor
            Lebewesen lebewesen = new Lebewesen();
        } //Hier wird das Lebewesen quasi abgebaut -> Deconstructor wird erwartet


        //Methoden, welche jeweils die Alter-Property manipulieren
        public static void Altern(PersonC person)
        {
            person.Alter++;
        }

        public static void Altern(PersonS person)
        {
            person.Alter++;
        }

        //Mittels des REF-Stichworts können Werte als Referenzen an Methoden übergeben werden (s.u.)
        public static void Altern(ref PersonS person)
        {
            person.Alter++;
        }
    }


    #region Beispiel 1 - Statische Member

    public enum UmweltTyp { Wasser, Luft, Land }

    public enum Gender { Männlich, Weiblich, Zwitter }

    public class Lebewesen
    {
        #region Properties
        //Alles Auto-Properties -> Variablen werden beim kompilieren intern hinzugefügt
        public DateTime Geburtsdatum { get; set; }
        public string Name { get; set; }
        public double Gewicht { get; set; }

        //Neuen Version 2.0 fügen wr eine Property hinzu
        public string Farbe { get; set; }

        //Neue Version 3.0 
        public UmweltTyp Umwelt { get; }
        public Gender Gender { get; set; }

        public int AlterInJahren
        {
            get { return ((DateTime.Now - this.Geburtsdatum).Days / 365); }
        }
        #endregion

        #region Konstuktoren / Dekonstruktor
        //Default Konstrutor -> Konstruktor OHNE PARAMETER
       
        public Lebewesen()
        {
            AnzahlLebewesen++;
            //Anzahl der Lebewesen wird um 1 erhöht
        }

        //Werte-Konstruktor 
        public Lebewesen(DateTime geburtsdatum, string name, double gewicht)
            : this()
        {
            Geburtsdatum = geburtsdatum;
            Name = name;
            Gewicht = gewicht;

            
        }

        public Lebewesen(DateTime geburtsdatum, string name, double gewicht, string farbe)
            : this(geburtsdatum, name, gewicht)
        {
            Farbe = farbe;
        }

        public Lebewesen(DateTime geburtsdatum, string name, double gewicht, string farbe, UmweltTyp umweltTyp, Gender gender)
           : this(geburtsdatum, name, gewicht, farbe)
        {
            Umwelt = umweltTyp;
            Gender = gender;
        }


        //Der Kopierkonstruktor
        public Lebewesen(Lebewesen existierendesLebewesen)
        {
            this.Geburtsdatum = existierendesLebewesen.Geburtsdatum;
            this.Name = existierendesLebewesen.Name;
            this.Gewicht = existierendesLebewesen.Gewicht;
            this.Farbe = existierendesLebewesen.Farbe;
            this.Umwelt = existierendesLebewesen.Umwelt;
            this.Gender = existierendesLebewesen.Gender;
        }

        //Dekonstructor
        ~Lebewesen()
        {
            Console.WriteLine("Objekt wird abgebaut");

            AnzahlLebewesen--;
        }

        //statische Konstruktoren
        static Lebewesen()
        {
            //Hier kann man nur statische Variablen oder Properties initialisieren
            //wird auch nur 1x insgesamt aufgerufen 
            AnzahlLebewesen = 0; //
        }

        #endregion

        #region Methoden
        public void Atmen()
        {
            Console.WriteLine($"{Name} atmet");

        }

        public Lebewesen Gebären()
        {
            if (Gender == Gender.Männlich)
            {
                //Fehlermeldung wäre hier der beste Weg
                throw new Exception("Ein männliches Lebewesen kann kein Lebewesen zur Welt bringen");
            }
            
            return new Lebewesen(DateTime.Now, this.Name, new Random().Next(1, 10), "schwarz", this.Umwelt, (Gender)(new Random().Next(0, 3)));
        }
        #endregion

        #region statische Member
        //STATISCHE Variablen und Methoden hängen an der Klasse selbst und nicht an instanziierten Objekten. Sie existieren demnach unabhängig von der Anzahl
        ///Objekte genau einmal. Der Aufruf erfolgt über den Klassenbezeichner.

        //statische Variablen 'AnzahlLebewesen' existiert nur 1x im Arbeitsspeicher
        public static int AnzahlLebewesen { get; set; } = 0; //Initialisiere die statische Property mit 0 


        //Wird via Lebewesen.ZeigeAnzahlLebewesen() aufgerufen
        public static string ZeigeAnzahlLebewesen()
        {
            WeitereStatischeMethode();
            return $"Es gibt {AnzahlLebewesen}";
            
        }

        public static void WeitereStatischeMethode()
           => Console.WriteLine("Hallo");
        #endregion
    }
    #endregion

    public class PersonC
    {
        public int Alter { get; set; }
        public string Name { get; set; }

        public PersonC(int a, string n)
        {
            Alter = a;
            Name = n;
        }
    }

    //Struct, dessen Objekte, wie sämtliche Basisdatentypen, als WERTETYPEN betrachtet werden
    public struct PersonS
    {
        public int Alter { get; set; }
        public string Name { get; set; }

        public PersonS(int a, string n)
        {
            Alter = a;
            Name = n;
        }
    }
}