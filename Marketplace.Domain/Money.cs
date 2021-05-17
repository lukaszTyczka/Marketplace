using Marketplace.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Marketplace.Domain
{
    public class Money : Value<Money>
    {
        private const string DefaultCurrency = "EUR";
        public static Money FromDecimal(decimal amount, string currency = DefaultCurrency) => new Money(amount, currency);
        public static Money FromString(string amount, string currency = DefaultCurrency) => new Money(decimal.Parse(amount), currency);
        public decimal Amount { get; }
        public string CurrencyCode { get; }
        protected Money(decimal amount, string currencyCode = "EUR")
        {
            if (decimal.Round(amount, 2) != amount)
                throw new ArgumentOutOfRangeException(nameof(amount), "amount cannot have more tha two decimals");
            Amount = amount;
            CurrencyCode = currencyCode;
        }
        public Money Add(Money summand)
        {
            if (CurrencyCode != summand.CurrencyCode)
                throw new CurrencyMismatchException("Cannot sum amount with different currencies");
            return new Money(Amount + summand.Amount);
        }

        public Money Substract(Money subtrahend)
        {
            if (CurrencyCode != subtrahend.CurrencyCode)
                throw new CurrencyMismatchException("Cannot substract amount with different currencies");
            return new Money(Amount - subtrahend.Amount);
        }

        public static Money operator +(Money summand1, Money summand2) => summand1.Add(summand2);
        public static Money operator -(Money minuend, Money subtrahend) => minuend.Substract(subtrahend);
    }

    public class CurrencyMismatchException : Exception
    {
        public CurrencyMismatchException(string message) : base(message)
        {
        }
    }
}
