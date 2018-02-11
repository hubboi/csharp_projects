using System;
using System.Collections.Generic;

namespace ThrowingADice
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int k = Program.AddNumbers(3, 4);
            Console.WriteLine(k);
            int[] p = new int[] {1, 2, 3, 4, 5 ,6};
            int[] a = new int[] {1, 2};
            int[] b = new int[] {2, 1};
            Program.IndependencyCheck(p, a, b);
            return 0;
        }

        public static int AddNumbers(int number1, int number2)
        {
            int result = number1 + number2;
            return result;
        }

        public static void IndependencyCheck(int[] p, int[] a, int[] b)
        {
            for (int i = 0; i < p.Length; i++)
            {
                Console.WriteLine(p[i]);
            }
            int numberOfElementsInA = a.Length;
            int numberOfElementsInB = b.Length;

            var intersection = new List<int>();

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                    {
                        intersection.Add(a[i]);
                        break;
                    }
                }
            }
            if (intersection.Count == 0)
            {
                string message = "Events a and b are independent.";
                Console.WriteLine(message);
            }
            else 
            {
                float abIntersection = intersection.Count / p.Length;
                float abProduct = a.Length * b.Length / (p.Length) ^ 2;
                if (abIntersection == abProduct)
                {
                    string message = "Events a and b are dependent.";
                    Console.WriteLine(message);
                }
                else
                {
                    string message = "Events a and b are independent.";
                    Console.WriteLine(message);
                }
            }
        }


    }
}
