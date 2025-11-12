using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Tasks67
    {
        private byte hours, minutes;

        public Tasks67(byte h, byte m)
        {
            if (h > 23 || m > 59) throw new ArgumentException();
            hours = h;
            minutes = m;
        }

        public override string ToString() => $"{hours:D2}:{minutes:D2}";

        public static Tasks67 operator +(Tasks67 t1, Tasks67 t2)
        {
            int diff = (t1.hours * 60 + t1.minutes) + (t2.hours * 60 + t2.minutes);
            if (diff < 0) diff += 1440;
            return new Tasks67((byte)(diff / 60), (byte)(diff % 60));
        }

        public static Tasks67 operator -(Tasks67 t1, Tasks67 t2)
        {
            int diff = (t1.hours * 60 + t1.minutes) - (t2.hours * 60 + t2.minutes);
            if (diff < 0) diff += 1440;
            return new Tasks67((byte)(diff / 60), (byte)(diff % 60));
        }

        public static Tasks67 InputTime()
        {
            while (true)
            {
                try
                {
                    Console.Write("Часы: ");
                    byte h = byte.Parse(Console.ReadLine());
                    Console.Write("Минуты: ");
                    byte m = byte.Parse(Console.ReadLine());
                    return new Tasks67(h, m);
                }
                catch { Console.WriteLine("Ошибка"); }
            }
        }
    }
}

    