using System.Linq;

#region Arrays
//Arrays 

//Beim Anlegen eines Arrays wird die Array-Größe benötigt 

//Variante 1
int[] zahlen = new int[10]; //Ein leeres Array mit 10 Felder 


//Variante 2
int[] zahlenB = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 }; //Anhand der Einträge wird die Array-Größe ermittelt.

//Zugriff auf ein Array mithilfe des Indexes (0 .. 9)
Console.WriteLine(zahlenB[0]);
Console.WriteLine(zahlenB[9]); // 0 .. 9 sind 10 Felder 

string[] worte = new string[5];

worte[0] = "Hallo";
worte[1] = "Welt";
//usw...

string csvDatansatz = "Max;Mustermann;Hamburg;Programmierer";
string[] csvParts = csvDatansatz.Split(';');

Console.Write(csvParts[0]);
Console.Write(csvParts[1]);
Console.Write(csvParts[2]);
Console.Write(csvParts[3]);

//Mehrdimensionales Array 

int[,] gameBoard = new int[8, 12];

int ersteDimension = gameBoard.GetLength(0); //8
int zweiteDimension = gameBoard.GetLength(1); //12

//Gehen komplettes Array durch und befüllen jedes Fehld 
for (int i = 0; i < gameBoard.GetLength(0); i++)
{
    for (int y = 0; y < gameBoard.GetLength(1); y++)
        gameBoard[i, y] = i * y;
}


//Eine kleine Erweiterung in Verbindung mit System.Linq (In .NET 6 ist System.Linq per Default schon eingefügt) 

if (worte.Contains("Welt"))
{
    Console.WriteLine("Das Wort 'Welt' ist im Worte-Array vorhanden");
}

#endregion

#region Bool-Variable 

bool wahrOderfalsch = true;

Console.WriteLine(wahrOderfalsch);
Console.WriteLine(wahrOderfalsch.ToString());


#endregion


#region Bedingung (If/Else)

int a = 23;
int b = 23;


//IF-ELSEIF-ELSE-Block
///Das Programm wird den ersten Block ausführen, bei welchem er auf eine wahre Bedingung trifft und dann am Ende des Blocks mit
///dem Code weiter machen
if (a < b)
{
    //Mehrzeiligen 
    Console.WriteLine("b ist größer als a");
}
else if(a > b)
{
    Console.WriteLine("a ist größer als b");
}
else
{
    Console.WriteLine("a und b sind gleich");
}

//Kurznotation 

string ergebnis = (a == b) ? "A ist gleich B" : "A ist ungleich B";

Console.WriteLine(ergebnis);

string name1 = "Hans";
string name2 = "Hans";

//Mit der Methode euquals kann man eine == Prüfung angehen. 
if (name1.Equals(name2)) //Alternative zu == 
{
    Console.WriteLine("ist gleich");
}
#endregion


#region Boolische Operatoren

Console.WriteLine(true ^ true);    // output: False
Console.WriteLine(true ^ false);   // output: True
Console.WriteLine(false ^ true);   // output: True
Console.WriteLine(false ^ false);  // output: False

#endregion

#region Modulo Operator bei if-Statements
//Modulo gibt immer die Rest-Zahl bei einer Division zurück
//int restZahl = 24 % 7; //restZahl = 3
int zahl = 25;

if (zahl % 5 == 0) //Ist die Zahl durch 5 Teilbar
{
    Console.WriteLine("ist durch 5 Teilbar");
}

#endregion

#region Random Zahlen
Random rnd = new Random();
int zufallszahlUnter100 = rnd.Next(0, 100);
int zufallszahlUnter100b = rnd.Next() % 100; //Restzahl kann nur zwischen 1..99 sein
#endregion