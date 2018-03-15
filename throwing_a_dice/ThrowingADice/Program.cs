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
            int mainSetLength = rnd.Next(10, 100); // rnd.Next(a, b) creates a number between a and b-1
            int subsetLength = rnd.Next(1, mainSetLength + 1);
            int start = 3;
            int stop = 19;
            bool repeatedElements = true;
            //string length = 'Number of elements in the list is ';
            string newString = "the number of elements in the main set is: " + mainSetLength.ToString();
            //Console.WriteLine(newString);
            List<int> mainSet = Program.RandomListOfIntegers(mainSetLength, start, stop, repeatedElements);
            List<int> p = new List<int>(new int[] { 1, 2, 3 });
            p.Swap(1, 2);

            Console.WriteLine(p.PrintNumbersToString());


            //List<List<int>> listOfSubsets = Program.ListOfRandomSubsetsFromTheMainSet(mainSet, mainSetLength, subsetLength, numberOfSubsets);
            //bool independence = Program.PairwiseIndependenceCheck(mainSetLength, listOfSubsets, numberOfSubsets);
            //string newString2 = "are the subsets pairwise independent: " + independence.ToString();
            //Console.WriteLine(newString2);
            Console.ReadLine();
            return 0;
        }


        public static int AddNumbers(int number1, int number2)
        {
            int result = number1 + number2;
            return result;
        }

        public static bool IndependenceCheck(int mainSetLength, List<int> a, List<int> b)
        {
            bool independence;
            int numberOfElementsInA = a.Count;
            int numberOfElementsInB = b.Count;
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
                independence = true;
            }
            else
            {
                float abIntersection = intersection.Count / mainSetLength;
                float abProduct = numberOfElementsInA * numberOfElementsInB / (mainSetLength) ^ 2;
                if (abIntersection == abProduct)
                {
                    //string message = "Events a and b are independent.";
                    //Console.WriteLine(message);
                    independence = true;
                }
                else
                {
                    //string message = "Events a and b are dependent.";
                    //Console.WriteLine(message);
                    independence = false;
                }
            }
            return independence;
        }

        public static List<int> RandomListOfIntegers(int listLength, int lowerLimit, int upperLimit, bool repeatedElements)
        {
            List<int> mainSet = new List<int>();
            if (repeatedElements)
            {
                mainSet = new List<int>(listLength);
                Random rnd = new Random();
                for (int i = 0; i < listLength; i++)
                {
                    int thisElement = rnd.Next(lowerLimit, upperLimit + 1);
                    mainSet.Add(thisElement);
                    //Console.WriteLine(mainList[i]);
                }
            }
            else
            {
                if (listLength > upperLimit - lowerLimit + 1)
                {
                    Console.WriteLine("The length of the list is larger than the number of integers " +
                        " within the bounds, please choose again!");
                }
                else
                {
                    mainSet = new List<int>(listLength);
                    Random rnd = new Random();
                    for (int i = 0; i < listLength; i++)
                    {
                        int thisElement = rnd.Next(lowerLimit, upperLimit + 1);
                        while (mainSet.Contains(thisElement))
                        {
                            thisElement = rnd.Next(lowerLimit, upperLimit + 1);
                        }
                        mainSet.Add(thisElement);
                        //Console.WriteLine(mainList[i]);
                    }
                }
            }
            return mainSet;
        }

        public static List<int> OneRandomSubsetFromTheMainSet(List<int> mainSet)
        {
            int mainSetLength = mainSet.Count;
            var subset = new List<int>();
            Random rnd = new Random();
            int subsetLength = rnd.Next(1, mainSetLength + 1);
            for (int i = 0; i < subsetLength; i++)
            {
                int thisIndex = rnd.Next(0, mainSetLength);
                int thisElement = mainSet[thisIndex];
                subset.Add(thisElement);
            }
                return subset;
        }

        public static List<List<int>> ListOfRandomSubsetsFromTheMainSet(List<int> mainSet, int mainSetLength, int subsetLength, int numberOfSubsets)
        {
            var listOfSubsets = new List<List<int>>();
            for (int i = 0; i < subsetLength; i++)
            {
                List<int> thisList = OneRandomSubsetFromTheMainSet(mainSet);
                listOfSubsets.Add(thisList);
            }
            return listOfSubsets;
        }

        public static bool PairwiseIndependenceCheck(int mainSetLength, List<List<int>> listOfSubsets, int numberOfSubsets)
        {
            bool pairwiseIndependence = true;
            for (int i = 0; i < numberOfSubsets - 1; i++)
            {
                for (int j = i; j < numberOfSubsets - i - 1; j++)
                {
                    pairwiseIndependence = IndependenceCheck(mainSetLength, listOfSubsets[j], listOfSubsets[j+1]);
                    if (pairwiseIndependence == false)
                        {
                            i = numberOfSubsets; // breaks out of the first loop too
                            break;
                        }
                }
            }
            return pairwiseIndependence;
        }
    }
    
}
