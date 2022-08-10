namespace Momdul007Lab
{
    public class Fahrzeug
    {
        #region Lab 06: Properties, Methoden, Konstruktor

        //Properties
        public string Name { get; set; }
        public int MaxGeschwindigkeit { get; set; }
        public int AktGeschwindigkeit { get; set; }
        public double Preis { get; set; }
        public bool MotorLäuft { get; set; }

        //Konstruktor mit Übergabeparametern und Standartwerten
        public Fahrzeug(string name, int maxG, double preis)
        {
            this.Name = name;
            this.MaxGeschwindigkeit = maxG;
            this.Preis = preis;
            this.AktGeschwindigkeit = 0;
            this.MotorLäuft = false;
        }

        //Methode zur Ausgabe von Objektinformationen
        public string Info()
        {
            if (this.MotorLäuft)
                return $"{this.Name} kostet {this.Preis}€ und fährt momentan mit {this.AktGeschwindigkeit} von maximal {this.MaxGeschwindigkeit}km/h.";
            else
                return $"{this.Name} kostet {this.Preis}€ und könnte maximal {this.MaxGeschwindigkeit}km/h fahren.";
        }

        //Methode zum Starten des Motors
        public void StarteMotor()
        {
            if (this.MotorLäuft)
                Console.WriteLine($"Der Motor von {this.Name} läuft bereits.");
            else
            {
                this.MotorLäuft = true;
                Console.WriteLine($"Der Motor von {this.Name} wurde gestartet.");
            }
        }

        //Methode zum Stoppen des Motors
        public void StoppeMotor()
        {
            if (!this.MotorLäuft)
                Console.WriteLine($"Der Motor von {this.Name} ist bereits gestoppt");
            else if (this.AktGeschwindigkeit > 0)
                Console.WriteLine($"Der Motor kann nicht gestoppt werden, da sich {this.Name} noch bewegt");
            else
            {
                this.MotorLäuft = false;
                Console.WriteLine($"Der Motor von {this.Name} wurde gestoppt.");
            }
        }

        //Methode zum Beschleunigen und Bremsen
        public void Beschleunige(int a)
        {
            if (this.MotorLäuft)
            {
                if (this.AktGeschwindigkeit + a > this.MaxGeschwindigkeit)
                    this.AktGeschwindigkeit = this.MaxGeschwindigkeit;
                else if (this.AktGeschwindigkeit + a < 0)
                    this.AktGeschwindigkeit = 0;
                else
                    this.AktGeschwindigkeit += a;

                Console.WriteLine($"{this.Name} bewegt sich jetzt mit {this.AktGeschwindigkeit}km/h");
            }
        }

        public void Bremsen()
        {
            if (AktGeschwindigkeit > 0)
            {
                if (AktGeschwindigkeit < 20)
                    AktGeschwindigkeit = 0;
                else AktGeschwindigkeit -= 20;
            }
        }

        #endregion


        #region Lab 07: Statische Member, Destruktor

        public static int AnzahlFahrzeuge { get; set; } = 0;

        public static string ZeigeAnzahlFahrzeuge()
        {
            return $"Es wurden {AnzahlFahrzeuge} Fahrzeuge gebaut.";
        }

        ~Fahrzeug()
        {
            Console.WriteLine($"{this.Name} wurde gerade verschrottet.");
        }

        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Ändern des durch Console verwendeten Zeichensatzes auf Unicode (damit das €-Zeichen angezeigt werden kann)
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            #region Lab 06: Fahrzeug-Klasse
            //Deklaration einer Fahrzeug-Variablen und Initialisierung mittels einer Fahrzeug-Instanz
            Fahrzeug fz1 = new Fahrzeug("Mercedes", 190, 23000);
            //Ausführen der Info()-Methode des Fahrzeugs und Ausgabe in der Konsole
            Console.WriteLine(fz1.Info() + "\n");

            //Diverse Methodenausführungen
            fz1.StarteMotor();
            fz1.Beschleunige(120);
            Console.WriteLine(fz1.Info() + "\n");

            fz1.Beschleunige(300);
            Console.WriteLine(fz1.Info() + "\n");

            fz1.StoppeMotor();
            Console.WriteLine(fz1.Info() + "\n");

            fz1.Beschleunige(-500);
            fz1.StoppeMotor();
            Console.WriteLine(fz1.Info() + "\n");
            #endregion


            //Generierung von div. Objekten (zur Überschwemmung des RAM)
            Fahrzeug fz2 = new Fahrzeug("BMW", 230, 25999.99);
            
            for (int i = 0; i < 1000; i++)
            {
                fz1 = new Fahrzeug("BMW", 230, 25999.99);
            }

            //Bsp-Aufruf der GarbageCollection
            GC.Collect();
            //Abwarten der Finalizer-Ausführungen (der Objekte)
            GC.WaitForPendingFinalizers();

            //Aufruf der statischen Methode
            Console.WriteLine(Fahrzeug.ZeigeAnzahlFahrzeuge());

#endregion
        }
    }
}