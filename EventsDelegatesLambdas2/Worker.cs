using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegatesLambdas2
{
    delegate int AddDelegate(int a, int b);

    internal class Worker
    {

        internal void DoWork(Action act)
        {
            Console.WriteLine("Starting DoWork Action...");
            act?.Invoke();

            Console.WriteLine("Work with Action done.");
        }

        internal bool DoWork(Func<bool>? func)
        {
            Console.WriteLine("Starting DoWork Func...");

            if (func is null)
                return false;

            var result = func.Invoke();
            Console.WriteLine("Work with Func done.");

            return result;
        }

        internal int DoAdd(AddDelegate add, WorkerArgs args)
        {
            return add(args.N1, args.N2);
        }

    }

    internal class WorkerArgs
    {
        public int N1 { get; set; } = 0;
        public int N2 { get; set; } = 0;
    }
}
