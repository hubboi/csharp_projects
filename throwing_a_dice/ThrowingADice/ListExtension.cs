using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace ThrowingADice
{
    public static class ListExtension
    {
        /// <summary>
        /// Shuffle allows the shuffling of a list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="rnd"></param>
        /// 
        public static class ThreadSafeRandom
        {
            [ThreadStatic] private static Random Local;

            public static Random ThisThreadsRandom
            {
                get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
            }
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static void Swap<T>(this IList<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        public static string PrintNumbersToString<T>(this IList<T> list)
        {
            string outputString = string.Empty;
            foreach (T number in list)
            {
                outputString += number.ToString() + " ";
            }
            return outputString;
        }
    }
}
