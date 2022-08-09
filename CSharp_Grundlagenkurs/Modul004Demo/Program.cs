#region Schleifen

int a = 0;
int b = 10;


#region Kopfgesteuerte Schleifen


//While - Schleife
while (a < b)
{
    Console.WriteLine("A ist kleiner als B");
    a++;
}

bool endless = true;
a = 0;

//Endlosschleife
while (endless)
{
    a++;

    if (a == 50)
        endless = false; //While Schleife wird unterbrochen
}

a = 0;


while (true)
{
    a++;

    if (a == 50)
        break; //Verlassen der Schleife 
}





Console.WriteLine("Schleifenende");
Console.WriteLine("for-schleife ist eine Zählerschleife");
for (int i = 0; i < 100; i++)
{
    Console.WriteLine(i);
}




int[] zahlen = { 2, 3, 5, 4 };
//Iteration über ein Array mittels For-Schleife
for (int i = 0; i < zahlen.Length; i++)
{
    Console.WriteLine(zahlen[i]);

    //for-Schleifen können bei einem Array eine IndexOutOfRange-Exception auslösen
}


for (int i = 0; i < 1000; i++)
{
    if (i % 2 == 0)
    {
        continue; //Schleifen durchlauf wird abgebrochen und nächste Schleifendurchlauf wird angegangen.
    }

    Console.WriteLine("Ausgabe nur ungerader Zahlen");
}

a = 0;
//aus einer For-Schleife könnte man eine While Schleife bauen

for (/*Initialisierung eine Variable*/;a < 10; /*auf das Hochzählen verzichten wir auch*/)
{
    Console.WriteLine("A ist kleiner als 10");
    a++;
}


//FOREACH-Schleifen können über Collections laufen und sprechen dabei jedes Element genau einmal an
foreach (int item in zahlen)
{
    Console.WriteLine(item);
}


#endregion


#region Fussgesteuerte Schleife

a = -45;
do
{
    Console.WriteLine(a);
    a++;

} while (a < 0);


#endregion
#endregion



#region Enums-Beispiele

//bevor es enums gab, wurden solche Aufzählungen so geschrieben -> 
string[] Wochentage = { "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag", "Sonntag" };
//Probleme bei einer Aufzählung in einem Array, dass die Werte schwer rauslesebar sind...man muss die Definition eines Array jedesmal lesen
Console.WriteLine(Wochentage[6]);
Console.WriteLine(Wochentage[5]);


int meinWochentag = 3;
switch(meinWochentag)
{
    case 0:
        Console.WriteLine("Wochenstart");
        break;
    case 1:
    case 2:
    case 3:
    case 4:
        Console.WriteLine("Wochentag");
        break;
    case 5:
    case 6:
    case 7:
        Console.WriteLine("Wochenende");
        break;
    default:
        Console.WriteLine("Falsche Eingabe");
        break; 

}



//Enums machen das Lesen von Aufzähungen einfacher und lesbarer

Console.WriteLine(Wochentag.Mittwoch); //Ausgabe Mittwoch
Console.WriteLine(Enum.GetName(typeof(Wochentag), 3)); //Ausgabe Mittwoch
Console.WriteLine((int)Wochentag.Mittwoch); //Index-Ausgabe: 3


Wochentag heutigerTag = Wochentag.Montag;

//Eingabe mit einer Index-Zahl 
// Speichern einer Benutzereingabe(Int) als Enumerator
//Cast: Int -> Wochentag

heutigerTag = (Wochentag)int.Parse("3");
Console.WriteLine($"Dein Lieblingstag ist also {heutigerTag}.");

//Parsing eines Strings in den Enumzustand
heutigerTag = (Wochentag)Enum.Parse(typeof(Wochentag), "Freitag");
Console.WriteLine($"Dein Lieblingstag ist also {heutigerTag}.");


//SWITCHs sind eine verkürzte Schreibweise für IF-ELSE-Blöcke. Mögliche Zustände der übergebenen Variablen werden 
//in den CASES definiert
switch (heutigerTag)
{
    case Wochentag.Montag:
        Console.WriteLine("Wochenstart");
        //Jeder speziell definierte CASE muss mit einer BREAK-Anweisung beendet werden
        break;
    //Wenn in einem CASE keine Anweisungen geschrieben stehen kann auf den BREAK-Befehl verzichtet werden. In diesem Fall
    //springt das Programm in diesem CASE zum Nachfolgenden
    case Wochentag.Dienstag:
    case Wochentag.Mittwoch:
    case Wochentag.Donnerstag:
        Console.WriteLine("Normaler Wochentag");
        break;
    case Wochentag.Freitag:
    case Wochentag.Samstag:
    case Wochentag.Sonntag:
        Console.WriteLine("Wochenende");
        break;
    //Wenn die übergebene Variable keinen der vordefinierten Zustände erreicht, wird der DEFAULT-Fall ausgeführt
    default:
        Console.WriteLine("Fehlerhafte Eingabe");
        break;
}

#endregion
#region Enums mit Flag Beispiele


//Wert 15 wird gespeichert 
FischsortenInMeinemSee meineFischeInMeinemTeich = FischsortenInMeinemSee.Forelle | FischsortenInMeinemSee.Hecht | FischsortenInMeinemSee.Zander | FischsortenInMeinemSee.Karpfen;

foreach (FischsortenInMeinemSee currentFisch in Enum.GetValues(typeof(FischsortenInMeinemSee)))
{
    if (meineFischeInMeinemTeich.HasFlag(currentFisch) && currentFisch != FischsortenInMeinemSee.KeineFische)
    {
        Console.WriteLine($"{currentFisch} befindet sich in deinem Teich" );
    }
}


#region Brauche ich das Flag-Attribute üfr Kombinationen von Werten? -> Sample

// Display all possible combinations of values.
Console.WriteLine(
     "All possible combinations of values without FlagsAttribute:");
for (int val = 0; val <= 16; val++)
    Console.WriteLine("{0,3} - {1:G}", val, (SingleHue)val);

// Display all combinations of values, and invalid values.
Console.WriteLine(
     "\nAll possible combinations of values with FlagsAttribute:");
for (int val = 0; val <= 16; val++)
    Console.WriteLine("{0,3} - {1:G}", val, (MultiHue)val);

#endregion

#endregion

#region Enums Definition

//Startwert eines Enums ist definierbar 

//Ein Enum wird in der Datenbank als Integer-Wert abgespeichert 
enum Wochentag {Montag=1, Dienstag, Mittwoch, Donnerstag, Freitag, Samstag, Sonntag }



#endregion

#region Enums mit Flags - Definition

[Flags]
enum FischsortenInMeinemSee
{
    KeineFische = 0,
    Forelle = 1,
    Hecht = 2,
    Zander = 4,
    Karpfen = 8,
    Barsch = 16,
    Wels = 32
}

// Define an Enum without FlagsAttribute.
enum SingleHue : short
{
    None = 0,
    Black = 1,
    Red = 2,
    Green = 4,
    Blue = 8
};

// Define an Enum with FlagsAttribute.
[Flags]
enum MultiHue : short
{
    None = 0,
    Black = 1,
    Red = 2,
    Green = 4,
    Blue = 8
};
#endregion
