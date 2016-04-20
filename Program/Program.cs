
using System;
using System.Collections.Generic;
using NodaMoney;
using TaxCalculatorAssy;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OpenStandardOutput();

            //string currancy = args[0]; // pass in local currancy
            string currancyCode = "USD";
            decimal salesTaxRate = .10m;
            decimal importTaxRate = .05m;

            // tax calculation
            TaxCalculatorRoundUpFiveHundths TaxCalc = new TaxCalculatorRoundUpFiveHundths(currancyCode);
            TaxApplicableSalesTax salesTaxApplicableCheck = new TaxApplicableSalesTax();
            TaxApplicableImportDuty importTaxApplicableCheck = new TaxApplicableImportDuty();
            List<TaxMethod> TaxMethods = new List<TaxMethod>();
            TaxMethod SalesTax = new TaxMethod("Sales Tax", salesTaxRate, salesTaxApplicableCheck);
            TaxMethod ImportTax = new TaxMethod("Import Duty Tax", importTaxRate, importTaxApplicableCheck);
            TaxMethods.Add(SalesTax);
            TaxMethods.Add(ImportTax);
            TaxService TaxSvc = new TaxService(TaxCalc, currancyCode, TaxMethods);

            // product categories
            ProductCategory Book = new ProductCategory("Book", false);
            ProductCategory Food = new ProductCategory("Food", false);
            ProductCategory Medical = new ProductCategory("Medical", false);
            ProductCategory General = new ProductCategory("General", true);
            
            // inventory
            Product prod1 = new Product("book", new Money(12.49, currancyCode), Book, ProductOrigin.LOCAL);
            Product prod2 = new Product("music CD", new Money(14.99, currancyCode), General, ProductOrigin.LOCAL);
            Product prod3 = new Product("chocolate bar", new Money(0.85, currancyCode), Food, ProductOrigin.LOCAL);

            Product prod4 = new Product("imported box of chocolates", new Money(10.00, currancyCode), Food, ProductOrigin.IMPORT);
            Product prod5 = new Product("imported bottle of perfume", new Money(47.50, currancyCode), General, ProductOrigin.IMPORT);

            Product prod6 = new Product("imported bottle of perfume", new Money(27.99, currancyCode), General, ProductOrigin.IMPORT);
            Product prod7 = new Product("bottle of perfume", new Money(18.99, currancyCode), General, ProductOrigin.LOCAL);
            Product prod8 = new Product("packet of headache pills", new Money(9.75, currancyCode), Medical, ProductOrigin.LOCAL);
            Product prod9 = new Product("imported box of chocolates", new Money(11.25, currancyCode), Food, ProductOrigin.IMPORT);

            Order order1 = new Order(TaxSvc, "1");
            order1.addItem(prod1, 1);
            order1.addItem(prod2, 1);
            order1.addItem(prod3, 1);

            Order order2 = new Order(TaxSvc, "2");
            order2.addItem(prod4, 1);
            order2.addItem(prod5, 1);

            Order order3 = new Order(TaxSvc, "3");
            order3.addItem(prod6, 1);
            order3.addItem(prod7, 1);
            order3.addItem(prod8, 1);
            order3.addItem(prod9, 1);

            order1.printOrder();
            order2.printOrder();
            order3.printOrder();

            Console.Read();

        }

    }
}
