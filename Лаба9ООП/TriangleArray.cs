using System;

public class TriangleArray
{
    private Triangle[] arr;

    // Количество созданных массивов
    private static int objectCount = 0;

    public static int ObjectCount
    {
        get { return objectCount; }
    }

    // Размер массива
    public int Length
    {
        get { return arr.Length; }
    }

    public TriangleArray()
    {
        arr = new Triangle[0];
        objectCount++;
    }

    // Конструктор со случайными значениями (создание треугольника)
    public TriangleArray(int size)
    {
        if (size < 0)
            throw new ArgumentException("Размер массива не может быть отрицательным");

        arr = new Triangle[size];

        Random random = new Random();

        for (int i = 0; i < size; i++)
        {
            double a = random.Next(2, 11);
            double b = random.Next(2, 11);

            int min = (int)Math.Abs(a - b) + 1;
            int max = (int)(a + b);

            double c = random.Next(min, max);

            arr[i] = new Triangle(a, b, c);
        }

        objectCount++;
    }

    // Конструктор с заполнением с клавиатуры
    public TriangleArray(int size, bool inputFromKeyboard)
    {
        if (size < 0)
            throw new ArgumentException("Размер массива не может быть отрицательным");

        arr = new Triangle[size];

        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"\nТреугольник №{i + 1}");

            double a = Text_Oretations.ReadDouble("Введите сторону A: ");
            double b = Text_Oretations.ReadDouble("Введите сторону B: ");
            double c = Text_Oretations.ReadDouble("Введите сторону C: ");

            arr[i] = new Triangle(a, b, c);
        }

        objectCount++;
    }

    // Индексатор
    public Triangle this[int index]
    {
        get
        {
            if (index < 0 || index >= arr.Length)
                throw new ArgumentException("Индекс выходит за пределы массива");

            return arr[index];
        }

        set
        {
            if (index < 0 || index >= arr.Length)
                throw new ArgumentException("Индекс выходит за пределы массива");

            arr[index] = value;
        }
    }

    // Просмотр элементов массива
    public void Print()
    {
        if (arr.Length == 0)
        {
            Console.WriteLine("Массив пуст");
            return;
        }

        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine($"Элемент [{i}]: {arr[i]}");
        }
    }
}

