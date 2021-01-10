using CheckoutKataGmuca;
using CheckoutKataGmuca.Catalog.Implementation;
using CheckoutKataGmuca.DataObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKataTest
{
    class CatalogTest
    {
        private static MyLogger logger;

        [SetUp]
        public void Setup()
        {
            //initialize logger
            logger = new MyLogger();
        }

        /// <summary>
        /// Test of initialization Catalog
        /// </summary>
        [Test]
        public void CatalogInitTest()
        {
            Catalog cat = new Catalog(logger);
            Assert.Pass();
        }

        [Test]
        /// <summary>
        /// test if can be sucessfully added item to catalog
        /// </summary>
        public void CatalogAddItemSucess()
        {
            Catalog cat = new Catalog(logger);

            Item newItem = new Item() { Price = 1, ProductCode = "aaaa", SpecOffer = null };
            bool res = cat.AddItemToCatalog(newItem);

            Assert.IsTrue(res);
        }

        [Test]
        /// <summary>
        /// test if can be sucessfully returned list of entries
        /// </summary>
        public void CatalogGetItemsTest()
        {
            Catalog cat = new Catalog(logger);

            Item newItem = new Item() { Price = 1, ProductCode = "aaaa", SpecOffer = null };
            bool res = cat.AddItemToCatalog(newItem);

            var items = cat.GetItems();

            Assert.IsTrue(items.Count>0);
        }

        [Test]
        /// <summary>
        /// test if duplicit item cannot be added to catalog
        /// </summary>
        public void CatalogAddItemNoSucess()
        {
            Catalog cat = new Catalog(logger);

            Item newItem = new Item() { Price = 1, ProductCode = "aaaa", SpecOffer = null };
            bool res = cat.AddItemToCatalog(newItem);

            newItem = new Item() { Price = 1, ProductCode = "aaaa", SpecOffer = null };
            res = cat.AddItemToCatalog(newItem);

            Assert.IsFalse(res);
        }

        [Test]
        /// <summary>
        /// test if inserted item can be found in catalog
        /// </summary>
        public void FindCatalogItem()
        {
            Catalog cat = new Catalog(logger);

            Item newItem = new Item() { Price = 1, ProductCode = "aaaa", SpecOffer = null };
            bool res = cat.AddItemToCatalog(newItem);

            var res2 = cat.GetItemByProductCode("aaaa");

            Assert.IsTrue(res2 != null);
        }

        [Test]
        /// <summary>
        /// test if non existing item can not be found in catalog
        /// </summary>
        public void FindCatalogItemNonExist()
        {
            Catalog cat = new Catalog(logger);

            Item newItem = new Item() { Price = 1, ProductCode = "aaaa", SpecOffer = null };
            bool res = cat.AddItemToCatalog(newItem);

            var res2 = cat.GetItemByProductCode("aaaadfds");

            Assert.IsFalse(res2 != null);
        }

    }
}
