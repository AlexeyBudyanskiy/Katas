using System.Collections.Generic;
using System.Linq;

namespace HarryPotterKata.Tests
{
    public class HarryPotterBooksCalculator
    {
        private const int BookDefaultCost = 8;

        private readonly Dictionary<int, double> _discountDictionary = new Dictionary<int, double>
        {
            {1, 0}, {2, 0.05}, {3, 0.1}, {4, 0.2}, {5, 0.25}
        };

        public double Calculate(IEnumerable<int> books)
        {
            var basket = books.ToList();
            double totalPriceWithDiscount = 0;

            while (basket.Any())
            {
                var bookSet = basket.Distinct().ToList();

                totalPriceWithDiscount += CalculateBookSetPrice(bookSet);
                RemoveBookSetFromBasket(bookSet, basket);
            }

            return totalPriceWithDiscount;
        }

        private static void RemoveBookSetFromBasket(IList<int> booksSet, IList<int> calculatingBook)
        {
            foreach (var elem in booksSet)
            {
                calculatingBook.Remove(elem);
            }
        }

        private double CalculateBookSetPrice(IList<int> booksSet)
        {
            var priceWithouDiscount = booksSet.Count * BookDefaultCost;
            var priceWithDiscount =  CalculatePriceWithDiscount(priceWithouDiscount, _discountDictionary[booksSet.Count]);

            return priceWithDiscount;
        }

        private double CalculatePriceWithDiscount(double priceWithouDiscount, double discountPercentage)
        {
            return priceWithouDiscount - priceWithouDiscount * discountPercentage;
        }
    }
}