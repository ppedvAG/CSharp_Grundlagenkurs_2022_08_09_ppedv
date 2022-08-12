namespace Modul013Demo
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            #region Delegate Grundlagen
            //Das Delegate benötigt im Konstruktor, den Namen einer Funktion mit der selben Signatur, wie das Delegate 

            //Hier legt die Methode Addieren Ihre Speicheradresse im Delgate ab.
            //Über das Delegate können wir die Methode von überall her aufrufen. 
            Console.WriteLine("Beispiel1: meinDelegate mit Addieren");
            MeinDelegate meinDelegate = new MeinDelegate(Addieren);
            Console.WriteLine($"Beispiel1: {meinDelegate(4,5)}");

            Console.WriteLine("Beispiel2: meinDelegate mit Addieren und Multiplizieren");
            meinDelegate += Multiplizieren;
            Console.WriteLine($"Beispiel2: {meinDelegate(4, 5)}");


            Console.WriteLine("Beispiel2 B: Kann man alle Methoden-Ergebnisse ausgeben lassen?");
            int ergebnis = 0;
            foreach (Delegate item in meinDelegate.GetInvocationList())
            {
                Console.WriteLine(item.Method);
                ergebnis = Convert.ToInt32(item.DynamicInvoke(ergebnis, 12));

                Console.WriteLine($"Ergebnis nach der {item.Method} ist:  {ergebnis}" );
            }

            Console.WriteLine("Beispiel3: meinDelegate mit Multiplizieren");
            meinDelegate -= Addieren;
            Console.WriteLine($"Beispiel3: {meinDelegate(4, 5)}");


            Console.WriteLine("Beispiel mit Methoden ohne Rückgabewert");
            DelegateOhneRueckgabe delegateOhneRueckgabe = new DelegateOhneRueckgabe(Message);
            delegateOhneRueckgabe("Hallo Welt");

            #endregion

            #region Action Grundlagen
            //Action arbeitet NUR mit Methoden OHNE RÜCKGABEWERT
            Action<string> messageActionDelegate = new Action<string>(Message);
            messageActionDelegate("Hallo Welt");
            #endregion

            #region Func Grundlagen
            Func<int, int, int> funcDelegate = new Func<int, int, int>(Addieren);
            Console.WriteLine($"Func-Beispiel->Ergebnis: {funcDelegate(11,22)}");

            funcDelegate += Multiplizieren;

            //Aufruf jeder Methode, die an Func dranhängt 
            foreach (Delegate item in funcDelegate.GetInvocationList())
            {
                Console.WriteLine(item.Method);
                Console.WriteLine(item.DynamicInvoke(11, 12));
            }
            #endregion

            #region UseCase -> Was ist ein Callback

            //Via PercentChangedDelegate rufen wir die Program -> public static void ProcessFinishAusgabe(string msg) auf
            PercentChangedDelegate percentChangedDelegate = new PercentChangedDelegate(ShowPercentAusgabe);
            FinishDelegate finishDelegate = new FinishDelegate(ProcessFinishAusgabe);

            Component component = new Component();
            component.Process(percentChangedDelegate, finishDelegate);


            #endregion

            #region event delegate
            BusinessComponentA businessComponentA = new BusinessComponentA();
            //Wir können die Komponente ohne Event Delegates verwenden
            businessComponentA.Process();

            //Wir können die Komponente mit Events verwenden
            businessComponentA.ChangePercentValueDelegate += BusinessComponentA_ChangePercentValueDelegate;
            businessComponentA.ResultDelegate += BusinessComponentA_ResultDelegate;
            businessComponentA.Process();
            #endregion

            #region EventHandler
            BusinessComponentB businessComponentB = new BusinessComponentB();
            businessComponentB.PercentValueChanged += BusinessComponentB_PercentValueChanged;
            businessComponentB.ProcessCompleted += BusinessComponentB_ProcessCompleted;

            businessComponentB.PercentValueChanged2 += BusinessComponentB_PercentValueChanged2;
            businessComponentB.ProcessCompleted2 += BusinessComponentB_ProcessCompleted2;
            businessComponentB.StartProcess();
            #endregion
        }

        private static void BusinessComponentB_ProcessCompleted2(object? sender, FinishEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void BusinessComponentB_PercentValueChanged2(object? sender, PercentEventArgs e)
        {
            Console.WriteLine(e.Percent);
        }

        private static void BusinessComponentB_ProcessCompleted(object? sender, EventArgs e)
        {
            FinishEventArgs finishEventArgs = (FinishEventArgs)e;
            Console.WriteLine(finishEventArgs.Message);
        }

        private static void BusinessComponentB_PercentValueChanged(object? sender, EventArgs e)
        {
            PercentEventArgs percentEventArgs = (PercentEventArgs)e;
            Console.WriteLine("Percent: " + percentEventArgs.Percent);
        }

        private static void BusinessComponentA_ResultDelegate(string msg)
        {
            Console.WriteLine("BusinessComponentA.Process ->  Ergebnis: " + msg);
        }

        private static void BusinessComponentA_ChangePercentValueDelegate(int newPercentValue)
        {
            Console.WriteLine("BusinessComponentA.Process ->  Prozentwert: " + newPercentValue);
        }

        #region Methoden für Delegate Grundlagen + Action Grundlagen + Func Grundlagen
        public static int Addieren(int a, int b)
            => a + b;

        public static int Multiplizieren(int a, int b)
            => a * b;

        public static void Message(string text)
            => Console.WriteLine(text);
        #endregion


        #region Callback-Delegate Beispiel
        public static void ShowPercentAusgabe(int percent)
            => Console.WriteLine($"aktueller Prozentwert -> {percent} %");
        public static void ProcessFinishAusgabe(string msg)
            => Console.WriteLine($"{msg}");
        #endregion
    }

    #region Definition von Delegate-Types
    //Dieses Delegate kann NUR mit Methoden zusammenarbeiten, die ein Rückgabewert (int) und die selben
    //Parameter vorweisen, wie das Delegate (int, int) 
    public delegate int MeinDelegate(int a, int b);
    public delegate void DelegateOhneRueckgabe(string message);
    #endregion

    #region Callback-Delegate (Könnte auch eine DLL von einer anderen Firma sein) 
    public delegate void FinishDelegate(string msg);
    public delegate void PercentChangedDelegate(int percent);

    public class Component
    {
        public void Process(PercentChangedDelegate percentChangedDelegate, FinishDelegate finishDelegate)
        {
            for (int i = 0; i < 100; i++)
            {
                //Wir wollen nach außen benachrichtigen, was für ein aktuell Prozentwert wird haben
                percentChangedDelegate(i);
            }

            //Wollen wir am Ende aussagen, dass wir fertig sind.

            finishDelegate("Ich bin fertig");
        }
    }
    #endregion
}