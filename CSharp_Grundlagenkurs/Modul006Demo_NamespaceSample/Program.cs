using NamespB = Modul006Demo_NamespaceSample.NamespaceB;
using NamespA = Modul006Demo_NamespaceSample.NamespaceA;
namespace Modul006Demo_NamespaceSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Implizietes Verwenden
            //Modul006Demo_NamespaceSample.NamespaceA.FootballClub
            NamespA.FootballClub footballClub = new NamespA.FootballClub();

            ///Modul006Demo_NamespaceSample.NamespaceB.Wochentage
            NamespB.Wochentage selektierterWochentag = NamespB.Wochentage.Mo;

            if (selektierterWochentag == NamespB.Wochentage.Mo)
                Console.WriteLine($"selektierter Wochentag ist {selektierterWochentag}");
            #endregion

            #region Explizietes verwenden von absoluten Namespaceangaben -> Wenn selber Typname in unterschiedlichen Namespaces vorkommen

            //Explizietes Verwenden von Klassen mit absoluter Namespaceangabe
            NamespA.Gender gender = new Modul006Demo_NamespaceSample.NamespaceA.Gender();
            gender.HelloWorld();

            NamespB.Gender gender1 = NamespaceB.Gender.Mann;
            Console.WriteLine(gender1);
            #endregion

        }
    }
}