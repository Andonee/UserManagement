using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Utils
{
    internal class ConsoleInputHelper
    {
        public static string ReadRequiredInput(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim(); // remove leading/trailing spaces
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Error: This field is required. Please enter a value.");
                }
            } while (string.IsNullOrEmpty(input));

            return input;
        }

        public static int ReadRequiredInt(string prompt)
        {
            while (true)
            {
                string input = ReadRequiredInput(prompt);
                if (int.TryParse(input, out int value))
                    return value;

                Console.WriteLine("Error: Please enter a valid number.");
            }
        }
    }
}
