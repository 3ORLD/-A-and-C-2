using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Search_Jesse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "Road_1_2048.txt";
            string fileP = "Road_2_2048.txt";
            string fileC = "Road_3_2048.txt";

            string[] lines = File.ReadAllLines(filePath);
            string[] lines1 = File.ReadAllLines(fileP);
            string[] lines2 = File.ReadAllLines(fileC);

            int[] numbers = new int[lines.Length];
            int[] numbers1 = new int[lines1.Length];
            int[] numbers2 = new int[lines2.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                numbers[i] = int.Parse(lines[i]);
            }

            for (int i = 0; i < lines1.Length; i++)
            {
                numbers1[i] = int.Parse(lines1[i]);
            }

            for (int i = 0; i < lines2.Length; i++)
            {
                numbers2[i] = int.Parse(lines2[i]);
            }

            // sort in ascending order using bubble sort
            BubbleSort(numbers);
            BubbleSort(numbers1);
            BubbleSort(numbers2);

            Console.WriteLine("Contents of " + filePath + " in ascending order:");
            PrintArray(numbers);

            Console.WriteLine("\nContents of " + fileP + " in ascending order:");
            PrintArray(numbers1);

            Console.WriteLine("\nContents of " + fileC + " in ascending order:");
            PrintArray(numbers2);

            // sort in descending order using bubble sort
            BubbleSortDescending(numbers);
            BubbleSortDescending(numbers1);
            BubbleSortDescending(numbers2);

            Console.WriteLine("\nContents of " + filePath + " in descending order:");
            PrintArray(numbers);

            Console.WriteLine("\nContents of " + fileP + " in descending order:");
            PrintArray(numbers1);

            Console.WriteLine("\nContents of " + fileC + " in descending order:");
            PrintArray(numbers2);

            for (int i = 0; i < lines.Length; i++)
            {
                numbers[i] = int.Parse(lines[i]);

                // Print every 50th value
                if (i % 50 == 0)
                {
                    Console.WriteLine("Value at index " + i + ": " + numbers[i]);
                }
            }

            for (int i = 0; i < lines1.Length; i++)
            {
                numbers1[i] = int.Parse(lines1[i]);

                // Print every 50th value
                if (i % 50 == 0)
                {
                    Console.WriteLine("Value at index " + i + ": " + numbers1[i]);
                }
            }

            for (int i = 0; i < lines2.Length; i++)
            {
                numbers2[i] = int.Parse(lines2[i]);

                // Print every 50th value
                if (i % 50 == 0)
                {
                    Console.WriteLine("Value at index " + i + ": " + numbers2[i]);
                }

                // Get user-defined value to search
                Console.Write("Enter value to search: ");
                int searchValue = int.Parse(Console.ReadLine());

                // Search for value in array
                List<int> indexes = new List<int>();
                for (int V = 0; V < numbers.Length; V++)
                {
                    if (numbers[V] == searchValue)
                    {
                        indexes.Add(V);
                    }
                }

                // Check if value exists in array
                if (indexes.Count > 0)
                {
                    Console.Write("Value " + searchValue + " found at index(es): ");
                    foreach (int index in indexes)
                    {
                        Console.Write(index + " ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Value " + searchValue + " not found in array.");

                    // Find nearest values and their indexes
                    int nearestIndex1 = Array.BinarySearch(numbers, searchValue);
                    int nearestIndex2 = ~nearestIndex1;

                    if (nearestIndex1 >= 0)
                    {
                        Console.WriteLine("The value " + searchValue + " is at index " + nearestIndex1);
                    }
                    else if (nearestIndex2 < numbers.Length)
                    {
                        int nearestValue1 = numbers[nearestIndex2 - 1];
                        int nearestValue2 = numbers[nearestIndex2];

                        Console.WriteLine("The nearest values to " + searchValue + " are " + nearestValue1 + " and " + nearestValue2);
                        Console.WriteLine("The indexes of the nearest values are " + (nearestIndex2 - 1) + " and " + nearestIndex2);
                    }
                    else
                    {
                        Console.WriteLine("The value " + searchValue + " is larger than all values in the array.");
                    }

                    Console.ReadLine();
                }
            }
        }

        private static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        private static void BubbleSortDescending(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        private static void PrintArray(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
        }
    }
}
