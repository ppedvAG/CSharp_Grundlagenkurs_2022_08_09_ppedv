// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

#region Beispiel wie eine Referenz funktioniert
int alterVonPersonA = 33;
int alterVonPersonB = 33; // Auch wenn diese Variable nicht direkt manipuliert wird, wird Sie dies in der Methode 

AlternA(alterVonPersonA); 
AlternB(ref alterVonPersonB);

Console.WriteLine(alterVonPersonA); //33 
Console.WriteLine(alterVonPersonB); //34


//https://stackoverflow-com.translate.goog/questions/636932/in-c-why-is-string-a-reference-type-that-behaves-like-a-value-type?_x_tr_sl=en&_x_tr_tl=de&_x_tr_hl=de&_x_tr_pto=sc
//https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/builtin-types/reference-types
string input = "Hallo";
ManipuliereString(out input);

Console.WriteLine(input);

void AlternA (int alter)
{
    alter++;
}

//ref ist die allgemeine Referenz und kann uneingeschränkt verwendet werden 
void AlternB (ref int alter)
{
    alter++;
}

//out gilt Regel, dass dort ein Wert zugewiesen werden MUSS
void AlternC(out int alter)
{
    alter = 50;
}

//'in' wird verwendet um Referenzen nur readonly zu repräsentieren 
void AlternD(in int alter)
{
    Console.WriteLine(alter);
}


void ManipuliereString(out string str)
{
    str = "hello";
}


#endregion


#region Wertetyp und Referenztyp

//Wertetyp: Gibt bei einer Zuweisung nur seinen Variableninhalt (Wert) weiter 

//Welche Wertetypen gibt es: int, bool, short, long, float, double, decimal, struct

//Referenztyp: Gibt bei einer Zuweisung seine Adresse mit Wert weiter.
//string, class, interface
//Benchmark bei Zuweisungen sind Referenztypen schneller als Wertetypen 

#endregion

