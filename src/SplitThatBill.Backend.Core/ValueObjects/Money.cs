using System;
namespace SplitThatBill.Backend.Core.ValueObjects
{
    public class Money
    {
        public Money(decimal amount)
        {
            Amount = RoundToTwoDecimals(amount);
        }

        public Money(decimal amount, string currency)
        {
            Amount = RoundToTwoDecimals(amount);
            Currency = currency;
        }

        public decimal Amount { get; }
        public string Currency { get; } = "MYR";

        public override string ToString()
        {
            var roundedAmount = RoundToTwoDecimals(Amount);
            return $"{Currency} {roundedAmount.ToString("G")}";
        }

        private decimal RoundToTwoDecimals(decimal amount)
        {
            return Math.Round(amount, 2, MidpointRounding.AwayFromZero);
        }
    }
}
