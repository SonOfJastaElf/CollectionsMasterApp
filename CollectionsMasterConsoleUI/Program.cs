using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Arrays
            int[] numbers = new int[50];

            Populater(numbers);

            Console.WriteLine($"\nIndex0: {numbers[0]} \n---------------------");

            Console.WriteLine($"Last Index {numbers[^1]} \n--------------------");

            Console.WriteLine("All numbers original");
            NumberPrinter(numbers);
            Console.WriteLine("-----------------------");

            Array.Reverse(numbers);

            Console.WriteLine("All numbers reversed");
            NumberPrinter(numbers);

            Console.WriteLine("-----------------REVERSE CUSTOM------------------------");
            ReverseArray(numbers);
            NumberPrinter(numbers);
            Console.WriteLine("----------------------------------");

            Console.WriteLine("Multiple of three = 0: ");
            ThreeKiller(numbers);
            NumberPrinter(numbers);
            Console.WriteLine();
            Console.WriteLine("-------------------------------");

            Console.WriteLine("Sorted Numbers:");
            Array.Sort(numbers);
            NumberPrinter(numbers);

            Console.WriteLine("\n*******************End Arrays****************************\n");

            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            List<int> numberList = new List<int>();

            Console.WriteLine($"List starting capacity: {numberList.Capacity}");
            Populater(numberList);
            Console.WriteLine($"List capacity after population: {numberList.Capacity}");
            Console.WriteLine("---------------------");

            Console.WriteLine("What number will you search for in the number list?");
            int searchNumber = int.Parse(Console.ReadLine());
            NumberChecker(numberList, searchNumber);
            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            NumberPrinter(numberList);
            Console.WriteLine("-------------------");

            Console.WriteLine("Evens Only!!");
            OddKiller(numberList);
            NumberPrinter(numberList);
            Console.WriteLine("------------------");

            Console.WriteLine("Sorted Evens!!");
            numberList.Sort();
            NumberPrinter(numberList);
            Console.WriteLine("------------------");

            var secondArray = numberList.ToArray();

            numberList.Clear();
            #endregion
        }

        private static void ThreeKiller(int[] numbers)
        {
           for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 3 == 0)
                {
                    numbers[i] = 0;
                }
            } 
        }

        private static void OddKiller(List<int> numberList)
        {
            foreach (var num in numberList)
            {
                if (num % 2 != 0)
                {
                    numberList.Remove(num);
                }
            }
        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            if (numberList.Contains(searchNumber))
            {
                Console.WriteLine("\n Found it! \n");
            }
            else
            {
                Console.WriteLine("That number is not on this list");
            }
        }

        private static void Populater(List<int> numberList)
        {
            Random rng = new Random();

            for (int i = 0; i < 50; i++) 
            {
                int rando = rng.Next(100);
                numberList.Add(rando);
            }
        }

        private static void Populater(int[] numbers)
        {
            Random rng = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                int rando = rng.Next(100);
                numbers[i] = rando;
            }

        }        

        private static void ReverseArray(int[] array)
        {
            int temp = 0;
            int lastIndex = array.Length - 1;

            for (int i = 0; i < array.Length / 2; i++)
            {
                temp = array[i];
                array[i] = array[lastIndex - i];
                array[lastIndex - i] = temp;
            }
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
