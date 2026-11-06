using System;

namespace OrganizationLibrary
{
    public class Organization
    {
        private string name;
        private string city;
        private int foundationYear;
        private int employeeCount;

        // Свойство: название организации
        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    name = value;
                else
                    name = "Не указано";
            }
        }

        // Свойство: город
        public string City
        {
            get { return city; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    city = value;
                else
                    city = "Не указан";
            }
        }

        // Свойство: год основания
        public int FoundationYear
        {
            get { return foundationYear; }
            set
            {
                if (value >= 1800 && value <= DateTime.Now.Year)
                    foundationYear = value;
                else
                    foundationYear = 2000;
            }
        }

        // Свойство: количество сотрудников
        public int EmployeeCount
        {
            get { return employeeCount; }
            set
            {
                if (value >= 0)
                    employeeCount = value;
                else
                    employeeCount = 0;
            }
        }

        // Конструктор без параметров
        public Organization()
        {
            Name = "Не указано";
            City = "Не указан";
            FoundationYear = 2000;
            EmployeeCount = 0;
        }

        // Конструктор с параметрами
        public Organization(string name, string city,
                            int foundationYear, int employeeCount)
        {
            Name = name;
            City = city;
            FoundationYear = foundationYear;
            EmployeeCount = employeeCount;
        }

        // Конструктор копирования
        public Organization(Organization other)
        {
            Name = other.Name;
            City = other.City;
            FoundationYear = other.FoundationYear;
            EmployeeCount = other.EmployeeCount;
        }

        // Обычный невиртуальный метод
        public void ShowNonVirtual()
        {
            Console.WriteLine($"Организация: {Name}");
        }
        
        // Виртуальный метод отображения информации
        public virtual void Show()
        {
            Console.WriteLine($"Название: {Name}");
            Console.WriteLine($"Город: {City}");
            Console.WriteLine($"Год основания: {FoundationYear}");
            Console.WriteLine($"Количество сотрудников: {EmployeeCount}");
        }

        // Виртуальный метод ввода информации
        public virtual void Init()
        {
            Console.Write("Название организации: ");
            Name = Console.ReadLine() ?? "";

            Console.Write("Город: ");
            City = Console.ReadLine() ?? "";

            Console.Write("Год основания: ");
            if (int.TryParse(Console.ReadLine(), out int year))
                FoundationYear = year;
            else
                FoundationYear = 2000;

            Console.Write("Количество сотрудников: ");
            if (int.TryParse(Console.ReadLine(), out int count))
                EmployeeCount = count;
            else
                EmployeeCount = 0;
        }

        // Виртуальный метод случайной инициализации
        public virtual void RandomInit()
        {
            string[] names =
            {
                "Альфа", "Вектор", "Прогресс",
                "Горизонт", "Импульс"
            };

            string[] cities =
            {
                "Пермь", "Москва", "Казань",
                "Екатеринбург", "Санкт-Петербург"
            };

            Random random = Random.Shared;

            Name = names[random.Next(names.Length)];
            City = cities[random.Next(cities.Length)];
            FoundationYear = random.Next(1950, DateTime.Now.Year + 1);
            EmployeeCount = random.Next(10, 1001);
        }

        // Сравнение объектов
        public override bool Equals(object? obj)
        {
            if (obj is not Organization other)
                return false;

            if (GetType() != other.GetType())
                return false;

            return Name == other.Name
                && City == other.City
                && FoundationYear == other.FoundationYear
                && EmployeeCount == other.EmployeeCount;
        }

        // Получение хеш-кода объекта
        public override int GetHashCode()
        {
            return HashCode.Combine(
                Name, City, FoundationYear, EmployeeCount
            );
        }
    }
}
