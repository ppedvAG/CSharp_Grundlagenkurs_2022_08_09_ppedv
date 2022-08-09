
double summe = Addiere(3, 6);
Console.WriteLine(summe); //9

summe = Addiere



//Jede Funktion/Methode besteht aus einem Kopf und einem Körper
///Der Kopf besteht aus den MODIFIERN (public static), dem RÜCKGABEWERT (int), dem NAMEN (Addiere) sowie den ÜBERGABEPARAMETERN

int Addiere (int a, int b)
{
    return a + b;
}

//Addiere gibt es schon, in dieser Signatur 
//int Addiere(int a, int c)
//{
//    return a + b;
//}

//Überladen einer Methode (also Methodennamen mehrfach verwenden), wenn ich die Eingabe-Parameter Liste ändere 
double Addiere (double a, double b)
{
    return a + b;
}

