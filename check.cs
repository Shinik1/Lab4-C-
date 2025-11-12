using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class check
    {
        // Методы для проверки ввода
        public int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                    return result;
                Console.WriteLine("Ошибка! Введите целое число.");
            }
        }
    }
}
