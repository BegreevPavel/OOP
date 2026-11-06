using System;

namespace OrganizationLibrary
{
    public class ShipbuildingCompany : Organization
    {
        private int shipsBuilt;
        private double totalDisplacement;

        // Свойство: количество построенных судов
        public int ShipsBuilt
        {
            get { return shipsBuilt; }
            set
            {
                if (value >= 0)
                    shipsBuilt = value;
                else
                    shipsBuilt = 0;
            }
        }

        // Свойство: суммарное водоизмещение
        public double TotalDisplacement
        {
            get { return totalDisplacement; }
            set
            {
                if (value >= 0 && !double.IsNaN(value)
                    && !double.IsInfinity(value))
                    totalDisplacement = value;
                else
                    totalDisplacement = 0;
            }
        }

        // Конструктор без параметров
        public ShipbuildingCompany() : base()
        {
            ShipsBuilt = 0;
            TotalDisplacement = 0;
        }

        // Конструктор с параметрами
        public ShipbuildingCompany(
            string name,
            string city,
            int foundationYear,
            int employeeCount,
            int shipsBuilt,
            double totalDisplacement)
            : base(name, city, foundationYear, employeeCount)
        {
            ShipsBuilt = shipsBuilt;
            TotalDisplacement = totalDisplacement;
        }

        // Конструктор копирования
        public ShipbuildingCompany(ShipbuildingCompany other)
            : base(other)
        {
            ShipsBuilt = other.ShipsBuilt;
            TotalDisplacement = other.TotalDisplacement;
        }

        // Переопределение Show()
        public override void Show()
        {
            Console.WriteLine("Тип: Судостроительная компания");

            base.Show();

            Console.WriteLine($"Количество построенных судов: {ShipsBuilt}");
            Console.WriteLine($"Суммарное водоизмещение: {TotalDisplacement:F2} тонн");
        }

        // Переопределение Init()
        public override void Init()
        {
            base.Init();

            Console.Write("Количество построенных судов: ");

            if (int.TryParse(Console.ReadLine(), out int ships))
                ShipsBuilt = ships;
            else
                ShipsBuilt = 0;

            Console.Write("Суммарное водоизмещение (тонн): ");

            if (double.TryParse(Console.ReadLine(), out double displacement))
                TotalDisplacement = displacement;
            else
                TotalDisplacement = 0;
        }

        // Переопределение RandomInit()
        public override void RandomInit()
        {
            base.RandomInit();

            Random random = Random.Shared;

            ShipsBuilt = random.Next(1, 101);
            TotalDisplacement = random.Next(1000, 100001);
        }

        // Сравнение объектов
        public override bool Equals(object? obj)
        {
            if (obj is not ShipbuildingCompany other)
                return false;

            return base.Equals(other)
                && ShipsBuilt == other.ShipsBuilt
                && TotalDisplacement == other.TotalDisplacement;
        }

        // Получение хеш-кода
        public override int GetHashCode()
        {
            return HashCode.Combine(
                base.GetHashCode(),
                ShipsBuilt,
                TotalDisplacement
            );
        }
    }
}
