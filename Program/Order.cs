using System;
using System.Collections.Generic;
using NodaMoney;

namespace Program
{
    class Order
    {
        private TaxService TaxSrvc { get; set; }
        public string OrderNunber { get; set; }
        private List<OrderEntry> OrderItems = new List<OrderEntry>();
        
        public Order(TaxService taxSvc, string orderNumber)
        {
            TaxSrvc = taxSvc;
            OrderNunber = orderNumber;
        }

        public void addItem(Product product, int qty)
        {
            Money totalTaxes = new Money(0.00, TaxSrvc.CurrencyCode);
            OrderEntry item = new OrderEntry(product, qty, totalTaxes);
            totalTaxes = TaxSrvc.getAllTaxes(item);
            item.TotalTaxes = totalTaxes;
            
            OrderItems.Add(item);
        }

        public void printOrder()
        {
            Money TotalTaxes = new Money(0.00, TaxSrvc.CurrencyCode);
            Money TotalOrder = new Money(0.00, TaxSrvc.CurrencyCode);

            Console.WriteLine("Receipt " + OrderNunber);
            
            foreach (OrderEntry item in OrderItems)
            {
                TotalTaxes = TotalTaxes + item.TotalTaxes;
                TotalOrder = TotalOrder + (item.Product.Price * item.Qty) + item.TotalTaxes;
                Console.WriteLine(item.Qty + " " + item.Product.Name + ": " + ((item.Product.Price * item.Qty) + item.TotalTaxes));
            }

            Console.WriteLine("Sales Taxes: " + TotalTaxes);
            Console.WriteLine("Total:" + TotalOrder);
            Console.WriteLine("");
            
        }

    }
}
