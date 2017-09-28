using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HarryPotterKata.Tests
{
    public class HarryPotterBooksTests
    {
        private HarryPotterBooksCalculator _booksCalculator;

        [SetUp]
        public void Setup()
        {
            _booksCalculator = new HarryPotterBooksCalculator();
        }

        [Test]
        public void Calculate_1_book_costs_8_dollars()
        {
            CheckPrice(8, new[] { 1 });
        }

        [Test]
        public void Calculate_2_equal_book_costs_16_dollars()
        {
            CheckPrice(16, new[] { 1, 1 });
        }

        [Test]
        public void Calculate_5_equal_book_costs_40_dollars()
        {
            CheckPrice(40, new[] { 1, 1, 1, 1, 1 });
        }

        [Test]
        public void Calculate_2_different_book_costs_15_2_dollars()
        {
            CheckPrice(15.2, new[] { 1, 2 });
        }

        [Test]
        public void Calculate_3_different_book_costs_21_6_dollars()
        {
            CheckPrice(21.6, new[] { 1, 2, 3 });
        }

        private void CheckPrice(double expectedPrice, IEnumerable<int> books)
        {
            var result = _booksCalculator.Calculate(books);

            Assert.AreEqual(expectedPrice, result);
        }
    }

    public class HarryPotterBooksCalculator
    {
        private const int BookDefaultCost = 8;

        public double Calculate(IEnumerable<int> books)
        {
            var priceWithoutDiscount = books.Count() * BookDefaultCost;

            if (books.Distinct().Count() == books.Count())
            {
                return priceWithoutDiscount - priceWithoutDiscount * 0.05;
            }
            return books.Count() * BookDefaultCost;
        }
    }
}