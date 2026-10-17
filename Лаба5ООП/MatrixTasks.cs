using System;
using System.Globalization;

class MatrixTasks
{
    public static void CreateMatrix()
    {
    Random rnd = new Random();
    int strings, columns;

    strings = Program.ReadInt("Введите количество строк (1 - 100)", 1, 100);
    columns = Program.ReadInt("Введите количество столбцов (1 - 100)", 1, 100);

    Console.WriteLine("\n1.Заполнить вручную");
    Console.WriteLine("2.Заполнить случайными числами");

    int choice = Program.ReadInt("Ваш выбор: ", 1, 2);

    int[,] matrix = new int[strings, columns];
    int i, j;
    for (i = 0; i < strings; i++)
        {
            for (j = 0; j < columns; j++)
            {
                if (choice == 1)
                {
                    matrix[i, j] = Program.ReadInt($"Введите элемент [{i}, {j}]: ");
                }
                else
                {
                    matrix[i, j] = rnd.Next(1, 100);
                }
            }
        }

        Console.WriteLine("\nИсходная массив: ");
        PrintMatrix(matrix);

        int[,] result = AddColumn(matrix);

        Console.WriteLine("\nМатрица после добавления столбца: ");
        PrintMatrix(result);
    }

    static int[,] AddColumn(int[,] matrix)
    {
        int strings = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        int[,] result = new int[strings, columns + 1];

        for (int i = 0; i < strings; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[i, j] = matrix[i, j];
            }

            result[i, columns] = Program.ReadInt($"Введите новый элемент для строки {i + 1}: ");
        }

        return result;
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "  ");
            }

            Console.WriteLine();
        }
    }
}