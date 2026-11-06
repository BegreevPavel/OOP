using System;

namespace OrganizationLibrary
{
    public class Factory : Organization
    {
        private string productName;
        private int productionVolume;

        // Свойство: наименование продукции
        public string ProductName
        {
            get { return productName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    productName = value;
                else
                    productName = "Не указано";
            }
        }

        // Свойство: объём производства
        public int ProductionVolume
        {
            get { return productionVolume; }
            set
            {
                if (value >= 0)
                    productionVolume = value;
                else
                    productionVolume = 0;
            }
        }

        // Конструктор без параметров
        public Factory() : base()
        {
            ProductName = "Не указано";
            ProductionVolume = 0;
        }

        // Конструктор с параметрами
        public Factory(
            string name,
            string city,
            int foundationYear,
            int employeeCount,
            string productName,
            int productionVolume)
            : base(name, city, foundationYear, employeeCount)
        {
            ProductName = productName;
            ProductionVolume = productionVolume;
        }

        // Конструктор копирования
        public Factory(Factory other) : base(other)
        {
            ProductName = other.ProductName;
            ProductionVolume = other.ProductionVolume;
        }

        // Обычный невиртуальный метод
        public new void ShowNonVirtual()
        {
            Console.WriteLine($"Завод: {Name}");
        }

        // Переопределение Show()
        public override void Show()
        {
            Console.WriteLine("Тип: Завод");

            base.Show();

            Console.WriteLine($"Выпускаемая продукция: {ProductName}");
            Console.WriteLine($"Объём производства за год: {ProductionVolume}");
        }

        // Переопределение Init()
        public override void Init()
        {
            base.Init();

            Console.Write("Наименование продукции: ");
            ProductName = Console.ReadLine() ?? "";

            Console.Write("Объём производства за год: ");

            if (int.TryParse(Console.ReadLine(), out int volume))
                ProductionVolume = volume;
            else
                ProductionVolume = 0;
        }

        // Переопределение RandomInit()
        public override void RandomInit()
        {
            base.RandomInit();

            string[] products =
            {
                "Автомобили",
                "Металлоконструкции",
                "Электроника",
                "Оборудование",
                "Строительные материалы"
            };

            Random random = Random.Shared;

            ProductName = products[random.Next(products.Length)];
            ProductionVolume = random.Next(1000, 100001);
        }

        // Сравнение объектов
        public override bool Equals(object? obj)
        {
            if (obj is not Factory other)
                return false;

            return base.Equals(other)
                && ProductName == other.ProductName
                && ProductionVolume == other.ProductionVolume;
        }

        // Получение хеш-кода
        public override int GetHashCode()
        {
            return HashCode.Combine(
                base.GetHashCode(),
                ProductName,
                ProductionVolume
            );
        }
    }
}