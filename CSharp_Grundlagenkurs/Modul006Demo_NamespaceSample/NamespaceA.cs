using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul006Demo_NamespaceSample.NamespaceA
{
    public class Gender
    {
        public void HelloWorld()
        {
            Console.WriteLine("Ich bin eine Methode in der Klasse Gender");
        }
    }

    public class FootballClub
    {
        public string Name { get; set; }
    }
}
