using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
                // Part 1: Create jagged array with given values
                int[][] jagged1 = new int[4][];
                jagged1[0] = new int[] { 1, 1, 1, 1, 1 };
                jagged1[1] = new int[] { 2, 2 };
                jagged1[2] = new int[] { 3, 3, 3, 3 };
                jagged1[3] = new int[] { 4, 4 };

                Console.WriteLine("=== Fixed Jagged Array ===");
                PrintJagged(jagged1);

                // Part 2: Create jagged array by user input
                Console.Write("Enter number of rows: ");
                int rows = int.Parse(Console.ReadLine());
                int[][] jagged2 = new int[rows][];

                Random rand = new Random();
                for (int i = 0; i < rows; i++)
                {
                    Console.Write($"Enter number of columns for row {i}: ");
                    int cols = int.Parse(Console.ReadLine());
                    jagged2[i] = new int[cols];
                    for (int j = 0; j < cols; j++)
                    {
                        jagged2[i][j] = rand.Next(1, 50); // random 1-50
                    }
                }

                Console.WriteLine("\n=== Random Jagged Array ===");
                PrintJagged(jagged2);

                // 1. Biggest number of each row + whole array
                Console.WriteLine("\nBiggest number in each row:");
                int globalMax = int.MinValue;
                for (int i = 0; i < jagged2.Length; i++)
                {
                    int rowMax = int.MinValue;
                    foreach (int num in jagged2[i])
                    {
                        if (num > rowMax) rowMax = num;
                        if (num > globalMax) globalMax = num;
                    }
                    Console.WriteLine($"Row {i}: {rowMax}");
                }
                Console.WriteLine($"Largest number in whole array: {globalMax}");

                // 2. Sort ascending each row
                Console.WriteLine("\nSorted rows:");
                for (int i = 0; i < jagged2.Length; i++)
                {
                    Array.Sort(jagged2[i]);
                }
                PrintJagged(jagged2);

                // 3. Print prime numbers
                Console.WriteLine("\nPrime numbers:");
                for (int i = 0; i < jagged2.Length; i++)
                {
                    foreach (int num in jagged2[i])
                    {
                        if (IsPrime(num)) Console.Write(num + " ");
                    }
                }
                Console.WriteLine();

                // 4. Search and print positions of a number
                Console.Write("\nEnter number to search: ");
                int target = int.Parse(Console.ReadLine());
                Console.WriteLine($"Positions of {target}:");
                for (int i = 0; i < jagged2.Length; i++)
                {
                    for (int j = 0; j < jagged2[i].Length; j++)
                    {
                        if (jagged2[i][j] == target)
                            Console.WriteLine($"Found at row {i}, col {j}");
                    }
                }
            }

            // helper: print jagged array
            static void PrintJagged(int[][] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine(string.Join(" ", arr[i]));
                }
            }

            // helper: check prime
            static bool IsPrime(int n)
            {
                if (n < 2) return false;
                for (int i = 2; i * i <= n; i++)
                    if (n % i == 0) return false;
                return true;
            }
        }
    }