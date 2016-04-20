namespace Program
{
    class ProductCategory
    {
        public string ProductType { get; private set; }
        public bool Taxable { get; private set; }

        public ProductCategory(string productType, bool taxable)
        {
            ProductType = productType;
            Taxable = taxable;
        }
        
    }
}
