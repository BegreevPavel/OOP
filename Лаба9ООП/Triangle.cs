using System;

public class Triangle
{
    private double a;
    private double b;
    private double c;

    private static int objectCount = 0;

    public double A
    {
        get { return a; }
        set { a = value; }
    }

    public double B
    {
        get { return b; }
        set { b = value; }
    }

    public double C
    {
        get { return c; }
        set { c = value; }
    }

    // Количество созданных объектов
    public static int ObjectCount
    {
        get { return objectCount; }
    }

    public Triangle()
    {
        A = 1;
        B = 1;
        C = 1;

        objectCount++;
    }

    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;

        objectCount++;
    }

    // Проверка существования треугольника
    public bool IsValid()
    {
        return A > 0 && B > 0 && C > 0 && A + B > C && A + C > B && B + C > A;
    }

    // Вычисление площади (метод класса)
    public double CalculateArea()
    {
        if (!IsValid())
            return -1;

        double p = (A + B + C) / 2.0;

        return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }

    // Статический метод вычисления площади
    public static double CalculateArea(Triangle t)
    {
        if (t == null)
            return -1;

        return t.CalculateArea();
    }

    // Вывод информации о треугольнике
    public override string ToString()
    {
        return $"Стороны: A = {A}, B = {B}, C = {C}; " +
               $"Площадь: {CalculateArea():F2}; " +
               $"Существует: {(IsValid() ? "Да" : "Нет")}";
    }

    public static Triangle operator ++(Triangle t)
    {
        return new Triangle(t.A + 1, t.B + 1, t.C + 1);
    }

    public static Triangle operator --(Triangle t)
    {
        return new Triangle(t.A - 1, t.B - 1, t.C - 1);
    }

    // Явное преобразование Triangle в double
    public static explicit operator double(Triangle t)
    {
        return t.CalculateArea();
    }

    // Неявное преобразование Triangle в bool
    public static implicit operator bool(Triangle t)
    {
        return t != null && t.IsValid();
    }

    public static bool operator <=(Triangle t1, Triangle t2)
    {
        return t1.CalculateArea() <= t2.CalculateArea();
    }

    public static bool operator >=(Triangle t1, Triangle t2)
    {
        return t1.CalculateArea() >= t2.CalculateArea();
    }
}





