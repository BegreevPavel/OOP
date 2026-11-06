using System;
using System.Linq;
using Xunit;
using OrganizationLibrary;

namespace OrganizationLibrary.Tests
{
    public class OrganizationTests
    {
        // 1. Проверка конструктора Organization
        [Fact]
        public void Organization_Constructor_WorksCorrectly()
        {
            Organization organization = new Organization(
                "Альфа",
                "Пермь",
                2000,
                100
            );

            Assert.Equal("Альфа", organization.Name);
            Assert.Equal("Пермь", organization.City);
            Assert.Equal(2000, organization.FoundationYear);
            Assert.Equal(100, organization.EmployeeCount);
        }

        // 2. Проверка ограничений свойств Organization
        [Fact]
        public void Organization_Properties_ValidateValues()
        {
            Organization organization = new Organization();

            organization.Name = "";
            organization.City = "";
            organization.FoundationYear = 1700;
            organization.EmployeeCount = -10;

            Assert.Equal("Не указано", organization.Name);
            Assert.Equal("Не указан", organization.City);
            Assert.Equal(2000, organization.FoundationYear);
            Assert.Equal(0, organization.EmployeeCount);
        }

        // 3. Проверка свойств страховой компании
        [Fact]
        public void InsuranceCompany_Properties_ValidateValues()
        {
            InsuranceCompany company = new InsuranceCompany();

            company.Region = "";
            company.InsuranceFund = -100;

            Assert.Equal("Не указан", company.Region);
            Assert.Equal(0, company.InsuranceFund);
        }

        // 4. Проверка свойств судостроительной компании
        [Fact]
        public void ShipbuildingCompany_Properties_ValidateValues()
        {
            ShipbuildingCompany company = new ShipbuildingCompany();

            company.ShipsBuilt = -5;
            company.TotalDisplacement = -100;

            Assert.Equal(0, company.ShipsBuilt);
            Assert.Equal(0, company.TotalDisplacement);
        }

        // 5. Проверка свойств завода
        [Fact]
        public void Factory_Properties_ValidateValues()
        {
            Factory factory = new Factory();

            factory.ProductName = "";
            factory.ProductionVolume = -500;

            Assert.Equal("Не указано", factory.ProductName);
            Assert.Equal(0, factory.ProductionVolume);
        }

        // 6. Проверка свойств библиотеки
        [Fact]
        public void Library_Properties_ValidateValues()
        {
            Library library = new Library();

            library.BookCount = -100;
            library.ReaderCount = -50;

            Assert.Equal(0, library.BookCount);
            Assert.Equal(0, library.ReaderCount);
        }

        // 7. Проверка конструктора копирования
        [Fact]
        public void Library_CopyConstructor_CreatesEqualObject()
        {
            Library original = new Library(
                "Городская библиотека",
                "Пермь",
                2000,
                50,
                10000,
                2000
            );

            Library copy = new Library(original);

            Assert.NotSame(original, copy);
            Assert.True(original.Equals(copy));
        }

        // 8. Проверка сравнения разных объектов
        [Fact]
        public void Organization_Equals_ComparesObjects()
        {
            Organization first = new Organization(
                "Альфа", "Пермь", 2000, 100
            );

            Organization second = new Organization(
                "Альфа", "Пермь", 2000, 100
            );

            Organization third = new Organization(
                "Бета", "Москва", 1990, 200
            );

            Assert.True(first.Equals(second));
            Assert.False(first.Equals(third));
        }

        // 9. Проверка случайной инициализации
        [Fact]
        public void RandomInit_CreatesValidObjects()
        {
            Organization organization = new Organization();
            InsuranceCompany insurance = new InsuranceCompany();
            ShipbuildingCompany shipbuilding = new ShipbuildingCompany();
            Factory factory = new Factory();
            Library library = new Library();

            organization.RandomInit();
            insurance.RandomInit();
            shipbuilding.RandomInit();
            factory.RandomInit();
            library.RandomInit();

            Assert.InRange(organization.EmployeeCount, 10, 1000);

            Assert.InRange(insurance.InsuranceFund,
                1000000, 100000000);

            Assert.InRange(shipbuilding.ShipsBuilt, 1, 100);
            Assert.InRange(shipbuilding.TotalDisplacement,
                1000, 100000);

            Assert.InRange(factory.ProductionVolume,
                1000, 100000);

            Assert.InRange(library.BookCount,
                1000, 100000);

            Assert.InRange(library.ReaderCount,
                100, 10000);
        }

        // 10. Проверка динамической идентификации типов
        [Fact]
        public void TypeIdentification_DetectsCorrectTypes()
        {
            Organization[] organizations =
            {
                new Organization(),
                new InsuranceCompany(),
                new ShipbuildingCompany(),
                new Factory(),
                new Library()
            };

            int libraryCount = organizations.Count(
                organization => organization is Library
            );

            int insuranceCount = organizations.Count(
                organization =>
                    organization as InsuranceCompany != null
            );

            int factoryCount = organizations.Count(
                organization =>
                    organization.GetType() == typeof(Factory)
            );

            Assert.Equal(1, libraryCount);
            Assert.Equal(1, insuranceCount);
            Assert.Equal(1, factoryCount);
        }
    }
}
