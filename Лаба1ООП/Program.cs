using System;

class Program
{

    static double CubeRoot(double x)
    {
        if (x >= 0)
            return Math.Pow(x, 1.0 / 3.0);
        else
            return -Math.Pow(-x, 1.0 / 3.0);
    }

    static void Main()
    {
        Console.WriteLine("ЗАДАЧА 1");

        Console.Write("Введите n: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите m: ");
        int m = Convert.ToInt32(Console.ReadLine());


        int n1 = n;
        int m1 = m;
        int result1 = n1++ * m1;

        Console.WriteLine("\n1) n++ * m");
        Console.WriteLine($"Результат: {result1}");
        Console.WriteLine($"После вычисления n = {n1}");


        int n2 = n;
        int m2 = m;
        bool result2 = n2++ < m2;

        Console.WriteLine("\n2) n++ < m");
        Console.WriteLine($"Результат: {result2}");
        Console.WriteLine($"После вычисления n = {n2}");


        int n3 = n;
        int m3 = m;
        bool result3 = --m3 > n3;

        Console.WriteLine("\n3) --m > n");
        Console.WriteLine($"Результат: {result3}");
        Console.WriteLine($"После вычисления m = {m3}");


        Console.Write("\nВведите x: ");
        double x = Convert.ToDouble(Console.ReadLine());

        double underRoot = x - x * x + x * x * x * x * x;
        double result4 = CubeRoot(underRoot);

        Console.WriteLine("\n4) ∛(x - x² + x⁵)");
        Console.WriteLine($"Подкоренное выражение = {underRoot}");
        Console.WriteLine($"Результат = {result4:F6}");



        Console.WriteLine("\n\nЗАДАЧА 2");
        Console.WriteLine("Область — круг радиуса 1 с центром в начале координат");

        Console.Write("Введите X1: ");
        double x1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите Y1: ");
        double y1 = Convert.ToDouble(Console.ReadLine());

        bool belongs = x1 * x1 + y1 * y1 <= 1;

        Console.WriteLine($"Точка ({x1}; {y1}) принадлежит области: {belongs}");


        Console.WriteLine("\n\nЗАДАЧА 3");

        float af = 1000f;
        float bf = 0.0001f;

        float numeratorF =
            (af - bf) * (af - bf) * (af - bf) - af * af * af;

        float denominatorF =
            3 * af * bf * bf - bf * bf * bf - 3 * af * af * bf;

        float resultFloat = numeratorF / denominatorF;


        double ad = 1000.0;
        double bd = 0.0001;

        double numeratorD =
            (ad - bd) * (ad - bd) * (ad - bd) - ad * ad * ad;

        double denominatorD =
            3 * ad * bd * bd - bd * bd * bd - 3 * ad * ad * bd;

        double resultDouble = numeratorD / denominatorD;

        Console.WriteLine("\nТип float:");
        Console.WriteLine($"Числитель = {numeratorF}");
        Console.WriteLine($"Знаменатель = {denominatorF}");
        Console.WriteLine($"Результат = {resultFloat}");

        Console.WriteLine("\nТип double:");
        Console.WriteLine($"Числитель = {numeratorD}");
        Console.WriteLine($"Знаменатель = {denominatorD}");
        Console.WriteLine($"Результат = {resultDouble}");
    }
}
