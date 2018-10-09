using System;
using System.Linq;
using System.Collections.Generic;

namespace SetsofElements
{
    class SetsofElements
    {
        static void Main(string[] args)
        {
            int[] lenght = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            HashSet<int> setN = new HashSet<int>();
            HashSet<int> setM = new HashSet<int>();
            for (int i = 0; i < lenght[0]; i++)
                setN.Add(int.Parse(Console.ReadLine()));
            for (int i = 0; i < lenght[1]; i++)
                setM.Add(int.Parse(Console.ReadLine()));
            setN.IntersectWith(setM);
            Console.WriteLine(string.Join(" ", setN));
        }
    }
}
