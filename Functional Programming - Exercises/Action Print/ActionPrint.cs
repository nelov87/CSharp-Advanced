using System;
using System.Linq;

namespace Action_Print
{
    class ActionPrint
    {
        static void Main(string[] args)
        {
            Action<string> Print = x => Console.WriteLine(x);

            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(Print);
        }
    }
}
