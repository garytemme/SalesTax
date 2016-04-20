using System.Collections.Generic;
using NodaMoney;
using TaxCalculatorAssy;

namespace Program
{
    class TaxService
    {

        private TaxCalculatorRoundUpFiveHundths TaxCalculator { get; set; }
        public string CurrencyCode { get; set; }
        private List<TaxMethod> TaxMethods { get; set; }

        public TaxService(TaxCalculatorRoundUpFiveHundths taxCalculator, string currencyCode, List<TaxMethod> taxMethods )
        {
            TaxCalculator   = taxCalculator;
            CurrencyCode    = currencyCode;
            TaxMethods      = taxMethods;
        }

        public Money getAllTaxes(OrderEntry item)
        {
            Money totalTax = item.TotalTaxes; 

            foreach(TaxMethod taxMethod in TaxMethods)
            {
                if (taxMethod.TaxApplicableCheck.isApplicable(item))
                {
                    
                    totalTax = totalTax + (TaxCalculator.calculateTax((item.Product.Price * item.Qty), taxMethod.TaxRatePrcnt));
                }
            }
           
            return totalTax;
        }
    }
}
