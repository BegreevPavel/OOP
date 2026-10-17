using System;


class ArrayTasks
{
    public static void CreateArray()
    {
        int strings = Program.ReadInt("Введите количество строк (1–100): ", 1, 100);

        int[][] array = new int[strings][];

        Console.WriteLine("\n1. Заполнить вручную");
        Console.WriteLine("2. Заполнить случайными числами");

        int choice = Program.ReadInt("Ваш выбор: ", 1, 2);

        Random random = new Random();

        for (int i = 0; i < strings; i++)
        {
            int length = Program.ReadInt($"Введите количество элементов в строке {i + 1} (1–100): ", 1, 100);

            array[i] = new int[length];

            for (int j = 0; j < length; j++)
            {
                if (choice == 1)
                {
                    array[i][j] = Program.ReadInt($"Введите элемент [{i}][{j}]: ");
                }
                else
                {
                    array[i][j] = random.Next(0, 100);
                }
            }
        }

        Console.WriteLine("\nИсходный рваный массив:");
        PrintArray(array);

        int k = Program.ReadInt("\nВведите число K: ");

        int[][] result = RemoveRows(array, k);

        Console.WriteLine($"\nМассив после удаления строк с числом {k}: ");

        if (result.Length == 0)
        {
            Console.WriteLine("Все строки удалены. Массив пуст");
        }
        else
        {
            PrintArray(result);
        }
    }

    static int[][] RemoveRows(int[][] array, int k)
    {
        int count = 0;

        // Считаем строки, в которых нет числа K.
        for (int i = 0; i < array.Length; i++)
        {
            bool containsK = false;

            for (int j = 0; j < array[i].Length; j++)
            {
                if (array[i][j] == k)
                {
                    containsK = true;
                    break;
                }
            }

            if (!containsK)
            {
                count++;
            }
        }

        // Создаём массив нужного размера.
        int[][] result = new int[count][];

        int index = 0;

        // Копируем строки, в которых нет числа K.
        for (int i = 0; i < array.Length; i++)
        {
            bool containsK = false;

            for (int j = 0; j < array[i].Length; j++)
            {
                if (array[i][j] == k)
                {
                    containsK = true;
                    break;
                }
            }

            if (!containsK)
            {
                result[index] = new int[array[i].Length];

                for (int j = 0; j < array[i].Length; j++)
                {
                    result[index][j] = array[i][j];
                }

                index++;
            }
        }

        return result;
    }

    static void PrintArray(int[][] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                Console.Write(array[i][j] + " ");
            }

            Console.WriteLine();
        }
    }
}
    