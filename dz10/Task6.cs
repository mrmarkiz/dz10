using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace dz10
{
    internal class Task6
    {
        public static void Run()
        {
            Console.WriteLine("Enter string to check on word:");
            string input = Console.ReadLine();
            Console.Write("Enter word to find: ");
            string word = Console.ReadLine();
            var countWord = (string input, string word) =>
            {
                int result = 0;
                string[] text = input.Split(' ', ',', '.');
                foreach (string s in text)
                    if (s.ToLower() == word.ToLower())
                        result++;
                return result;
            };
            Console.WriteLine($"Number of such words in the input text: {countWord(input, word)}");
        }

    }
}
