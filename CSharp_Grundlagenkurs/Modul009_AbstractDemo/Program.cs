namespace Modul009_AbstractDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Polymorphie Beispiel GeoFormen
            Square square = new Square(25);
            Console.WriteLine($"Fläche eines Quatrates: {square.GetArea()}");

            Rectangle rec = new Rectangle(12, 2);
            Console.WriteLine($"Fläche eines Rechtecks: {rec.GetArea()}");

            Circle circle = new Circle(22);
            Console.WriteLine($"Fläche eines Kreises: {circle.GetArea()}");

            #region Was ist eine Liste
            List<string> stringListe = new List<string>();
            stringListe.Add("Berlin");
            stringListe.Add("München");
            stringListe.Add("Passau");

            List<DateTime> datumsListe = new List<DateTime>();
            datumsListe.Add(DateTime.Now);
            #endregion

            #region Polymorphy Beispiel 1
            //Alle abgeleiteten Klassen von object können in die Liste aufgenommen
            List<object> objListe = new List<object>();

            objListe.Add(rec);
            objListe.Add(circle);
            objListe.Add(square);
            objListe.Add(datumsListe);


            object[] objectArray = objListe.ToArray();

            List<object> objListe2 = new();

            objListe2.AddRange(objListe.ToArray());

            foreach(object currentObject in objListe)
            {
                currentObject.ToString();

                //Typprüfung mit Casten
                if (currentObject is List<DateTime> dateTimeList)
                {
                    foreach (DateTime currentDateTime in dateTimeList)
                        Console.WriteLine(currentDateTime.ToString()) ;
                }

                if (currentObject is Rectangle)
                {

                }
            }
            #endregion


            #region Polymorphy Beispiel 2

            List<Shape> shapeListe = new List<Shape>();
            shapeListe.Add(rec);
            rec.Bezeichnung = "Reckteck Krumm";
            shapeListe.Add(circle);
            shapeListe.Add(square);



            //Vorteil von Polymorphy gegenüber freier Methoden Implementierung
            //Shape currentShape gilt hier nur als Platzhalte für die Vererbten Klasse von Shape

            //Beim Programmieren können wir mit currentShape nur alle Methoden ansprechen, die in Shape definiert sind

            rec.VerstaueDasRechteckInEinSchrank();

            double summeAlleFlaechen = 0;

            foreach (Shape currentShape in shapeListe)
            {
                //Von allen Geometrieformen kann ich die Fläche jetzt berechnen lassen

                //1.) Mit dem Platzhalter Shape, kannst du nur auf die Properties, Methoden zugreifen, die in Shape definiert sind.
                //2.) Wenn currentShape GetArea aufruft, wird in der abgeleiteten Klasse die GetArea aufgerufen. 
                currentShape.Info();
                Console.WriteLine($"{currentShape.Bezeichnung} hat eine Fläche von {currentShape.GetArea()}");
                summeAlleFlaechen += currentShape.GetArea();
                
                //Wir fragen, hey currentShape-Platzhalte, bist du gerade jetzt ein Rechteck?
                if (currentShape is Rectangle)
                {
                    Rectangle rectangle = (Rectangle)currentShape;
                    rectangle.VerstaueDasRechteckInEinSchrank();

                }
            }

            Console.WriteLine($"Summe alle Flaechen ist {summeAlleFlaechen}");
            #endregion

            #endregion


            #region MultipleDocumentenTool
            List<DocumentBase> documents = new List<DocumentBase>();

            documents.Add(new Excel());
            documents.Add(new PDFDocument());
            documents.Add(new WordDocument());

            //Alle Dokumente sollen ausgedruckt werden

            foreach (DocumentBase currentDoc in documents)
                currentDoc.Print(); //Alle Dokumente werden gedruckt 
            #endregion



        }
    }
    #region Klassen zum Beispiel GeoFormen
    //Wenn eine Methode oder Property als abstract gekennzeichnet ist-> wird die Klasse auch abstrac!
    //Eine Klasse die abstract ist, kann keine Instanz erstellt werden 
    //Eine abstrakte Klasse soll wie eine Schablone zu sehen sein. 

    public abstract class Shape
    {
        public int Id { get; set; } //Id für DB 

        public abstract string Bezeichnung { get; set; }
        public abstract double GetArea();

        public virtual void Info()
        {
            Console.WriteLine("Undefinierte Geometrieform");
        }
    }

    //Wenn wir von einer abstrakten Klasse erben, MÜSSEN wir ALLE abstrakten Methoden überschreiben 
    public class Square : Shape
    {

        public Square(int side)
        {
            Side = side;
        }


        public int Side { get; set; }
        public override string Bezeichnung { get; set; } = "Quatrat";

        public override double GetArea()
        {
            return Side * Side;
        }

        public override void Info()
        {
            Console.WriteLine($"Ein {Bezeichnung} mit einer Seitenlänge von {Side}");
        }

        public void SendeQuatratMitDerPost()
        {

        }
    }

    public class Rectangle : Shape
    {
        public int? X { get; set; }
        public int? Y { get; set; }

        public override string Bezeichnung { get; set; } = "Rechteck";

        public Rectangle(int? x, int? y)
        {
            X = x;
            Y = y;  
        }

        public override double GetArea()
        {
            if (!X.HasValue || !Y.HasValue)
                throw new Exception("X oder Y wurden nicht gesetzt");

            if (X == Y)
                throw new Exception("Ein Quatrat ist kein Rechteck");

            return X.Value * Y.Value;
        }

        public override void Info()
        {
            Console.WriteLine($"Ein {Bezeichnung} mit den Seitenlängen: {X} und {Y}");
        }

        public void VerstaueDasRechteckInEinSchrank()
        {

        }

        public int Version { get; set; }
    }

    public class Circle :Shape
    {
        public int? Radius { get; set; }
        public override string Bezeichnung { get; set; } = "Kreis";

        public Circle(int? radius)
        {
            Radius = radius;
        }

        public override double GetArea()
        {
            if (!Radius.HasValue)
                throw new Exception("Radius muss gesetzt werden");

            return Radius.Value * Radius.Value * Math.PI;
        }

        public override void Info()
        {
            Console.WriteLine($"Ein {Bezeichnung} mit einem Radius: {Radius}");
        }
    }

    #endregion


    public abstract class DocumentBase
    {
        public virtual string FilePath { get; set; }


        public virtual string CopyrigthOwner()
        {
            return "Me";
        }

        public void GetFileInfo ()
        {
            FileInfo info = new FileInfo(FilePath);
            long FileSize = info.Length;
        }

        public string DocumentType { get; set; } = string.Empty;

        public abstract void Print(); //Alle Dokument die 

        public abstract DocumentBase SaveDocumentAs(string newPath);

    }

    public class PDFDocument : DocumentBase
    {
        public override string FilePath 
        { 
            get => base.FilePath;
            
            set
            {
                if (value.EndsWith("*.pfd"))
                {

                }
            }
        }
        public override void Print()
        {
            Console.WriteLine("PDF Document wird gedruckt");
        }

        public override DocumentBase SaveDocumentAs(string newPath)
        {
            Console.WriteLine("Dokument wird unter einem anderen Pfad abgespeichert");
            return this; //Ich gebe mich selber zurück 
        }

        public int CompressRate { get; set; }
        public bool Watermark { get; set; }
    }

    public class WordDocument : DocumentBase
    {
        public override void Print()
        {
            Console.WriteLine("Word Document wird gedruckt");
        }

        public override DocumentBase SaveDocumentAs(string newPath)
        {
            Console.WriteLine("Dokument wird unter einem anderen Pfad abgespeichert");
            return this; //Ich gebe mich selber zurück 
        }

        public string WordVersion { get; set; } = string.Empty;
    }

    public class EBUPDocument : DocumentBase
    {
        public override void Print()
        {
            Console.WriteLine(value: "Ebup Document wird gedruckt");
        }

        public override DocumentBase SaveDocumentAs(string newPath)
        {
            Console.WriteLine("Dokument wird unter einem anderen Pfad abgespeichert");
            return this; //Ich gebe mich selber zurück 
        }

        
    }

    public class Excel : DocumentBase
    {
        public override void Print()
        {
            Console.WriteLine(value: "Ebup Document wird gedruckt");
        }

        public override DocumentBase SaveDocumentAs(string newPath)
        {
            Console.WriteLine("Dokument wird unter einem anderen Pfad abgespeichert");
            return this; //Ich gebe mich selber zurück 
        }

        public int Tabellenanzahl { get; set; }
    }

}