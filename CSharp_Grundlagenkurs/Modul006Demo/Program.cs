using Modul006Demo.LebewesenSample1;
using LebewesenSample3 = Modul006Demo.LebewesenSample3.Lebewesen;

namespace Modul006Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Sample 1: Einstieg -> Erstellen einer Instanz 
            Lebewesen lebewesen1 = new Lebewesen(); //Klasseninstanz

            //Übergabe mit Variable
            DateTime geb = new DateTime(1999, 4, 4);
            lebewesen1.SetGeburtstag(geb);

            //Kurzschreibweise
            lebewesen1.SetGeburtstag(new DateTime(1999, 5, 5));


            DateTime birthday = lebewesen1.GetGeburtstag();
            #endregion

            #region Sample2 -> Warum sind Set/Get Methoden veraltet
            lebewesen1.SetGeburtstag(new DateTime(1999, 5, 4));
            lebewesen1.Atmen();


            #endregion


            #region Sample3 Konstruktoren

            //Per Default hat jede Klasse einen Default-Konstruktor -> Dieser wird vom Kompilier intern dazugebaut. 
            LebewesenSample3.Lebewesen lebewesen = new LebewesenSample3.Lebewesen();

            //Werte Zuweisungen via Properties -> Hier muss man wissen, was befüllt werden muss
            lebewesen.Gewicht = 10;
            lebewesen.Name = "Maus";
            lebewesen.Geburtsdatum = DateTime.Now; //eben geboren 
            lebewesen.Atmen();


            LebewesenSample3.Lebewesen lebewesen2 = new LebewesenSample3.Lebewesen(DateTime.Now, "Katze", 20);
            lebewesen2.Atmen();
            
            //Properties kann man nach der Konstruktion abändern
            LebewesenSample3.Lebewesen lebewesen3 = new LebewesenSample3.Lebewesen(DateTime.Now, "Hund", 25, "Orange");
            lebewesen3.Atmen();
            lebewesen3.Name = "Wolf";
            lebewesen3.Atmen();

            //Um das manipulieren von Properties zu unterbinden, bieten sich Properties mit nur Get-Zugriff an. Hier wird über den Konstruktor die Property initialisiert und besteht,
            //solange das Objekt existiert. 
            LebewesenSample3.Lebewesen lebewesen4 = new LebewesenSample3.Lebewesen(DateTime.Now, "Hund", 25, "Orange", LebewesenSample3.UmweltTyp.Land, LebewesenSample3.Gender.Weiblich);

            #region Übergaben Übergaben von einem Object zu einem anderen Object -> Kopierkonstruktor hilft 
            //Übergaben von einem Object zu einem anderen Object (via Referenz oder Kopierkonstruktor) 
            LebewesenSample3.Lebewesen lebewesen4b = lebewesen4; //Referenz (Speichadresse) wird hier übergeben
            lebewesen4b.Gewicht = 40;

            LebewesenSample3.Lebewesen lebewesen5 = new LebewesenSample3.Lebewesen(lebewesen4); //Kopierkonstruktor wurde verwendet; 
            lebewesen5.Gewicht = 50;
            #endregion


            #region Methoden 

            LebewesenSample3.Lebewesen neugeboren1 = lebewesen5.Gebären();
            #endregion

            FileStream fileStream = new FileStream("C:\\NewFile.txt", FileMode.CreateNew);
            

            #endregion

        }
    }

   
}