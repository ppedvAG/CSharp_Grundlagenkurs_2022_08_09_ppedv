using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul013Demo
{
    public class BusinessComponentB
    {
        //Komponente bietet für die Kommunikation nach draußen, folgende event Handler an
        public event EventHandler PercentValueChanged;
        public event EventHandler ProcessCompleted;

        //Verbesserung zu PercentValueChanged und ProcessCompleted
        public event EventHandler<PercentEventArgs> PercentValueChanged2;
        public event EventHandler<FinishEventArgs> ProcessCompleted2;

        public void StartProcess()
        {
            for (int i = 0; i < 100; i++)
            {
                if (PercentValueChanged != null)
                {
                    PercentValueChanged.Invoke(this, new PercentEventArgs() { Percent = i });
                }

                if (PercentValueChanged2 != null)
                {
                    PercentValueChanged2.Invoke(this, new PercentEventArgs() { Percent = i });
                }
            }

            if (ProcessCompleted != null)
                ProcessCompleted.Invoke(this, new FinishEventArgs() { Message = "BusinessComponentB ist mit StartProcess fertig" });

            if (ProcessCompleted2 != null)
                ProcessCompleted2.Invoke(this, new FinishEventArgs() { Message = "BusinessComponentB ist mit StartProcess fertig" });
        }
    }

    public class PercentEventArgs : EventArgs
    {
        public int Percent { get; set; }
    }

    public class FinishEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
