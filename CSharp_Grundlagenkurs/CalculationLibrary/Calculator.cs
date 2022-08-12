using System.Diagnostics;

namespace CalculationLibrary
{
    public class Calculator
    {
        public double Addieren(double a, double b)
            => a + b;

        public double Subtrahieren(double a, double b)
            => a - b;

        public double Multiplikation(double a, double b)
            => a * b;

        public double Division(double a, double b)
        {
            try
            {
                Validate(a);

                return a / b;
            }
            catch (DivideByZeroException ex)
            {
                //Der DLL - Hersteller möchte seine Komponente geloggt wissen

                // Hier können Fehlermeldung mit ToString() - für die Entwickler geloggt werden

                //Debug ist jetzt unser "Logger"
                Debug.WriteLine("NUR FEHLERMERLDUNG" + ex.Message); //Fehlermeldung in Text
                Debug.WriteLine("NUR STACKTRACE" + ex.StackTrace); // Wo ist Fehler passiert
                Debug.WriteLine("NUR ToString()" + ex.ToString()); //Fehlermeldung in Text + Wo ist Fehler passiert
                throw new DivideByZeroException();
            }
            return 0; 
            
        }

        private void Validate(double a)
        {
            if (a == 0)
            {
                throw new DivideByZeroException();
            }
        }


        public void MethodeAVonAzubi()
        {
            throw new CalculatorException("Allgmeiner Fehler in der DLL");
        }

        public void MethodeBVonAzubi()
        {
            throw new DivByZeroException("Div by Zero Excpetion");
        }
    }

    //Für Allgemeine Fehler in der Library-Exception
    public class CalculatorException : Exception
    {
        public CalculatorException(string message)
            :base (message)
        {

        }
    }

    public class DivByZeroException : CalculatorException
    {
        public DivByZeroException(string message)
            : base(message)
        {

        }
    }
}