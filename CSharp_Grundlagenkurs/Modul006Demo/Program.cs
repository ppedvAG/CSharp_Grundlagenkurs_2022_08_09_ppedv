using Modul006Demo.LebewesenSample1;

namespace Modul006Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lebewesen lebewesen1 = new Lebewesen(); //Klasseninstanz

            DateTime birthday = lebewesen1.GetGeburtstag();
        }
    }

   
}