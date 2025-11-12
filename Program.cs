using Lab4;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        while (true)
        {
            check check = new check();
            Console.WriteLine("Выберите номер задания (1,2,3,4,6)");
            string taskNumber;
            taskNumber = Console.ReadLine();

            switch (taskNumber)
            {
                case "1": // Задание 1
                    {
                        Console.WriteLine("=== Удаление повторяющихся элементов ===");

                        // Создаем List 
                        List<int> numbers = new List<int>();

                    
                        int elem = check.ReadInt("Введите количество элементов в списке ");


                        for (int i = 0; i < elem; i++)
                        {
                            int input = check.ReadInt($"Число {i + 1}: ");

                            numbers.Add(input);
                        }

                        // Выводим исходный список
                        Console.WriteLine("\nИсходный список: " + string.Join(", ", numbers));

                        // Удаляем дубликаты
                        List<int> result = Tasks15.RemoveDup(numbers);

                        // Выводим результат
                        Console.WriteLine("Список без дубликатов: " + string.Join(", ", result));
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("=== LinkedList - Обмен соседей ===");

                        // Создаем LinkedList и вводим 7 чисел
                        LinkedList<int> list = new LinkedList<int>();

                        Console.WriteLine("Введите 7 чисел:");
                        for (int i = 0; i < 7; i++)
                        {
                            int number = check.ReadInt($"Число {i + 1}: ");
                            list.AddLast(number);
                        }
                 
                        List<HashSet<string>> workers = new List<HashSet<string>>();
                        // Вводим значение E
                        int E = check.ReadInt("Введите значение E: ");

                        // Выводим исходный список
                        Console.Write("\nИсходный список: ");
                        foreach (int num in list)
                        {
                            Console.Write(num + " ");
                        }

                        // Вызываем метод для обмена соседей
                        Tasks15.SwapNeighbors(list, E);

                        // Выводим результат
                        Console.Write("\nПосле обмена: ");
                        foreach (int num in list)
                        {
                            Console.Write(num + " ");
                        }
                        Console.WriteLine();
                        break;
                    }
                case "3":
                    {
                        string[] allLanguages = { "Английский", "Немецкий", "Французский", "Испанский", "Китайский" };

                       
                        int count = check.ReadInt("Сколько работников? ");

                        List<HashSet<string>> workers = new List<HashSet<string>>();

                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine($"\nРаботник {i + 1}:");
                            Console.WriteLine("Языки: " + string.Join(", ", allLanguages));
                            Console.Write("Введите языки через запятую: ");

                            string input = Console.ReadLine();
                            HashSet<string> workerLangs = new HashSet<string>();

                            foreach (string lang in input.Split(','))
                            {
                                workerLangs.Add(lang.Trim());
                            }

                            workers.Add(workerLangs);
                        }

                        Tasks15.AnalyzeLanguages(workers, allLanguages);
                        break;
                    }
                case "4":
                    {
                        Console.WriteLine("=== Первые буквы слов из файла ===");
                        string filePath = "Text4.txt";

                        // Читаем текст из файла
                        string text = File.ReadAllText(filePath);
                        Console.WriteLine($"\nТекст из файла:\n{text}");

                        // Получаем первые буквы слов
                        HashSet<char> firstLetters = Tasks15.GetFirstL(text);

                        // Выводим результат
                        Console.WriteLine("\nСлова начинаются с букв: " + string.Join(", ", firstLetters));
                        break;
                    }

                case "6":
                    {
                        Console.WriteLine("Введите первое время:");
                        Tasks67 time1 = Tasks67.InputTime();

                        Console.WriteLine("Введите второе время:");
                        Tasks67 time2 = Tasks67.InputTime();

                        Console.WriteLine($"{time1} - {time2} = {time1 - time2}");

                        break;
                    }
                default:
                    {
                        Console.WriteLine("Неизвестное число");
                        break;
                    }
            }

        }
    }
}