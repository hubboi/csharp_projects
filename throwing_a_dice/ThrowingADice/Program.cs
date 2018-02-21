using System;
using System.Collections.Generic;

namespace ThrowingADice
{
    class Program
    {
        static int Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //int k = Program.AddNumbers(3, 4);
            //Console.WriteLine(k);
            Random rnd = new Random();
            int listLength = rnd.Next(10, 100); // rnd.Next(a, b) creates a number between a and b-1
            int start = 3;
            int stop = 19;
            Console.WriteLine(listLength);
            List<int> mainList = Program.RandomListOfIntegers(listLength, start, stop);
            //int[] p = new int[] {1, 2, 3, 4, 5 ,6};
            //int[] a = new int[] {1, 2};
            //int[] b = new int[] {2, 1};
            //Program.IndependencyCheck(p, a, b);
            Console.WriteLine(mainList);
            Console.ReadLine();
            return 0;
        }

        public static int AddNumbers(int number1, int number2)
        {
            int result = number1 + number2;
            return result;
        }

        public static void IndependencyCheck(int[] p, int[] a, int[] b)
        {

            int numberOfElementsInA = a.Length;
            int numberOfElementsInB = b.Length;
            var intersection = new List<int>();

            for (int i = 0; i < numberOfElementsInA; i++)
            {
                for (int j = 0; j < numberOfElementsInB; j++)
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
                //string message = "Events a and b are independent.";
                //Console.WriteLine(message);
                bool independency = true;
                Console.WriteLine(independency);
            }
            else
            {
                float abIntersection = intersection.Count / p.Length;
                float abProduct = a.Length * b.Length / (p.Length) ^ 2;
                if (abIntersection == abProduct)
                {
                    //string message = "Events a and b are independent.";
                    //Console.WriteLine(message);
                    bool independency = true;
                    Console.WriteLine(independency);
                }
                else
                {
                    //string message = "Events a and b are dependent.";
                    //Console.WriteLine(message);
                    bool independency = false;
                    Console.WriteLine(independency);
                }
            }
        }

        public static List<int> RandomListOfIntegers(int listLength, int lowerLimit, int upperLimit)
        {

            var mainList = new List<int>();
            Random thisElement = new Random();
            for (int i = 0; i < listLength; i++)
            {
                mainList.Add(thisElement.Next(lowerLimit, upperLimit - 1));
                //Console.WriteLine(mainList[i]);

            }
            return mainList;

        }

        //public static void PairwiseIndependencyCheck(int[] p, int[] a, int[] b)

    }
}
