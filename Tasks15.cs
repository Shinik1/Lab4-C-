using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Tasks15
    {
        
        public static List<int> RemoveDup(List<int> list)
        {
            List<int> result = new List<int>();

            foreach (int number in list)
            {
                
                if (!result.Contains(number))
                {
                    result.Add(number);
                }
            }

            return result;
        }

       
        public static void SwapNeighbors(LinkedList<int> list, int E)
        {
        
            LinkedListNode<int> current = list.First;

            while (current != null)
            {
                
                if (current.Value == E)
                {
                 
                    LinkedListNode<int> left = current.Previous;
                    LinkedListNode<int> right = current.Next;

                   
                    if (left != null && right != null && left.Value != right.Value)
                    {
                        
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
            
            HashSet<string> allKnow = new HashSet<string>(allLanguages);
            foreach (HashSet<string> worker in workers)
            {
                allKnow.IntersectWith(worker);
            }
            Console.WriteLine("\nВсе знают: " + string.Join(", ", allKnow));

            
            HashSet<string> anyKnows = new HashSet<string>();
            foreach (HashSet<string> worker in workers)
            {
                anyKnows.UnionWith(worker);
            }
            Console.WriteLine("Хотя бы один знает: " + string.Join(", ", anyKnows));

            
            HashSet<string> allLangs = new HashSet<string>(allLanguages);
            HashSet<string> nobodyKnows = new HashSet<string>(allLangs);
            nobodyKnows.ExceptWith(anyKnows);
            Console.WriteLine("Никто не знает: " + string.Join(", ", nobodyKnows));

           
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

            
            char[] separators = { ' ', ',', '.', '!', '?', ';', ':', '\n' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (word.Length > 0)
                {
                    char firstLetter = char.ToLower(word[0]);

                  
                    if (IsRusL(firstLetter))
                    {
                        letters.Add(firstLetter);
                    }
                }
            }

            return letters;
        }
        
        private static bool IsRusL(char c)
        {
            return (c >= 'а' && c <= 'я') || c == 'ё';
        }

    }
   
}
