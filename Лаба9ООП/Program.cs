class Program
{
    // Поиск номера элемента с минимальной площадью
    public static int FindMinAreaIndex(TriangleArray array)
    {
        if (array.Length == 0)
            return -1;

        int minIndex = -1;
        double minArea = double.MaxValue;

        for (int i = 0; i < array.Length; i++)
        {
            Triangle t = array[i];

            // Проверка существования треугольника
            if ((bool)t)
            {
                double area = (double)t;

                if (area < minArea)
                {
                    minArea = area;
                    minIndex = i;
                }
            }
        }

        return minIndex;
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // ЧАСТЬ 1

        Text_Oretations.PrintTitle("ЧАСТЬ 1");

        Triangle t1 = new Triangle(3, 4, 5);
        Triangle t2 = new Triangle(5, 5, 6);
        Triangle t3 = new Triangle();

        Console.WriteLine("Созданные треугольники:");

        Text_Oretations.PrintTriangle(t1);
        Text_Oretations.PrintTriangle(t2);
        Text_Oretations.PrintTriangle(t3);

        Console.WriteLine("\nПлощадь через статическую функцию:");

        Console.WriteLine(
            $"Площадь первого треугольника: {Triangle.CalculateArea(t1):F2}");

        Console.WriteLine("\nПлощадь через метод класса:");

        Console.WriteLine(
            $"Площадь второго треугольника: {t2.CalculateArea():F2}");

        Console.WriteLine(
            $"\nКоличество созданных треугольников: {Triangle.ObjectCount}");


        // ЧАСТЬ 2

        Text_Oretations.PrintTitle("ЧАСТЬ 2");

        Triangle t4 = new Triangle(3, 4, 5);

        Console.WriteLine("Исходный треугольник:");
        Console.WriteLine(t4.ToString());

        t4++;

        Console.WriteLine("\nПосле операции ++:");
        Console.WriteLine(t4.ToString());

        t4--;

        Console.WriteLine("\nПосле операции --:");
        Console.WriteLine(t4.ToString());

        // Явное преобразование в double
        double area = (double)t1;

        Console.WriteLine(
            $"\nЯвное преобразование в double: {area:F2}");

        // Неявное преобразование в bool
        bool isTriangle = t1;

        Console.WriteLine(
            $"Неявное преобразование в bool: {isTriangle}");

        // Проверка несуществующего треугольника
        Triangle invalid = new Triangle(1, 2, 5);

        Console.WriteLine("\nНесуществующий треугольник:");
        Console.WriteLine(invalid);

        Console.WriteLine(
            $"Преобразование в double: {(double)invalid}");

        Console.WriteLine(
            $"Преобразование в bool: {(bool)invalid}");

        // Сравнение площадей
        Console.WriteLine("\nСравнение площадей:");

        Console.WriteLine(
            $"t1 <= t2: {t1 <= t2}");

        Console.WriteLine(
            $"t1 >= t2: {t1 >= t2}");

        Console.WriteLine(
            $"\nКоличество созданных треугольников: {Triangle.ObjectCount}");


        // ЧАСТЬ 3

        Text_Oretations.PrintTitle("ЧАСТЬ 3");

        Console.WriteLine("Выберите способ создания массива:");
        Console.WriteLine("1 - Пустой массив");
        Console.WriteLine("2 - Массив со случайными значениями");
        Console.WriteLine("3 - Заполнение с клавиатуры");

        int choice = Text_Oretations.ReadInt("Ваш выбор: ");

        TriangleArray array;

        switch (choice)
        {
            case 1:
                array = new TriangleArray();
                break;

            case 2:
                int randomSize = Text_Oretations.ReadInt("Введите размер массива: ");

                array = new TriangleArray(randomSize);
                break;

            case 3:
                int inputSize = Text_Oretations.ReadInt("Введите размер массива: ");

                array = new TriangleArray(inputSize, true);
                break;

            default:
                Console.WriteLine("Неверный выбор.");
                array = new TriangleArray();
                break;
        }

        Console.WriteLine("\nСодержимое массива:");

        array.Print();

        // Демонстрация индексатора
        if (array.Length > 0)
        {
            Console.WriteLine("\nДемонстрация индексатора:");

            int index = Text_Oretations.ReadInt(
                "Введите индекс элемента: ");

            try
            {
                Console.WriteLine(array[index].ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine("\nПоиск минимальной площади:");

        int minIndex = FindMinAreaIndex(array);

        if (minIndex == -1)
        {
            Console.WriteLine(
                "Нет существующих треугольников.");
        }
        else
        {
            Console.WriteLine(
                $"Номер элемента с минимальной площадью: {minIndex + 1}");

            Console.WriteLine(
                $"Площадь: {array[minIndex].CalculateArea():F2}");
        }


        Console.WriteLine(
            $"\nКоличество созданных массивов: {TriangleArray.ObjectCount}");

        Console.WriteLine(
            $"Количество созданных треугольников: {Triangle.ObjectCount}");

    }
}
