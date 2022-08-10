
namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            //Aufruf der Addiere(dbl,dbl)-Funktion

            int a = 5;
            int b = 3;
            double summe = Addiere(a, b);
            Console.WriteLine(summe);

            summe = Addiere(3.6, 4.8);
            summe = Addiere(3, 4, 5);

            BildeSumme(2, 4, 6, 8, 10, 12, 14);
            BildeSumme(2, 4, 6, 8);

            Subtrahiere(10, 3, 3, 1);
            Subtrahiere(10, 5); //c = 0 und d = 0



            //Aufruf der Out-Funktion
            int zahl = 5;

            int diff = 0;
            summe = AddiereUndSubtrahiere(10, zahl, out diff);
            //Ausgabe
            Console.WriteLine(diff);
            Console.WriteLine(summe);

        }

        //Jede Funktion/Methode besteht aus einem Kopf und einem Körper
        ///Der Kopf besteht aus den MODIFIERN (public static), dem RÜCKGABEWERT (int), dem NAMEN (Addiere) sowie den ÜBERGABEPARAMETERN
        static int Addiere(int a, int b)
        {
            //Der RETURN-Befehl weist die Methode an einen Wert als Rückgabewert an den Aufrufe zurückzugeben
            return a + b;
        }

        static int Addiere(int a, int b, int c)
            => Addiere(a,b) + c; //Kurzschreibweise > Return muss man hier nicht angeben 

        //Funktion, welche den gleichen Bezeichner haben, nennt man ÜBERLADENE Funktionen. Diese müssen sich in Anzahl und/oder Art der 
        ///Übergabeparameter unterscheiden, damit der Aufruf eindeutig ist.
        static double Addiere(double a, double b)
        {
            return a + b;
        }


        //Das PARAMS-Stichwort erlaubt die Übergabe einer beliebige Anzahl von gleichartigen Daten, welche innerhalb
        //der Methode als Array interpretiert werden
        static int BildeSumme(params int[] summanden)
        {
            int summe = 0;

            foreach (int summand in summanden)
                summe += summand;

            return summe;
        }


        ///Wird einem Parameter mittels =-Zeichen ein Defaultwert zugewiesen wird dieser Parameter OPTIONAL und muss bei Aufruf nicht zwangs-
        ///läufig mitgegeben werden. OPTIONALE Parameter müssen am Ende der Parameter stehen.
        static int Subtrahiere(int a, int b, int c = 0, int d = 0)
        {
            return a - b - c - d;
        }

        //Das OUT-Stichwort ermöglich einer Methode mehr als einen Rückgabewert zu haben. Dabei kann die Variable direkt in der Funktions-
        ///übergabe deklariert werden
        static int AddiereUndSubtrahiere(int a, int b, out int differenz)
        {
            differenz = a - b;
            return a + b;
        }
    }
}