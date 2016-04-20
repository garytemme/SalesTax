namespace Program
{
    class TaxMethod
    {
        public string TaxName { get; private set; }
        public decimal TaxRatePrcnt { get; private set; }
        public ITaxApplicable TaxApplicableCheck { get; private set; }

        public TaxMethod(string taxName, decimal taxRatePrcnt, ITaxApplicable taxApplicableCheck)
        {
            TaxName = taxName;
            TaxRatePrcnt = taxRatePrcnt;
            TaxApplicableCheck = taxApplicableCheck;
        }
    }
}
