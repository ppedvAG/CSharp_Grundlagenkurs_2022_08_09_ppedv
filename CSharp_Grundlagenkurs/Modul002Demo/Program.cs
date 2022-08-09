using System;

namespace Application
{
    class Program
    {
        //Main Methode wird als Einstiegs-Methode benutzt
        //Im Endeffekt wird nach einer Program.Main gesucht
        static void Main(string[] args)
        {
            #region Datentypen

            #region Ganzzalige Datentypen
            //Definieren einer Variable
            int age2;
            //Variable einen Wert zuweisen
            age2 = 34;

            //Definition und Initialisierung in einem 
            int age = 33;

            Console.WriteLine(age);


            //short
            short maxShortValue = short.MaxValue; //32767 
            short minShortValue = short.MinValue; //-32768


            //long
            long maxLongValue = long.MaxValue;
            long minLongValue = long.MinValue;

            //byte
            byte maxByteValue = byte.MaxValue;
            byte minByteValue = byte.MinValue;

            //unsigned short von 0 -> 65.535
            ushort maxUIntValue = ushort.MaxValue;
            ushort minUIntValue = ushort.MinValue;

            #endregion


            #region Gleitkomma Datentypen 
            double doubleValue = 3.14;
            float floatValue = 3.14f; //f wird als Suffix verwendet um am Wert darzustellen, dass es sich um ein float-Format handelt
            decimal moneyValue = 3_000_000m; //m wird als Suffice verwendet um einen Geldbetrag bzw. Decimal Value darzustellen. 
            #endregion

            #region Zeichen-Datentypen

            //Beispiel für eine Char-Variable 
            char textzeichen = 'A'; //Hier verwendest du die Asscii-Tabelle (A = 65) 
            string textzeichenkette = "Hallo, ich sitze gerade in Berlin!";
            Console.WriteLine(textzeichenkette);
            #endregion
            #endregion


            #region Ausgabe von Variablen in Console
            Console.WriteLine("Der maximale Wert einer Short-Variable ist: " + maxShortValue);

            //printf-Befehl (C/C++ weitervererbt)
            Console.WriteLine("Der minimale Wert einer Short-Variable ist: {0}", minShortValue);
            Console.WriteLine("Der minimale und maximale Wert einer Short Variable ist -> min: {0} und max {1} ", minShortValue, maxShortValue);

            //dritte Ausgabe-Variante und ist auch die Beste
            Console.WriteLine($"Der minimale und maximale Wert einer Short Variable ist -> min: {minShortValue} und max {maxShortValue}");


            int a = 45;
            int b = 12;

            Console.WriteLine($"{a} + {b} = {a+b}"); //45 + 12 = 57

            //Escape-Sequenzen -> wird von fast allen Programmiersprachen verwendet 
            //https://docs.microsoft.com/de-de/cpp/c-language/escape-sequences?view=msvc-170

            string bsp = "Dies ist ein \t Tabulator und dies ein \nZeilenumbruch";
            Console.WriteLine(bsp);

            //Bsp für Pfadausgabe mittels Escape-Sequenzen
            string path = "C:\\Windows\\Temp";

            string betterPath = @"C:\Windows\Temp";//intern im String wird allerdings C:\\Windows\\Temp verwendet
            Console.WriteLine(betterPath);
            string betterPathWithDynamicSubFolder = $@"{betterPath}\CSharpSchulung\bin"; // C:\\Windows\\Temp\\CSharpSchulung\\bin
            Console.WriteLine(betterPathWithDynamicSubFolder);
            #endregion

            #region Eingabe von Variablen

            //Eingabe eines Strings durch den Benutzer und Absspeichern in einer String-Variable
            Console.Write("Bitte geben Sie einen Namen ein:");
            string eingabe = Console.ReadLine();
            
            //Ausgabe
            Console.WriteLine($"Der eingebene Name ist also {eingabe}");
            #endregion

            #region Parse string->int

            Console.Write("Bitte gib deine Lieblingszahl ein:");
            string zahlAlsString = Console.ReadLine();

            //Wie kann ich aus einem String -> eine Zahl oder Gleitkomma-Zahl erstellen? 

            //Variante 1:
            int zahl1 = Convert.ToInt32(zahlAlsString);

            //Variante 2 (wird heute benutzt und hat auch mehere Vorteile gegenüber Convert.To.... 
            int zahl2 = int.Parse(zahlAlsString); //Parse ist eine statische Hilfsmethode, die uns das Leben mit int-Variable erleichtert 

            int zahl3;

            //Versuche zu Parsen
            if (int.TryParse(zahlAlsString, out zahl3))
            {
                //Wenn das Parsen geklappt hat, bin ich innerhalt des if-Bodys 

                Console.WriteLine(zahl3); //zahl3 ist definitiv ein Zahlenwert 
            }
            #endregion

            #region Konventieren

            int intZahl = 79;
            double doubleZahl = intZahl + 0.11;
            Console.WriteLine(doubleZahl); //79,11

            //Impliziete Konventierung -> es wird versuche 79,11 in eine Ganzzahligen Wert zu konventieren -> Ergebnis 79 (0,11 wird ignoriert -> Alles hinter dem Komma wird abgeschnitten) 
            intZahl = (int)doubleZahl;
            Console.WriteLine(intZahl);
            #endregion

            #region Operatoren von Variablen

            zahl1 = 111;
            zahl2 = 111;

            zahl3 = zahl1++; //zuerst übergeben danach um zahl1 auf 112 gesetzt
            int zahl4 = ++zahl2; //112 

            Console.WriteLine(zahl1++); //111 und danach wird um den Wert 1 erhöht
            Console.WriteLine(++zahl2); //112 zuerst wird der Wert erhöht und danach 112 

            Console.WriteLine(zahl3);
            Console.WriteLine(zahl4);


            #endregion

            #region Nullable Datentypen

            int normalInteger;

            int? nullableInteger = null; //nuallable

            //Nullable Datentypen können mit HasValue geprüft werden, ob ein Wert vorhanden ist
            if (nullableInteger.HasValue) //false 
                Console.WriteLine(nullableInteger.Value); //Value kann man auf den Wert zugreifen. 
            else
                Console.WriteLine("Die Variable hat keinen Wert zugewiesen bekommen");


            bool? boolWithNullable = true;

            if (boolWithNullable.HasValue)
                Console.WriteLine(boolWithNullable.Value);

            //das selbe Konzept gilt für float, double, decimal, long, short, byte (Zahlenwerte und Gleitkomma - Datentypen)
            #endregion

            #region nullable bei Strings? 

            string test; //test = null


            test = ""; //Leerer String 
            test = string.Empty; //andere Schreibweise für Leerer String

            if (test == "")
                Console.WriteLine("String ist leer");

            if (string.IsNullOrEmpty(test))
            {
                Console.WriteLine("test ist null oder ohne Zeichen->Leerstring");
            }


            #endregion

        }
    }
}
