﻿namespace Modul010Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ändern des durch Console verwendeten Zeichensatzes auf Unicode (damit das €-Zeichen angezeigt werden kann)
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            #region Lab 06: Fahrzeug-Klasse
            ////Deklaration einer Fahrzeug-Variablen und Initialisierung mittels einer Fahrzeug-Instanz
            //Fahrzeug fz1 = new Fahrzeug("Mercedes", 190, 23000);
            ////Ausführen der Info()-Methode des Fahrzeugs und Ausgabe in der Konsole
            //Console.WriteLine(fz1.Info() + "\n");

            ////Diverse Methodenausführungen
            //fz1.StarteMotor();
            //fz1.Beschleunige(120);
            //Console.WriteLine(fz1.Info() + "\n");

            //fz1.Beschleunige(300);
            //Console.WriteLine(fz1.Info() + "\n");

            //fz1.StoppeMotor();
            //Console.WriteLine(fz1.Info() + "\n");

            //fz1.Beschleunige(-500);
            //fz1.StoppeMotor();
            //Console.WriteLine(fz1.Info() + "\n");
            #endregion

            #region Lab 07: GC und statische Member

            ////Generierung von div. Objekten (zur Überschwemmung des RAM)
            //Fahrzeug fz1 = new Fahrzeug("BMW", 230, 25999.99);
            //for (int i = 0; i < 1000; i++)
            //{
            //    fz1 = new Fahrzeug("BMW", 230, 25999.99);
            //}

            ////Bsp-Aufruf der GarbageCollection
            //GC.Collect();
            ////Abwarten der Finalizer-Ausführungen (der Objekte)
            //GC.WaitForPendingFinalizers();

            ////Aufruf der statischen Methode
            //Console.WriteLine(Fahrzeug.ZeigeAnzahlFahrzeuge());

            #endregion

            #region Lab 08: Vererbung

            ////Instanziierung verschiedener Fahrzeuge
            //Fahrzeug fz1 = new Fahrzeug("Unbekannter Fahrzeugtyp", 190, 23000);
            //PKW pkw1 = new PKW("Mercedes", 210, 23000, 5);
            //Schiff schiff1 = new Schiff("Titanic", 40, 25000000, Schiff.SchiffsTreibstoff.Dampf);
            //Flugzeug flugzeug1 = new Flugzeug("Boing", 350, 90000000, 9800);

            ////Ausgabe der verschiedenen Info()-Methoden
            //Console.WriteLine(fz1.Info());
            //Console.WriteLine(pkw1.Info());
            //Console.WriteLine(schiff1.Info());
            //Console.WriteLine(flugzeug1.Info());

            //fz1.StarteMotor();
            //fz1.Beschleunige(12);

            //pkw1.StarteMotor();
            //pkw1.Beschleunige(123);

            #endregion

            #region Lab 09: Polymorphismus

            ////Arraydeklarierung und -initialisierung
            //Fahrzeug[] fahrzeuge = new Fahrzeug[10];

            ////Schleife über das Array zur Befüllung
            //for (int i = 0; i < fahrzeuge.Length; i++)
            //{
            //    //Aufruf der Zufallsmethode aus der Fahrzeug-Klasse
            //    fahrzeuge[i] = Fahrzeug.GeneriereFahrzeug($"_{i}");
            //}

            ////Deklarierung/Initialisierung der Zählvariablen
            //int pkws = 0, schiffe = 0, flugzeuge = 0;

            ////Schleife über das Array zur Identifizierung der Objekttypen
            //foreach (Fahrzeug fz in fahrzeuge)
            //{
            //    //Ausgabe der ToString()-Methoden
            //    Console.WriteLine(fz);
            //    //Prüfung des Objektstyps und Hochzählen der entsprechenden Variablen
            //    if (fz == null) Console.WriteLine("Kein Objekt vorhanden");
            //    else if (fz is PKW) pkws++;
            //    else if (fz is Schiff) schiffe++;
            //    else flugzeuge++;
            //}

            ////Ausgabe
            //Console.WriteLine($"Es wurden {pkws} PKW(s), {flugzeuge} Flugzeug(e) und {schiffe} Schiff(e) produziert.");
            ////Ausführung der abstrakten Methode
            //fahrzeuge[2].Hupen();

            #endregion

            #region Lab 10: Interfaces

            //Instanziierung von Bsp-Objekten
            //PKW pkw1 = new PKW("BMW", 250, 23000, 5);
            //Flugzeug flugzeug1 = new Flugzeug("Boing", 750, 3000000, 9990);
            //Schiff schiff1 = new Schiff("Titanic", 40, 3500000, Schiff.SchiffsTreibstoff.Dampf);

            ////Aufruf der Belade()-Funktion mit verschiedenen Fahrzeugen
            //BeladeFahrzeuge(pkw1, flugzeug1);
            //BeladeFahrzeuge(flugzeug1, schiff1);
            //BeladeFahrzeuge(schiff1, pkw1);

            ////Ausgabe der Info() des Schiffes
            //Console.WriteLine("\n" + schiff1.Info());

            ////Aufruf der Entlade()-Methode
            //schiff1.Entlade();

            #endregion


            Stack<Fahrzeug> stackFahrzeuge = new Stack<Fahrzeug>();
            Queue<Fahrzeug> queueFahrzeuge = new Queue<Fahrzeug>();

            //Fahrzeuge werden in Stack und Queue generiert
            for (int i = 0; i < 10; i++)
            {
                stackFahrzeuge.Push(Fahrzeug.GeneriereFahrzeug($"S_{i}"));
                queueFahrzeuge.Enqueue(Fahrzeug.GeneriereFahrzeug($"Q_{i}"));
            }

            Dictionary<Fahrzeug, Fahrzeug> fahrzeugDictionary = new Dictionary<Fahrzeug, Fahrzeug>();
            for (int i = 0; i < queueFahrzeuge.Count; i++)
            {
                Fahrzeug stackFahrzeug = stackFahrzeuge.Pop();
                Fahrzeug queueFahrzeug = queueFahrzeuge.Dequeue();

                if (queueFahrzeug is IBeladbar beladbaresFahrzeug)
                {
                    beladbaresFahrzeug.Belade(stackFahrzeug);
                    fahrzeugDictionary.Add(queueFahrzeug, stackFahrzeug);
                }
            }

            
            
            foreach (KeyValuePair<Fahrzeug, Fahrzeug> aktuellerEintrag in fahrzeugDictionary)
            {
                if (aktuellerEintrag.Key is IBeladbar beladbaresFahrzeug)
                {
                    if (aktuellerEintrag.Value is PKW)
                        Console.WriteLine($"PKW {aktuellerEintrag.Value.Name} ist in {aktuellerEintrag.Key.Name} beladen");
                    else if (aktuellerEintrag.Value is Schiff)
                        Console.WriteLine($"Schiff {aktuellerEintrag.Value.Name} ist in {aktuellerEintrag.Key.Name} beladen");
                    else
                        Console.WriteLine($"Flugzeug {aktuellerEintrag.Value.Name} ist in {aktuellerEintrag.Key.Name} beladen");
                }
            }


        }

        #region Lab 10: Interfaces (Methode)
        public static void BeladeFahrzeuge(Fahrzeug fz1, Fahrzeug fz2)
        {
            //Test, ob fz1 beladbar ist
            if (fz1 is IBeladbar beladbaresFahrzeug)
            {
                //Cast des Fahrzeuges in IBeladbar und Ausführung der Belade()-Methode
                ((IBeladbar)fz1).Belade(fz2);
            }
            //Test, ob fz2 beladbar ist
            else if (fz2 is IBeladbar)
            {
                //Cast des Fahrzeuges in IBeladbar mittels AS und Ausführung der Belade()-Methode
                (fz2 as IBeladbar).Belade(fz1);
            }
            //Fehlermeldung
            else
                Console.WriteLine("Keines der Fahrzeuge kann ein Fahrzeug transportieren.");
        }
        #endregion
    }
}