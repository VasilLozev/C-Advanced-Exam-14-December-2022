using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml;

namespace NavyBattle
{
    public class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[][] matrix = new char[size][];
            int subRow = 0;
            int subCol = 0;
            for (int i = 0; i < size; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if(matrix[i][j] == 'S')
                    {
                        subRow = i;
                        subCol = j;
                    }
                }
            }
            
            int countHits = 0;
            int countCruiser = 0;
            while (true)
            {
                string direction = Console.ReadLine();
                matrix[subRow][subCol] = '-';
                switch (direction)
                {
                    case "up":
                        subRow--;
                        break;
                    case "down":
                        subRow++;
                        break;
                    case "left":
                        subCol--;
                        break;
                    case "right":
                        subCol++;
                        break;
                }
                if (matrix[subRow][subCol] == '-')
                {
                    matrix[subRow][subCol] = 'S';
                }
                if (matrix[subRow][subCol] == '*')
                {
                    countHits++;
                    matrix[subRow][subCol] = 'S';
                    if (countHits == 3)
                    {
                        Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{subRow}, {subCol}]!");
                        matrix[subRow][subCol] = 'S';
                        break;
                    }
                }
                if (matrix[subRow][subCol] == 'C')
                {
                    countCruiser++;
                    if (countCruiser == 3)
                    {
                        Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                        matrix[subRow][subCol] = 'S';
                        break;
                    }
                }
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
