using System.Collections.Generic;
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
        public void Calculate_1_book_hould_cost_8_dollars()
        {
            CheckPrice(8, new[] { 1 });
        }

        [Test]
        public void Calculate_2_same_books_should_cost_16_dollars()
        {
            CheckPrice(16, new[] { 1, 1 });
        }

        [Test]
        public void Calculate_5_same_book_should_cost_40_dollars()
        {
            CheckPrice(40, new[] { 1, 1, 1, 1, 1 });
        }

        [Test]
        public void Calculate_2_different_book_should_cost_15_point_2_dollars()
        {
            CheckPrice(15.2, new[] { 1, 2 });
        }

        [Test]
        public void Calculate_3_different_book_should_cost_21_point_6_dollars()
        {
            CheckPrice(21.6, new[] { 1, 2, 3 });
        }

        [Test]
        public void Calculate_2_first_book_and_2_second_should_cost_30_point_4_dollars()
        {
            CheckPrice(30.4, new[] { 1, 2, 1, 2 });
        }

        [Test]
        public void Calculate_5_books_should_cost_30_point_4_dollars()
        {
            CheckPrice(36.8, new[] { 1, 2, 1, 2, 3 });
        }

        [Test]
        public void Calculate_10_books_should_cost_66_point_8_dollars()
        {
            CheckPrice(66.8, new[] { 1, 2, 1, 2, 3, 4, 5, 1, 2, 3});
        }

        private void CheckPrice(double expectedPrice, IEnumerable<int> books)
        {
            var result = _booksCalculator.Calculate(books);

            Assert.AreEqual(expectedPrice, result);
        }
    }
}