using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegatesLambdas
{
    public class ProcessData
    {
        public int Process(int x, int y, BizRulesDelegate del)
        {
            var result = del(x, y);

            return result;
        }
    }
}
