using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul006Demo.LebewesenSample1
{
   
    public class Lebewesen
    {
        #region Felder / Fields
        private DateTime geburtstag;
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
        #endregion
    }
}
