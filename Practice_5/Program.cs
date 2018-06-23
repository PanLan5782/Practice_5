using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = InputData("n=");
            int [,] array = GenerateArray(n);
            PrintArray(array);
            int temp = FindMax(array);
            Console.WriteLine($"Максимальный элемент массива:{temp}");
        }
        public static int [,] GenerateArray(int n)
        {
            Random rnd = new Random();
            int[,] array = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    array[i, j] = rnd.Next(0, 100);
            return array;
        }
        public static int InputData(String prompt)
        {
            bool ok = true;
            int v = 0;
            do
            {
                Console.Write(prompt);
                ok = int.TryParse(Console.ReadLine(), out v);
                if (!ok)
                    Console.WriteLine("Введенный символ не является числом. Повторите ввод.");
            }
            while (!ok);
            return v;
        }
        public static int FindMax(int [,] array)
        {
            int Max = int.MinValue;
            int n = array.GetLength(0);
            for (int i = 0; i < n / 2; i++)
                for (int j = 0; j < n; j++)
                    if (j < n / 2 && j >= i)
                        if (Max < array[i, j])
                            Max = array[i, j];
                        else if (j >= n / 2 && i > n - j - 1)
                            if (Max < array[i, j])
                                Max = array[i, j];
            return Max;
        }
        public static void  PrintArray(int [,] array)
        {
            int MasStore = array.GetLength(0);
            for (int i = 0; i < MasStore; i++)
            {
                for (int j = 0; j < MasStore; j++)
                    Console.Write($" {array[i, j]}");
                Console.WriteLine();
            }
            return;
        }
    }
}
