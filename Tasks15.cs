using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Tasks15
    {
        // Удаляет повторяющиеся элементы, оставляя только первые вхождения
        public static List<int> RemoveDup(List<int> list)
        {
            List<int> result = new List<int>();

            foreach (int number in list)
            {
                // Если числа еще нет в результате - добавляем его
                if (!result.Contains(number))
                {
                    result.Add(number);
                }
            }

            return result;
        }

        // Если у элемента со значением E "соседи" не равны, поменять их местами
        public static void SwapNeighbors(LinkedList<int> list, int E)
        {
            // Проходим по всем элементам списка
            LinkedListNode<int> current = list.First;

            while (current != null)
            {
                // Если нашли элемент с значением E
                if (current.Value == E)
                {
                    // Получаем левого и правого соседа
                    LinkedListNode<int> left = current.Previous;
                    LinkedListNode<int> right = current.Next;

                    // Проверяем, что оба соседа существуют и они разные
                    if (left != null && right != null && left.Value != right.Value)
                    {
                        // Меняем соседей местами
                        int x = left.Value;
                        left.Value = right.Value;
                        right.Value = x;
                    }
                }

                current = current.Next;
            }
        }

        public static void AnalyzeLanguages(List<HashSet<string>> workers, string[] allLanguages)
        {
            // Языки, которые знают все
            HashSet<string> allKnow = new HashSet<string>(allLanguages);
            foreach (HashSet<string> worker in workers)
            {
                allKnow.IntersectWith(worker);
            }
            Console.WriteLine("\nВсе знают: " + string.Join(", ", allKnow));

            // Языки, которые знает хотя бы один
            HashSet<string> anyKnows = new HashSet<string>();
            foreach (HashSet<string> worker in workers)
            {
                anyKnows.UnionWith(worker);
            }
            Console.WriteLine("Хотя бы один знает: " + string.Join(", ", anyKnows));

            // Языки, которые никто не знает
            HashSet<string> allLangs = new HashSet<string>(allLanguages);
            HashSet<string> nobodyKnows = new HashSet<string>(allLangs);
            nobodyKnows.ExceptWith(anyKnows);
            Console.WriteLine("Никто не знает: " + string.Join(", ", nobodyKnows));

            // Для каждого языка - кто знает
            Console.WriteLine("\nКто знает каждый язык:");
            foreach (string lang in allLanguages)
            {
                List<int> knowers = new List<int>();
                for (int i = 0; i < workers.Count; i++)
                {
                    if (workers[i].Contains(lang))
                    {
                        knowers.Add(i + 1);
                    }
                }

                if (knowers.Count > 0)
                {
                    Console.WriteLine($"{lang}: {string.Join(", ", knowers)}");
                }
                else
                {
                    Console.WriteLine($"{lang}: никто");
                }
            }
        }

        public static HashSet<char> GetFirstL (string text)
        {
            HashSet<char> letters = new HashSet<char>();

            // Разбиваем текст на слова (учитываем разные разделители)
            char[] separators = { ' ', ',', '.', '!', '?', ';', ':', '\n', '\r', '\t' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (word.Length > 0)
                {
                    char firstLetter = char.ToLower(word[0]);

                    // Проверяем, что это русская буква
                    if (IsRusL(firstLetter))
                    {
                        letters.Add(firstLetter);
                    }
                }
            }

            return letters;
        }
        // Проверяем, является ли символ русской буквой
        private static bool IsRusL(char c)
        {
            return (c >= 'а' && c <= 'я') || c == 'ё';
        }

    }
   
}
