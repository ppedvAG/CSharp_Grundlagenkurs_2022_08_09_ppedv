using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul006Demo.LebewesenSample1
{
      /*
      * LebewesenSample1_Properties_Felder.cs zeigt die Historie -> Get/Set - Methoden die allerdings veraltet sind bis hin zu Properties
      */
    public class Lebewesen
    {
        #region Felder / Fields
        private DateTime geburtstag;

        private string name; 
        #endregion


        #region Die C++ Entwickler, haben die Felde mit Methoden zugänglich gemacht
        public void SetGeburtstag(DateTime geb)
        {
            //Ich kann innerhalb meiner Klasse auf Private - Variablen zugreifen. 
            //Neues Geburtsdatum wird der Klassen-Field geburtstag zugewiesen 

            geburtstag = geb; 
        }

        public DateTime GetGeburtstag()
        {
            return geburtstag;
        }


        #region Kursschreib-Variante + Verwendung von this (wenn Field-Variable (Member-Variable) und Parameter-Variable genau gleich geschrieben sind)
        
        //this sagt, ich bin die Variable die zu der Klasse gehört 
        public void SetName(string name)
        {

            if (string.IsNullOrEmpty(name))
            {
                this.name = "unbekanntes Tier";
            }
            else
                this.name = name;


        }
           

        public string GetName()
            => this.name;
        #endregion
        #endregion


        #region Diese Property sticht sofort hervor und macht das Gleiche wie Get/Set-Methoden.
        public DateTime Geburtstag
        {
            set
            {

                if (DateTime.Now < value)
                    Console.WriteLine("Das Geburtsdatum ist in der Zukunft");
                else
                    this.geburtstag = value; //Value ist der Wert... der recht vom dem Symbol '=' steht -> lebewesen.Geburtstag = new DateTime(1995,5,5);
            }


            get
            {
                return this.geburtstag;
            }
        }
        #endregion
        
        
        public void Atmen()
        {
            Console.WriteLine($"{name} atmet");
        }
    }
}
