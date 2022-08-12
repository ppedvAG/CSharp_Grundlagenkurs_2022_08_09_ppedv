using System.Collections;

namespace Modul011Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<T> -> T wird durch einen Typ ersetzt (typisiert)

            //typisierte Liste von string
            List<string> cities = new List<string>();
            cities.Add("München");
            cities.Add("Deisenhofen");
            cities.Add("Taufkirchen");
            cities.Add("Sauerlach");
            

            Dictionary<int, string> dictionarySportarten = new Dictionary<int, string>();
            dictionarySportarten.Add(1, "Handball");
            dictionarySportarten.Add(2, "Fussball");
            dictionarySportarten.Add(3, "Basketball");

            if (!dictionarySportarten.ContainsKey(3))
            {
                dictionarySportarten.Add(3, "Basketball");
            }
            else
                Console.WriteLine("Key ist schon vorhanden");

            foreach (KeyValuePair<int, string> currentSportEntity in dictionarySportarten)
            {
                Console.WriteLine($"Key: {currentSportEntity.Key} \t Sportart: {currentSportEntity.Value}");
            }


            IDictionary<int, string> dictionarySportarten2 = new Dictionary<int, string>();

            //Das IDictionary bietet uns bei der Add-Methode eine Überladung an und können zusätzlich mit KeyValuePair arbeiten 
            dictionarySportarten2.Add(new KeyValuePair<int, string>(1, "Bogenschießen"));
            dictionarySportarten2.Add(new KeyValuePair<int, string>(2, "Bogenschießen"));
            dictionarySportarten2.Add(new KeyValuePair<int, string>(3, "Bogenschießen"));

            //Hashtable hat eher Nachteile als Vorteile -> Dictionary ist besser 
            Hashtable hashtable = new Hashtable();
            hashtable.Add("1", new DateTime());
            hashtable.Add(new DateTime(), "1");
            hashtable.Add(12, 22);

            

        }
    }
}