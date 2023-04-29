using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz10
{
    public delegate int[] GetRGB(string color);

    internal class Task1
    {
        public static void Run()
        {
            GetRGB rgbConverter = delegate (string color)
            {
                color = color.ToLower();
                switch (color)
                {
                    case "red":
                        return new int[] { 255, 0, 0 };
                    case "orange":
                        return new int[] { 255, 165, 0 };
                    case "yellow":
                        return new int[] { 255, 255, 0 };
                    case "green":
                        return new int[] { 0, 255, 0 };
                    case "blue":
                        return new int[] { 0, 0, 255 };
                    case "indigo":
                        return new int[] { 75, 0, 130 };
                    case "violet":
                        return new int[] { 238, 130, 238 };
                }
                return new int[] { 0, 0, 0 };
            };
            Console.WriteLine("Enter color of rainbow you want to onvert to RGB:");
            string color = Console.ReadLine();
            Console.WriteLine("Result:");
            Show(rgbConverter(color));
        }
        public static void Show(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
    }
}
