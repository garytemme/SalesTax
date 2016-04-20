using System;
using NodaMoney;

namespace TaxCalculatorAssy
{
    public class TaxCalculatorRoundUpFiveHundths
    {
        private string CurrancyCode { set; get; }

        public TaxCalculatorRoundUpFiveHundths(string currancyCode)
        {
            CurrancyCode = currancyCode;
        }

        public Money calculateTax(Money money, decimal rate)
        {
            decimal tax = roundUpToNearestFiveCents(money.Amount * rate);
            return new Money(tax, CurrancyCode);

        }

        //TODO - GDT - update tests to access private methods, then make this private
        public decimal roundUpToNearestFiveCents(decimal value)
        {
            if ((value * 100) % 5 != 0)
            {
                return Math.Ceiling(value * 20) / 20;
            }
            else return value;
        }
    }
}
