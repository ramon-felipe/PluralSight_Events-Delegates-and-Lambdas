using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegatesLambdas
{
    public delegate void WorkPerformedHandler();

    public class Worker
    {
        public event Action<WorkPerformedEventArgs>? WorkPerformed;
        public event EventHandler? WorkCompleted;
        public event WorkPerformedHandler? WorkCompletedWithNoArgs;

        public Worker(Action<WorkPerformedEventArgs> onWorkPerformed, EventHandler onWorkCompleted)
        {
            WorkPerformed = onWorkPerformed;
            WorkCompleted = onWorkCompleted;
        }

        public Worker()
        {

        }

        public void DoWork(object? sender, WorkPerformedEventArgs e)
        {
            if (e.Hours < 1)
                return;

            for (int i = 1; i <= e.Hours; i++)
            {
                OnWorkPerformed(sender, e);
            }

            OnWorkCompletion();
        }

        public void DoWork2(object? sender, WorkPerformedEventArgs e)
        {
            if (e.Hours < 1)
                return;

            for (int i = 1; i <= e.Hours; i++)
            {
                OnWorkPerformed(sender, e);
            }

            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(object? sender, WorkPerformedEventArgs e)
        {
            WorkPerformed?.Invoke(e);
        }

        protected virtual void OnWorkCompleted()
        {
            WorkCompleted?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnWorkCompletedWithNoArgs()
        {
            WorkCompletedWithNoArgs?.Invoke();
        }

        private void OnWorkCompletion()
        {
            OnWorkCompleted();
            OnWorkCompletedWithNoArgs();
        }
    }
}
