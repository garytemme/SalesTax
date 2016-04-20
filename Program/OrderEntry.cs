using NodaMoney;

namespace Program
{
    class OrderEntry
    {
        public Product Product { get; private set; }
        public int Qty { get; set; }
        public Money TotalTaxes { get; set; }
        //public Money TotalPriceWithTax { get;  set; }

        public OrderEntry(Product product, int qty, Money totalTaxes)
        {
            Product = product;
            Qty                 = qty;
            TotalTaxes          = totalTaxes;
            //TotalPriceWithTax   = totalPriceWithTax; //represents product price plus applicable taxes

        }
    }
}
