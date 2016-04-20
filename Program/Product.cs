using NodaMoney;

namespace Program
{
    class Product
    {
        public string Name { get;  private set; }
        public Money Price { get;  private set; }
        public ProductCategory Category { get; set; }
        public ProductOrigin Origin { get; private set; }

        public Product(string name, Money price, ProductCategory productCategory, ProductOrigin origin)
        {
            Name        = name;
            Price       = price;
            Category    = productCategory;
            Origin      = origin;
        }

        public bool isTaxable()
        {
            return Category.Taxable;
        }
    }
}
