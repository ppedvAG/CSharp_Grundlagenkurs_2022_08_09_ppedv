using System.Data.SqlClient;

namespace Modul010Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region ICloneable - Beispiel
            Achterbahn achterbahn = new() { Geschwindigkeit = 500, KloAnzahl = 12, LaengerDerStrecke = 500, MitarbeiterAnzahl = 10 };

            Achterbahn neueAchterbahn = (Achterbahn)achterbahn.Clone();

            neueAchterbahn.MitarbeiterAnzahl = 4;

            Achterbahn eineReferenzZuweisung = achterbahn;
            eineReferenzZuweisung.MitarbeiterAnzahl = 123;
            #endregion

            #region ICompare
            #region ICompareable
            Achterbahn achterbahnA = new() { Geschwindigkeit = 500, KloAnzahl = 12, LaengerDerStrecke = 500, MitarbeiterAnzahl = 10 };
            Achterbahn achterbahnB = new() { Geschwindigkeit = 500, KloAnzahl = 12, LaengerDerStrecke = 500, MitarbeiterAnzahl = 10 };

            //Bei Referenztrypen werden die Speicheradresse verglichen 
            if (achterbahnA == achterbahnB)
            {
                Console.WriteLine("Referenzadresse ist gleich");
            }
            else
            {
                Console.WriteLine("ungleich");
            }

            if (Convert.ToBoolean(achterbahnA.CompareTo(achterbahnB)) )
            {
                Console.WriteLine("haben die selben Werte");
            }
            else
                Console.WriteLine("unterschiedliche Werte");
            #endregion
            #endregion

            #region 1.) Impliziete und Expliziete Implementierung von Interfaces 2.) Polymorphie mit Interfaces
            List<Jahrmarktstand> jahrmarktstaende = new List<Jahrmarktstand>();
            jahrmarktstaende.Add(new Autoscooter() { Bezeichnung = "Andres AutoScooter", AnzahlAnScooter = 12, FahrzeitInMinuten=5, MitarbeiterAnzahl=3 }) ;
            jahrmarktstaende.Add(new HorrorCabinet() { Bezeichnung = "Jedis Horrorcabinet", KloAnzahl = 1, MitarbeiterAnzahl = 2, SchockerAnzahl=2 });
            jahrmarktstaende.Add(new SpiegelCabinet() { Bezeichnung = "Kevins Spiegelkabinet", KloAnzahl = 12, MitarbeiterAnzahl = 4, Wegstrecke =50 }) ;
            jahrmarktstaende.Add(new Achterbahn() { Bezeichnung = "Hannes Achterbahn", KloAnzahl = 12, Geschwindigkeit = 300, MitarbeiterAnzahl = 10, LaengerDerStrecke = 10000 });
            jahrmarktstaende.Add(new Freakshow() { Bezeichnung = "Schwischtenberks Freakshow", MitarbeiterAnzahl = 1 });
            jahrmarktstaende.Add(new MultipleWildwasserrutsche() { Bezeichnung = "Sandras Wildwasserpark", MitarbeiterAnzahl = 4 });
            int alterVonFritz = 16;

            foreach(Jahrmarktstand aktuellerJahrmarktstand in jahrmarktstaende)
            {
                //Anti-Beispiel -> Nie so machen!!!
                //if (aktuellerJahrmarktstand is IFSK18)
                //{
                //    if (aktuellerJahrmarktstand is HorrorCabinet horrorCabinett)
                //    { 
                //        //horrorCabinett.AgeCheck
                //        horrorCabinett.KloAnzahl
                //    }
                //}

                //Wir bemerkten beim dem unbekannten Objekt, dass ein IFSK18 Interface vorhanden ist und casten das Objekt nach IFSK18 so, dass wir AgeCheck dann aufrufen können.

                if (aktuellerJahrmarktstand is IFSK16 jahrmarktstandMitFSK16)
                {
                    if (jahrmarktstandMitFSK16.AgeCheck(alterVonFritz))
                    {
                        Console.WriteLine($"Fritz darf {aktuellerJahrmarktstand.Bezeichnung}");
                    }
                    else
                    {
                        Console.WriteLine($"Fritz darf kein {aktuellerJahrmarktstand.Bezeichnung}");
                    }
                }
                
                if (aktuellerJahrmarktstand is IFSK18 jahrmarktstandMitFSK18)
                {
                    
                    if (jahrmarktstandMitFSK18.AgeCheck(alterVonFritz))
                    {
                        Console.WriteLine($"Fritz darf {aktuellerJahrmarktstand.Bezeichnung}");
                    }
                    else
                    {
                        Console.WriteLine($"Fritz darf kein {aktuellerJahrmarktstand.Bezeichnung}");
                    }
                }
                
                if ((aktuellerJahrmarktstand is not IFSK16) && (aktuellerJahrmarktstand is not IFSK18))
                {
                    Console.WriteLine($"Fritz darf {aktuellerJahrmarktstand.Bezeichnung} und das OHNE Altersprüfung....yeees");
                }

                

                if (aktuellerJahrmarktstand is IToilets)
                {
                    IToilets toilets = (IToilets)aktuellerJahrmarktstand;
                    Console.WriteLine($"Fritz geht eine von {toilets.KloAnzahl} verfügbaren Toiletten. Bei der Attraktion {aktuellerJahrmarktstand.Bezeichnung}");
                }

                
            }

            #endregion


            #region 2.) Wichtige Interfaces aus der .NET Welt

            #region 2.1) IDispose - Interface

            //FRÜHER bis .NET Framework 3.x
            SqlConnection connection = new SqlConnection("MySQLServer Irgendein ConnectionString ");
            FileStream fileStream = new FileStream("C:\\abc.txt", FileMode.Create);
            try
            {
                //1.) connection.Open(); -> hier würde es einen Fehler geben, weil wir keine SQL Datenbank gerade vorliegen haben 
                //..Und es passiert irgendein Fehler beim Import


                //stream bekommt Daten und schreibt
                //..es passiert ein Fehler bein schreiben
            }
            finally
            {
                //Wird immer aufgerufen (Im Normalfall + Fehlerfall) -> für Aufräumarbeiten 
                connection.Close(); //Schließen der Connection muss garantiert aufgerufen werden -> daher finally - Block
                connection.Dispose();

                fileStream.Close(); //selber Fall wie bei SQLConnection
                fileStream.Dispose();
            }
            #endregion

            //AB .NET Framework 3.x gab es das using-Statement
            using (SqlConnection connection1 = new SqlConnection("anyConnectionString"))
            {

            } //Beim Verlassen des using-Blocks wird auftomatisch connection1.Dispose aufgerufen 

            //Für using benötigen wir das IDisposable Interface
            using (Autoscooter autoscooter = new())
            {

            }


            #endregion
        }
    }


    
    public class Jahrmarktstand
    {
        public string Bezeichnung { get; set; }
        public int MitarbeiterAnzahl { get; set; }
    }

    //Anti-Beispiel -> Niemals für kleinen Aspekte die Vererbung umbiegen -> Bitte niemals machen!!!!
    public class JahrmarktstandÜber18 : Jahrmarktstand
    {
        public bool AgeCheck(int Alter)
        {
            //....

            return false; 
        }
    }

    public class Autoscooter : Jahrmarktstand, IDisposable
    {
        public int AnzahlAnScooter { get; set; }

        public int FahrzeitInMinuten { get; set; }

        public void Dispose()
        {
            AnzahlAnScooter = 0;
            FahrzeitInMinuten = 0; 

            //Und weitere Aufräumarbeiten 
        }
    }

    public class Achterbahn : Jahrmarktstand, IFSK18, IToilets, ICloneable, IComparable
    {
        public double Geschwindigkeit { get; set; }
        public int LaengerDerStrecke { get; set; }
        public int KloAnzahl { get; set; } = 12;

        public void StartDerAchterbahn() { }


        //Durch das Interface 
        public bool AgeCheck(int age)
        {
            return age >= 18 ? true : false;
        }


        //Wir wollen eine Kopie (Klon) von der Achterbahn
        public object Clone()
        {
            //Neuer Speicher = kopie eine Achterbahn (Nicht Referenz) 
            return new Achterbahn() { Bezeichnung = this.Bezeichnung, Geschwindigkeit = this.Geschwindigkeit, KloAnzahl = this.KloAnzahl, LaengerDerStrecke = this.LaengerDerStrecke, MitarbeiterAnzahl = this.MitarbeiterAnzahl };
        }

        public int CompareTo(object? obj)
        {
            if (obj == null)
                return 0;

            Achterbahn achterbahnToCheck = (Achterbahn)obj;

            if (this.Bezeichnung != achterbahnToCheck.Bezeichnung)
                return 0;

            if (this.MitarbeiterAnzahl != achterbahnToCheck.MitarbeiterAnzahl)
                return 0;

            if (this.LaengerDerStrecke != achterbahnToCheck.LaengerDerStrecke)
                return 0;

            if (this.KloAnzahl != achterbahnToCheck.KloAnzahl)
                return 0;

            if (this.Geschwindigkeit != achterbahnToCheck.Geschwindigkeit)
                return 0;


            //Ist True = 1
            return 1;
        }
    }

    public class HorrorCabinet : Jahrmarktstand, IFSK18, IToilets
    {
        public int SchockerAnzahl { get; set; }
        public int KloAnzahl { get; set; } = 8;

        public bool AgeCheck(int age)
        {
            return age >= 18 ? true : false;
        }
    }

    public class SpiegelCabinet : Jahrmarktstand, IToilets
    {
        public int Wegstrecke { get; set; }
        public int KloAnzahl { get; set; } = 4; //Defaultwerte -> diese werden weiter oben überschrieben 
    }

    public class Freakshow : Jahrmarktstand, IFSK18
    {
        public bool AgeCheck(int age)
        {
            return age >= 18 ? true : false;
        }
    }

    public class MultipleWildwasserrutsche : Jahrmarktstand, IFSK18, IFSK16
    {
        //Expliziete Implementierung -> Hier wird der Interface-Name vorneweg mit angegeben 
        bool IFSK18.AgeCheck(int age)
        {
            return age >= 18 ? true : false;
        }

        bool IFSK16.AgeCheck(int age)
        {
            return age >= 16 ? true : false;
        }
    }

    //Alle Interface Methoden / Properties sind public -> Man muss kein public angeben 
    public interface IFSK18
    {
        bool AgeCheck(int age);
    }

    public interface IFSK16
    {
        bool AgeCheck(int age);
    }

    public interface IToilets
    {
        int KloAnzahl { get; set; }
    }







}