using System;

namespace OrganizationLibrary
{
    public class Library : Organization
    {
        private int bookCount;
        private int readerCount;

        // Свойство: количество книг
        public int BookCount
        {
            get { return bookCount; }
            set
            {
                if (value >= 0)
                    bookCount = value;
                else
                    bookCount = 0;
            }
        }

        // Свойство: количество читателей
        public int ReaderCount
        {
            get { return readerCount; }
            set
            {
                if (value >= 0)
                    readerCount = value;
                else
                    readerCount = 0;
            }
        }

        // Конструктор без параметров
        public Library() : base()
        {
            BookCount = 0;
            ReaderCount = 0;
        }

        // Конструктор с параметрами
        public Library(
            string name,
            string city,
            int foundationYear,
            int employeeCount,
            int bookCount,
            int readerCount)
            : base(name, city, foundationYear, employeeCount)
        {
            BookCount = bookCount;
            ReaderCount = readerCount;
        }

        // Конструктор копирования
        public Library(Library other) : base(other)
        {
            BookCount = other.BookCount;
            ReaderCount = other.ReaderCount;
        }

        // Обычный невиртуальный метод
        public void ShowNonVirtual()
        {
            Console.WriteLine($"Библиотека: {Name}");
        }

        // Переопределение Show()
        public override void Show()
        {
            Console.WriteLine("Тип: Библиотека");

            base.Show();

            Console.WriteLine($"Количество книг: {BookCount}");
            Console.WriteLine($"Количество читателей: {ReaderCount}");
        }

        // Переопределение Init()
        public override void Init()
        {
            base.Init();

            Console.Write("Количество книг: ");

            if (int.TryParse(Console.ReadLine(), out int books))
                BookCount = books;
            else
                BookCount = 0;

            Console.Write("Количество читателей: ");

            if (int.TryParse(Console.ReadLine(), out int readers))
                ReaderCount = readers;
            else
                ReaderCount = 0;
        }

        // Переопределение RandomInit()
        public override void RandomInit()
        {
            base.RandomInit();

            Random random = Random.Shared;

            BookCount = random.Next(1000, 100001);
            ReaderCount = random.Next(100, 10001);
        }

        // Сравнение объектов
        public override bool Equals(object? obj)
        {
            if (obj is not Library other)
                return false;

            return base.Equals(other)
                && BookCount == other.BookCount
                && ReaderCount == other.ReaderCount;
        }

        // Получение хеш-кода
        public override int GetHashCode()
        {
            return HashCode.Combine(
                base.GetHashCode(),
                BookCount,
                ReaderCount
            );
        }
    }
}
