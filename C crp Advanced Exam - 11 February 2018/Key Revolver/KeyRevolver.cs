using System;
using System.Linq;
using System.Collections.Generic;

namespace Key_Revolver
{
    class KeyRevolver
    {
        static void Main(string[] args)
        {
            int buletCost = int.Parse(Console.ReadLine());
            int barelSize = int.Parse(Console.ReadLine());
            int[] buletsArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] locksArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int value = int.Parse(Console.ReadLine());
            Stack<int> bulets = new Stack<int>();
            Stack<int> locks = new Stack<int>();
            FillStack(buletsArr, bulets);
            Array.Reverse(locksArr);
            FillStack(locksArr, locks);
            int counter = barelSize;
            
            
            for (int i = bulets.Count; i >= 1 ; i--)
            {
                int bulet = bulets.Pop();
                int curentLock = locks.Peek();
                if (bulet <= curentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Pop();
                    
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                counter--;
                if (counter == 0 && bulets.Count != 0)
                {
                    Console.WriteLine("Reloading!");
                    counter = barelSize;
                }

                if (locks.Count == 0)
                {
                    break;
                }

                
            }

            if (locks.Count == 0)
            {
                value = value - ((buletsArr.Length - bulets.Count) * buletCost);
                Console.WriteLine($"{bulets.Count} bullets left. Earned ${value}");
            }
            if (bulets.Count == 0 && locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }

        private static void FillStack(int[] myArr, Stack<int> myStack)
        {
            for (int i = 0; i < myArr.Length; i++)
            {
                myStack.Push(myArr[i]);
            }
        }
    }
}
