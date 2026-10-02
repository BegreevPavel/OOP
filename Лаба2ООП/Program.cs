using System;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;

class Program
{
    // Вычисление n-го члена ряда
    static double Term(double x, int n)
    {
        return Math.Pow(-1, n + 1) * Math.Pow(x, 2 * n) / (2 * n * (2 * n - 1));
    }

    // Сумма ряда для заданного n
    static double SumByN(double x, int n)
    {
        double sum = 0;

        for(int z = 1; z <= n; z++)
        {
            sum += Term(x, z);
        }
        return sum;
    }

    // Сумма ряда с заданной точностью
    static double SumByEps(double x, double eps)
    {
        double sum = 0;
        int n = 0;

        while (true)
        {
            n++;

            double term = Term(x, n);
            sum += term;

            if (Math.Abs(term) < eps)
            {
                break;
            }
        }
        return sum;
    }

    // Точное значение функции
    static double ExactFunction(double x)
    {
        return x * Math.Atan(x) - 0.5 * Math.Log(1 + x * x);
    }

    static void Main()
    {
        double a = 0.1;
        double b = 0.8;

        int k = 10;
        int n = 10;

        double eps = 0.0001;

        double h = (b - a) / k;

        Console.WriteLine("Функция:");
        Console.WriteLine("y = X * arctg(X) - 0.5 * ln(1 + xˆ2))");
        Console.WriteLine();

        Console.WriteLine("{0,8:F4} {1,15:F10} {2,15:F10} {3,15:F10}", "X", "SN", "SE", "Y");

        for (int i = 0; i <= k; i++)
        {
            double x = a + i * h;

            // значение суммы для заданного n
            double SN = SumByN(x, n);

            // значение суммы для заданной точности
            double SE = SumByEps(x, eps);

            // точное значение функции
            double Y = ExactFunction(x);

            Console.WriteLine("{0,8:F4} {1,15:F10} {2,15:F10} {3,15:F10}", x, SN, SE, Y);
        }

        Console.WriteLine();
        Console.WriteLine("n = " + n);
        Console.WriteLine("eps = " + eps);  
        Console.WriteLine("Шаг = " + n);      
    }
}