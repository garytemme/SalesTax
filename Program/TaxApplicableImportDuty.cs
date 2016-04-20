using System;

namespace Program
{
    class TaxApplicableImportDuty : ITaxApplicable
    {
        public bool isApplicable()
        {
            throw new NotImplementedException();
        }

        public bool isApplicable(OrderEntry item)
        {
            return (item.Product.Origin.ToString() == ("IMPORT")) ?  true :  false;
        }
    }
}
