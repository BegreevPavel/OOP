using System;
using OrganizationLibrary;

class Program
{
    // Запрос 1 - количество библиотек в указанном городе
    static int CountLibrariesInCity(
        Organization[] organizations, string city)
    {
        int count = 0;

        foreach (Organization organization in organizations)
        {
            if (organization is Library library)
            {
                if (string.Equals(
                    library.City, city,
                    StringComparison.OrdinalIgnoreCase))
                {
                    count++;
                }
            }
        }

        return count;
    }

    // Запрос 2 - суммарный страховой фонд компаний указанного региона
    static double SumInsuranceFundByRegion(
        Organization[] organizations, string region)
    {
        double sum = 0;

        foreach (Organization organization in organizations)
        {
            InsuranceCompany? company =
                organization as InsuranceCompany;

            if (company != null)
            {
                if (string.Equals(
                    company.Region, region,
                    StringComparison.OrdinalIgnoreCase))
                {
                    sum += company.InsuranceFund;
                }
            }
        }

        return sum;
    }

    // Запрос 3 - количество книг во всех библиотеках указанного города.
    static int CountBooksInCity(
        Organization[] organizations, string city)
    {
        int sum = 0;

        foreach (Organization organization in organizations)
        {
            if (organization.GetType() == typeof(Library))
            {
                Library library = (Library)organization;

                if (string.Equals(
                    library.City, city,
                    StringComparison.OrdinalIgnoreCase))
                {
                    sum += library.BookCount;
                }
            }
        }

        return sum;
    }

    static void Main()
    {
        Organization[] organizations = new Organization[25];

        // Создание пяти объектов каждого типа
        for (int i = 0; i < organizations.Length; i++)
        {
            switch (i % 5)
            {
                case 0:
                    organizations[i] = new Organization();
                    break;

                case 1:
                    organizations[i] = new InsuranceCompany();
                    break;

                case 2:
                    organizations[i] = new ShipbuildingCompany();
                    break;

                case 3:
                    organizations[i] = new Factory();
                    break;

                case 4:
                    organizations[i] = new Library();
                    break;
            }

            organizations[i].RandomInit();
        }

        // Просмотр всех объектов
        Console.WriteLine("\nСПИСОК ВСЕХ ОРГАНИЗАЦИЙ\n");


        foreach (Organization organization in organizations)
        {
            organization.Show();
            Console.WriteLine("------------------------------");
        }

        // Запрос 1
        Console.WriteLine("\nЗАПРОС 1: КОЛИЧЕСТВО БИБЛИОТЕК\n");

        Console.Write("Введите город: ");
        string city1 = Console.ReadLine() ?? "";

        int libraryCount =
            CountLibrariesInCity(organizations, city1);

        Console.WriteLine(
            $"Количество библиотек в городе {city1}: {libraryCount}");

        // Запрос 2
        Console.WriteLine("\nЗАПРОС 2: СТРАХОВОЙ ФОНД\n");

        Console.Write("Введите регион: ");
        string region = Console.ReadLine() ?? "";

        double insuranceSum =
            SumInsuranceFundByRegion(organizations, region);

        Console.WriteLine(
            $"Суммарный страховой фонд региона {region}: " +
            $"{insuranceSum:F2} руб.");

        // Запрос 3
        Console.WriteLine("\nЗАПРОС 3: КОЛИЧЕСТВО КНИГ\n");

        Console.Write("Введите город: ");
        string city2 = Console.ReadLine() ?? "";

        int bookCount =
            CountBooksInCity(organizations, city2);

        Console.WriteLine(
            $"Количество книг в библиотеках города {city2}: {bookCount}");

        Console.WriteLine("\nРабота программы завершена");
    }
}
