namespace Modul009Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }


    public enum UmweltTyp { Wasser, Luft, Land }

    public enum Gender { Männlich, Weiblich, Zwitter }

    public abstract class Lebewesen
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

        public abstract Lebewesen Gebären();

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
}