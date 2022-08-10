using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul006Demo.LebewesenSample2
{
    /*
     *  LebewesenSample3_Konstruktor.cs
     */


    public enum UmweltTyp { Wasser, Luft, Land }

    public enum Gender { Männlich, Weiblich, Zwitter }
    public class Lebewesen
    {
        #region Properties
        //Alles Auto-Properties -> Variablen werden beim kompilieren intern hinzugefügt
        public DateTime Geburtsdatum { get; set; } 
        public string Name { get; set; }
        public double Gewicht { get; set; }

        //Neuen Version 2.0 fügen wr eine Property hinzu
        public string Farbe { get; set; }

        //Neue Version 3.0 
        public UmweltTyp Umwelt { get; }
        public Gender Gender { get; set; }

        public int AlterInJahren
        {
            get { return ((DateTime.Now - this.Geburtsdatum).Days / 365); }
        }
        #endregion

       
    }


}
