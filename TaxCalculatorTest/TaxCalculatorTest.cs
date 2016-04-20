using Microsoft.VisualStudio.TestTools.UnitTesting;
using NodaMoney;
using TaxCalculatorAssy;


namespace TaxCalculatorTest
{
    [TestClass]
    public class TaxCalculatorTest
    {
        private static decimal _salesTaxRate = .10m;
        //private static decimal _importTaxRate = .05m;
        private static string _currancy = "USD"; // do initial testing with US Dollars

        TaxCalculatorRoundUpFiveHundths taxCalc = new TaxCalculatorRoundUpFiveHundths(_currancy);

        [TestMethod]
        public void calcSalesTax1()
        {
            var expected = Money.USDollar(1.50m);
            Money actual = taxCalc.calculateTax(14.99m, _salesTaxRate);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void calcSalesTax2()
        {
            var expected = Money.USDollar(1433.50m);
            Money actual = taxCalc.calculateTax(14334.63m, _salesTaxRate);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void calcSalesTax3()
        {
            var expected = Money.USDollar(1433.50m);
            Money actual = taxCalc.calculateTax(14334.60m, _salesTaxRate);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void calcSalesTax4()
        {
            // at midpoint .465, make sure it rounds up
            var expected = Money.USDollar(1433.50m);
            Money actual = taxCalc.calculateTax(14334.65m, _salesTaxRate);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void roundUpToNearestFiveCents1()
        {
            // make sure it rounds up, not down
            var expected = 1.35m;
            var testValue = 1.31m;
            Money actual = taxCalc.roundUpToNearestFiveCents(testValue);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void roundUpToNearestFiveCents2()
        {
            // it should round up one cent
            var expected = 1.35m;
            var testValue = 1.34m;
            Money actual = taxCalc.roundUpToNearestFiveCents(testValue);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void roundUpToNearestFiveCents3()
        {
            var expected = 1.30m;
            var testValue = 1.29m;
            Money actual = taxCalc.roundUpToNearestFiveCents(testValue);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void roundUpToNearestFiveCents4()
        {
            // make sure it can deal with crazy decimals 
            var expected = 1.25m;
            var testValue = 1.20111m;
            Money actual = taxCalc.roundUpToNearestFiveCents(testValue);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void roundUpToNearestFiveCents5()
        {
            // make sure it can deal with crazy decimals 
            var expected = 5.05m;
            var testValue = 5.000001m;
            Money actual = taxCalc.roundUpToNearestFiveCents(testValue);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void roundUpToNearestFiveCents6()
        {
            // make sure it can deal with crazy decimals 
            var expected = 300.05m;
            var testValue = 300.04m;
            Money actual = taxCalc.roundUpToNearestFiveCents(testValue);
            Assert.AreEqual(expected, actual);
        }
    }
}
