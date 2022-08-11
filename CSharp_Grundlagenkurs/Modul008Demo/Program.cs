namespace Modul008Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Vererbung  Sample 1 - Einfache Vererbung
            Mensch mensch = new Mensch(DateTime.Now, "Homosapiens", 80, "europäisch", UmweltTyp.Land, Gender.Männlich, "Max", "Muster", "Frankfurt", null);
            Mensch mensch1 = new Mensch(DateTime.Now, "Homosapiens", 80, "europäisch", UmweltTyp.Land, Gender.Männlich, "Max", "Muster", "Frankfurt", null);
            Mensch mensch2 = new Mensch(DateTime.Now, "Homosapiens", 80, "europäisch", UmweltTyp.Land, Gender.Männlich, "Max", "Muster", "Frankfurt", null);
            Mensch mensch3 = new Mensch(DateTime.Now, "Homosapiens", 80, "europäisch", UmweltTyp.Land, Gender.Männlich, "Max", "Muster", "Frankfurt", null);
            
            Lebewesen lebewesen1 = new Lebewesen(DateTime.Now, "Amsel", 1, "schwarz", UmweltTyp.Luft, Gender.Männlich);
            Lebewesen lebewesen2 = new Lebewesen(DateTime.Now, "Ameise", 0.1, "schwarz", UmweltTyp.Land, Gender.Weiblich);

            Console.WriteLine(Mensch.ZeigeAnzahlLebewesen());
            Console.WriteLine(Mensch.ZeigeAnzahlMenschen());
            #endregion

            #region Vererbung mit sealed unterbinden
            MySqlConnectionClass mySqlConnectionClass = new ();
            MySqlConnectionClass mySqlConnectionClass2 = new MySqlConnectionClass();
            #endregion


            #region virtual - Methoden
            Console.WriteLine("--- override ToString für Lebewesen ---");
            Console.WriteLine(lebewesen1.ToString());
            Console.WriteLine();
            Console.WriteLine("--- override ToString für Mensch ---");
            Console.WriteLine("---- Klasse Mensch findet in seiner Klasse keine ToString() und schaut eine Klasse höher, ob es eine ToString() gibt");
            Console.WriteLine(mensch.ToString());
            #endregion
        }
    }



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
        public virtual Gender Gender { get; set; }

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
            return $"Es gibt {AnzahlLebewesen} Lebewesen";

        }

        public static void WeitereStatischeMethode()
           => Console.WriteLine("Hallo");
        #endregion

        #region Vererbung -> Virtual / Override
        //Mit  public sealed override string ToString() kann man ToString() deaktiviert nach unten das Keyword override 
        public override string ToString()
        {
            //Use Case: Können die Basis-Implementierung von base.ToString() weiterhin verwenden und mit der neuen Implementierung kombinieren
            //string getTypeStr = base.ToString();

            return $"{base.ToString()} beinhaltet folgende Variablen\nName:\t\t{Name}\nGeburtstag\t{Geburtsdatum}\nGewicht:\t{Gewicht}\n";
        }
        public virtual void Kommunizieren()
        {
            Console.WriteLine("Lebewesen kommuniziert");
        }
        #endregion
    }

    public class Mensch : Lebewesen
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Wohnort { get; set; }

        public bool? Führerschein { get; set; } = null;


        #region Konstruktoren bei vererbten Klassen
        public Mensch(DateTime geburtsdatum, string name, double gewicht, string farbe, UmweltTyp umweltTyp, Gender gender, 
            string firstName, string lastName, string wohnort, bool? führerschein)
            : base (geburtsdatum, name, gewicht, farbe, umweltTyp, gender)

        {
            AnzahlMenschen++;
            Firstname = firstName;
            Lastname = lastName;
            Wohnort = wohnort;
            Führerschein = führerschein;
        }
        #endregion

        public void Programmieren()
        {
            Console.WriteLine($"{Firstname} {Lastname} programmiert");
        }

        public void Lesen()
        {
            Console.WriteLine($"{Firstname} {Lastname} liest");
        }

        public void Schreiben()
        {
            Console.WriteLine($"{Firstname} {Lastname} schreibt");
        }

        public void AutoFahren()
        {
            //nicht alle Menschen können das
            if (Führerschein.HasValue)
            {
                Console.WriteLine("Mensch fährt wegen Führerscheinlizenz Auto");
            }
            else
                Console.WriteLine("Darf kein Auto fahren");
        }

        public static int AnzahlMenschen { get; set; } = 0;

        public static string ZeigeAnzahlMenschen()
        {
            WeitereStatischeMethode();
            return $"Es gibt {AnzahlMenschen} Menschen";

        }

        public override string ToString()
        {
            return $"{base.ToString()}\nVorname:\t{Firstname}\nNachname:\t{Lastname}";
        }

        public override void Kommunizieren()
        {
            Console.WriteLine("Mensch kommuniziert über Sprache");
        }

        public override Gender Gender 
        { 
            get => base.Gender; 
            set
            {
                if (value == Gender.Zwitter)
                    throw new Exception("Bei einem Menschen können wir nur Frau oder Mann zuweisen");

                base.Gender = value;
            }
        }
    }



    #region Mit dem Schlüsselwort sealed können wir nicht von MySqlConnectionClass vererben
    public sealed class MySqlConnectionClass
    {
        public int Timeout { get; set; } = 1800; //Timeout in Sekunden

        public void OpenConnection(string username, string passwort)
        {
            //Öffne Db
        }
    }
    #endregion





}