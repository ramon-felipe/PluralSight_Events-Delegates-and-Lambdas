using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegatesLambdas
{
    public delegate void WorkPerformedHandler(object? sender, WorkPerformedEventArgs e);

    public class Worker
    {
        public event WorkPerformedHandler WorkPerformed;
        public event EventHandler WorkCompleted;

        public Worker(WorkPerformedHandler onWorkPerformed, EventHandler onWorkCompleted)
        {
            WorkPerformed = onWorkPerformed;
            WorkCompleted = onWorkCompleted;
        }

        public void DoWork(object? sender, WorkPerformedEventArgs e)
        {
            for (int i = 0; i <= e.Hours; i++)
            {
                OnWorkPerformed(sender, e);
            }

            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(object? sender, WorkPerformedEventArgs e)
        {
            WorkPerformed?.Invoke(sender, e);
        }

        protected virtual void OnWorkCompleted()
        {
            WorkCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
}
