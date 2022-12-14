using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml;

namespace ClimbthePeaks
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> peaks = new List<string>();

            Stack<int> foodPortions = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            Queue<int> stamina = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            Dictionary<string, int> MountainPeaks = new Dictionary<string, int>
            {
                {"Vihren", 80 }  ,
                {"Kutelo",90 }       ,
                {"Banski Suhodol", 100 },
                { "Polezhan", 60},
                {"Kamenitza", 70 },
            };
            int count = 0;
            while (true)
            {
                if (foodPortions.Count == 0)
                {
                    break;
                }
                if (stamina.Count == 0)
                {
                    break;
                }
                int food = foodPortions.Pop();
                int stam = stamina.Dequeue();
                if (count == 7)
                {
                    break;
                }
                foreach (var item in MountainPeaks)
                {
                    if (food + stam >= item.Value)
                    {
                        peaks.Add(item.Key);
                        MountainPeaks.Remove(item.Key);
                        break;
                    }
                    else
                    {
                        count++;
                        break;
                    }
                }
            }

            if (MountainPeaks.Count == 0)
            {
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            }
            else
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            }

            if (peaks.Count > 0)
            {
                Console.WriteLine("Conquered peaks:");
                Console.WriteLine(String.Join($"{Environment.NewLine}", peaks));
            }
        }
    }
}
