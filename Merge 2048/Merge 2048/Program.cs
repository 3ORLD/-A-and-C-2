using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Test
{
    internal class Pti
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Computing\source\repos\-A-and-C-2\Merge 2048\Merge 2048\bin\Debug";
            string[] files = Directory.GetFiles(path, "*txt", SearchOption.TopDirectoryOnly);
            using (var output = System.IO.File.Create(path + "final_2048.txt"))
            {
                foreach (var file in files)
                {
                    using (var data = System.IO.File.OpenRead(file))
                    {
                        data.CopyTo(output);
                    }
                }
            }
            StreamReader sr = new StreamReader("final_2048.txt");

            string line = "";
            int counter = 0;

            while ((line = sr.ReadLine()) != null)
            {
                counter++;

                Console.WriteLine("{0}:{1}", counter, line);
            }
            string[] lines = System.IO.File.ReadAllLines("final_2048.txt");

            int[] numbers = new int[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                numbers[i] = int.Parse(lines[i]);
            }
            // sort in ascending order using bubble sort
            BubbleSort(numbers);


            Console.WriteLine("Contents of " + "final_2048.txt" + " in ascending order:");
            PrintArray(numbers);


            // sort in descending order using bubble sort
            BubbleSortDescending(numbers);


            Console.WriteLine("\nContents of " + "final_2048.txt" + " in descending order:");
            PrintArray(numbers);


            for (int i = 0; i < lines.Length; i++)
            {
                numbers[i] = int.Parse(lines[i]);

                // Print every 50th value
                if (i % 50 == 0)
                {
                    Console.WriteLine("Value at index " + i + ": " + numbers[i]);
                }
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
                Console.WriteLine("Press any Key to close");
                Console.ReadLine();
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