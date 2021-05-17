using Marketplace.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Marketplace.Tests
{
    public class MoneyTest
    {
        [Fact]
        public void Money_objects_with_the_same_amount_should_be_equal()
        {
            var firstAmount = Money.FromDecimal(5);
            var secondAmount = Money.FromDecimal(5);
            Assert.Equal(firstAmount, secondAmount);        
        }

        [Fact]
        public void Sum_of_money_gives_full_amount()
        {
            var coin1 = Money.FromDecimal(1);
            var coin2 = Money.FromDecimal(2);
            var coin3 = Money.FromDecimal(2);
            var banknote = Money.FromDecimal(5);
            Assert.Equal(banknote, coin1 + coin2 + coin3);
        }

        [Fact]
        public void Substract_of_money_gives_properly_amount()
        {
            var banknote1 = Money.FromDecimal(20);
            var banknote2 = Money.FromDecimal(10);
            Assert.Equal(banknote2, banknote1 - banknote2);
        }

        [Fact]
        public void Sum_of_money_different_currency_should_throw_exception()
        {
            var banknot = Money.FromDecimal(10, "PL");
            var banknot2 = Money.FromDecimal(10);

            Assert.Throws<CurrencyMismatchException>(() => banknot + banknot2);
        }

        [Fact]
        public void Substract_of_money_different_currency_should_throw_exception()
        {
            var banknot = Money.FromDecimal(10, "PL");
            var banknot2 = Money.FromDecimal(10);

            Assert.Throws<CurrencyMismatchException>(() => banknot - banknot2);
        }
    }
}
