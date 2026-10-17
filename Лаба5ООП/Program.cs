using System;
using System.Net;


class Program
{
    static void Main()
    {
        int choice;

        do
        {
            Console.WriteLine("1. Работа с двумерным массивом");
            Console.WriteLine("2. Работа с рваным массивом");
            Console.WriteLine("3. Работа со строкой");
            Console.WriteLine("0. Выход");

            choice = ReadInt("Выберите пункт меню: ", 0, 3);

            switch (choice)
            {
                case 1:
                    MatrixTasks.CreateMatrix();
                    break;

                case 2:
                    ArrayTasks.CreateArray();
                    break;

                case 3:
                    StringTasks.CreateText();
                    break;

                case 0:
                    Console.WriteLine("Программа завершена.");
                    break;
            }

        } while (choice != 0);
    }

     // Перегрузка метода. Ввод чисел без ограничения диапазона
    public static int ReadInt(string message)
    {
        int num;
        bool correct;

        do
        {
            Console.Write(message);
            string input = Console.ReadLine() ?? " ";

            correct = int.TryParse(input, out num);

            if (!correct)
            {
                Console.WriteLine("Ошибка! Введите целое число");
            }
        }
        while (! correct);

        return num;
    }

    // Перегрузка метода. Ввод числа с ограниченным диапазоном
    public static int ReadInt(string message, int min, int max)
    {
        int num;
        bool correct;

        do
        {
            Console.Write(message);
            string input = Console.ReadLine() ?? "";

            correct = int.TryParse(input, out num);

            if (!correct || num < min || num > max)
            {
                Console.WriteLine($"Ошибка! Введите целое число от {min} до {max}");
                correct = false;
            }
        } 
        while (! correct);

        return num;
    }
}
