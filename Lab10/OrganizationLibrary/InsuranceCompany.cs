using System;

namespace OrganizationLibrary
{
    public class InsuranceCompany : Organization
    {
        private string region;
        private double insuranceFund;

        // Свойство: регион деятельности
        public string Region
        {
            get { return region; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    region = value;
                else
                    region = "Не указан";
            }
        }

        // Свойство: страховой фонд
        public double InsuranceFund
        {
            get { return insuranceFund; }
            set
            {
                if (value >= 0 && !double.IsNaN(value)
                    && !double.IsInfinity(value))
                    insuranceFund = value;
                else
                    insuranceFund = 0;
            }
        }

        // Конструктор без параметров
        public InsuranceCompany() : base()
        {
            Region = "Не указан";
            InsuranceFund = 0;
        }

        // Конструктор с параметрами
        public InsuranceCompany(
            string name,
            string city,
            int foundationYear,
            int employeeCount,
            string region,
            double insuranceFund)
            : base(name, city, foundationYear, employeeCount)
        {
            Region = region;
            InsuranceFund = insuranceFund;
        }

        // Конструктор копирования
        public InsuranceCompany(InsuranceCompany other)
            : base(other)
        {
            Region = other.Region;
            InsuranceFund = other.InsuranceFund;
        }

        // Обычный невиртуальный метод
        public void ShowNonVirtual()
        {
            Console.WriteLine($"Страховая компания: {Name}");
        }

        // Переопределение метода Show()
        public override void Show()
        {
            Console.WriteLine("Тип: Страховая компания");

            base.Show();

            Console.WriteLine($"Регион: {Region}");
            Console.WriteLine($"Страховой фонд: {InsuranceFund:F2} руб.");
        }

        // Переопределение метода Init()
        public override void Init()
        {
            base.Init();

            Console.Write("Регион деятельности: ");
            Region = Console.ReadLine() ?? "";

            Console.Write("Страховой фонд: ");

            if (double.TryParse(Console.ReadLine(), out double fund))
                InsuranceFund = fund;
            else
                InsuranceFund = 0;
        }

        // Переопределение метода RandomInit()
        public override void RandomInit()
        {
            base.RandomInit();

            string[] regions =
            {
                "Пермский край",
                "Московская область",
                "Республика Татарстан",
                "Свердловская область",
                "Ленинградская область"
            };

            Random random = Random.Shared;

            Region = regions[random.Next(regions.Length)];

            InsuranceFund = random.Next(1000000, 100000001);
        }

        // Сравнение объектов
        public override bool Equals(object? obj)
        {
            if (obj is not InsuranceCompany other)
                return false;

            return base.Equals(other)
                && Region == other.Region
                && InsuranceFund == other.InsuranceFund;
        }

        // Хеш-код
        public override int GetHashCode()
        {
            return HashCode.Combine(
                base.GetHashCode(),
                Region,
                InsuranceFund
            );
        }
    }
}
