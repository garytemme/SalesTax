using System;

namespace Program
{
    class TaxApplicableSalesTax : ITaxApplicable
    {
        public bool isApplicable()
        {
            throw new NotImplementedException();
        }

        public bool isApplicable(OrderEntry item)
        {
           return  (item.Product.Category.Taxable == true) ? true : false;
        }
    }
}
