using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz10
{
    internal class Task3
    {
        public static void Run()
        {
            var countMult7 = (int[] array) =>
            {
                int result = 0;
                foreach (int i in array)
                    if (i % 7 == 0)
                        result++;
                return result;
            };
            int[] array = Init();
            Console.WriteLine("Array elemnts:");
            Show(array);
            Console.WriteLine($"Number of element multiple by 7: {countMult7(array)}");
        }
        public static int[] Init(int n)
        {
            int[] temp=new int[n];
            Random rnd = new Random();
            for (int i = 0; i < temp.Length; i++)
                temp[i] = rnd.Next(-30, 30);
            return temp;
        }
        public static int[] Init()
        {
            int[] temp = new int[10];
            Random rnd = new Random();
            for (int i = 0; i < temp.Length; i++)
                temp[i] = rnd.Next(-30, 30);
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
