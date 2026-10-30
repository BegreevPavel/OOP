using System;

public static class Text_Oretations
{
    // Ввод вещественного числа
    public static double ReadDouble(string message)
    {
        double value;

        while (true)
        {
            Console.Write(message);

            string input = Console.ReadLine();

            if (double.TryParse(input, out value))
                return value;

            Console.WriteLine("Ошибка! Введите вещественное число");
        }
    }

    // Ввод целого числа
    public static int ReadInt(string message)
    {
        int value;

        while (true)
        {
            Console.Write(message);

            string input = Console.ReadLine();

            if (int.TryParse(input, out value) && value >= 0)
                return value;

            Console.WriteLine("Ошибка! Введите неотрицательное целое число");
        }
    }


    public static void PrintTitle(string title)
    {
        Console.WriteLine();
        Console.WriteLine(title);
    }

    public static void PrintTriangle(Triangle t)
    {
        Console.WriteLine(t.ToString());
    }
}
