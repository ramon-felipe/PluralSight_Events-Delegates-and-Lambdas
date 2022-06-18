using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegatesLambdas2
{
    internal class DataProcessor
    {
        internal static (int, string) Process(int x, Func<int, (int, string)> f)
        {
            var result = f(x);

            return result;
        }
    }
}
