using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul006Demo.LebewesenSample3
{
    public enum UmweltTyp { Wasser, Luft, Land }

    public enum Gender { Männlich, Weiblich, Zwitter}
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

        #region Konstuktoren
        //Default Konstrutor -> Konstruktor OHNE PARAMETER

        public Lebewesen()
        {
            //Default-Werte vergeben, wenn nötig
        }

        //Werte-Konstruktor 
        public Lebewesen(DateTime geburtsdatum, string name, double gewicht)
        {
            Geburtsdatum = geburtsdatum;
            Name = name;
            Gewicht = gewicht;
        }

        public Lebewesen(DateTime geburtsdatum, string name, double gewicht, string farbe)
            : this (geburtsdatum, name, gewicht)
        {
            Farbe = farbe;
        }

        public Lebewesen(DateTime geburtsdatum, string name, double gewicht, string farbe, UmweltTyp umweltTyp, Gender gender)
           : this(geburtsdatum, name, gewicht, farbe)
        {
            Umwelt = umweltTyp;
            Gender = gender;
        }


        //Der Kopierkonstruktor
        public Lebewesen(Lebewesen existierendesLebewesen)
        {
            this.Geburtsdatum = existierendesLebewesen.Geburtsdatum;
            this.Name = existierendesLebewesen.Name;
            this.Gewicht = existierendesLebewesen.Gewicht;
            this.Farbe = existierendesLebewesen.Farbe;
            this.Umwelt = existierendesLebewesen.Umwelt;
            this.Gender = existierendesLebewesen.Gender;
        }
        #endregion

        #region Methoden
        public void Atmen()
        {
            Console.WriteLine($"{Name} atmet");
        }

        public Lebewesen Gebären()
        {
            if (Gender == Gender.Männlich)
            {
                //Fehlermeldung wäre hier der beste Weg
                throw new Exception("Ein männliches Lebewesen kann kein Lebewesen zur Welt bringen");
            }

            return new Lebewesen(DateTime.Now, this.Name, new Random().Next(1, 10), "schwarz",this.Umwelt, (Gender)(new Random().Next(0, 3)));
        }
        #endregion
    }
}
