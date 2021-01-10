using CheckoutKataGmuca;
using CheckoutKataGmuca.Catalog.Implementation;
using CheckoutKataGmuca.Checkout.Implementation;
using CheckoutKataGmuca.DataObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKataTest
{
    class CheckoutTest
    {

        private static MyLogger logger;
        private static Catalog catalog;

        [SetUp]
        public void Setup()
        {
            //initialize logger
            logger = new MyLogger();

            //initialize catalog
            catalog = new Catalog(logger);

            Item Item1 = new Item() { Price = 0.5, ProductCode = "Apples" };
            Item Item2 = new Item() { Price = 0.7, ProductCode = "Bananas", SpecOffer = new ItemSpecialOffer() { Number = 2, Price = 1 } };
            Item Item3 = new Item() { Price = 0.45, ProductCode = "Oranges", SpecOffer = new ItemSpecialOffer() { Number = 3, Price = 0.9 } };

            catalog.AddItemToCatalog(Item1);
            catalog.AddItemToCatalog(Item2);
            catalog.AddItemToCatalog(Item3);

        }

        /// <summary>
        /// test if initialization of object is OK
        /// </summary>
        [Test]
        public void CheckoutInitializationTest()
        {
            CheckOut chk = new CheckOut(catalog, logger);
            Assert.Pass();
        }

        /// <summary>
        /// test if scanning of existing item will return true
        /// </summary>
        [Test]
        public void CheckOutScanTest()
        {
            CheckOut chk = new CheckOut(catalog, logger);
            bool res = chk.Scan("Apples");
            Assert.IsTrue(res);
        }

        /// <summary>
        /// test if scanning of non existing item will return false
        /// </summary>
        [Test]
        public void CheckOutScanNoExistingTest()
        {
            CheckOut chk = new CheckOut(catalog, logger);
            bool res = chk.Scan("xxx");
            Assert.IsFalse(res);
        }

        /// <summary>
        /// simple totoal calculation test
        /// </summary>
        [Test]
        public void SimpleTotalTest()
        {
            CheckOut chk = new CheckOut(catalog, logger);
            chk.Scan("Apples");
            chk.Scan("Apples");
            double total = chk.Total();
            Assert.IsTrue(total == 1);
        }

        /// <summary>
        /// total calculation test with special offer
        /// </summary>
        [Test]
        public void ComplexTotalTest()
        {
            CheckOut chk = new CheckOut(catalog, logger);
            chk.Scan("Apples");
            chk.Scan("Bananas");
            chk.Scan("Apples");
            chk.Scan("Bananas");
            double total = chk.Total();
            Assert.IsTrue(total == 2);
        }

        /// <summary>
        /// cached total test
        /// </summary>
        [Test]
        public void CachedTotalTest()
        {
            CheckOut chk = new CheckOut(catalog, logger);
            chk.Scan("Apples");
            chk.Scan("Bananas");
            chk.Scan("Apples");
            chk.Scan("Bananas");
            double total = chk.Total();
            total = chk.Total();
            Assert.IsTrue(total == 2);
        }
    }
}
