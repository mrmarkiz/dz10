using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz10
{
    internal class Task5
    {
        public static void Run()
        {
            var showUniqueNegative = (int[] array) =>
            {
                int[] result = array.Distinct().ToArray();
                foreach (int i in result)
                    if (i < 0)
                        Console.Write($"{i} ");
                Console.WriteLine();
            };
            int[] array = Init();
            Console.WriteLine("Array elements:");
            Show(array);
            Console.WriteLine("Unique negative elements:");
            showUniqueNegative(array);
        }

        public static int[] Init(int n)
        {
            int[] temp = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < temp.Length; i++)
                temp[i] = rnd.Next(-10, 10);
            return temp;
        }
        public static int[] Init()
        {
            int[] temp = new int[10];
            Random rnd = new Random();
            for (int i = 0; i < temp.Length; i++)
                temp[i] = rnd.Next(-10, 10);
            return temp;
        }
        public static void Show(int[] arr)
        {
            foreach (int i in arr)
                Console.Write($"{i} ");
            Console.WriteLine();
        }
    }
}
