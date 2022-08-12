using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul013Demo
{

    public delegate void ChangePercentValueDelegate(int newPercentValue);
    public delegate void ResultDelegate(string msg);

    public class BusinessComponentA
    {
        //2.) Wir bieten die Delegates als 'Events' an -> wie Properties

        public event ChangePercentValueDelegate ChangePercentValueDelegate;
        public event ResultDelegate ResultDelegate;

        public void Process(/*1.) Wir verwenden diesmal keine Parameter wie beim Callback*/)
        {
            for (int i = 0; i < 100; i++)
            {

                //Soll nach außen den neuen Prozentwert kommuzieren

                //Achtung wir müssen uns fragen, ob eine Methode von 'draußen' am Event angehängt wurde

                if (ChangePercentValueDelegate != null)
                    ChangePercentValueDelegate(i); 
            }


            //Soll nach draußen kommunizieren, wann es fertig ist 

            if (ResultDelegate != null)
                ResultDelegate("Kompoenente ist fertig");
        }
    }
}
