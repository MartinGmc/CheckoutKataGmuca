using CheckoutKataGmuca;
using CheckoutKataGmuca.Catalog.Implementation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKataTest
{
   public class FileCatalogLoaderTest
    {
        private static MyLogger logger;

        [SetUp]
        public void Setup()
        {
            //initialize logger
            logger = new MyLogger();
        }

        /// <summary>
        /// Test of initialization Catalog Loader
        /// </summary>
        [Test]
        public void CatalogLoaderInitTest()
        {
            FileCatalogLoader cat = new FileCatalogLoader("DemoCatalog.txt",logger);
            Assert.Pass();
        }

        /// <summary>
        /// test if items can be loaded from catalog
        /// </summary>
        [Test]
        public void CatalogLoaderFillTest()
        {
            Catalog testCatalog = new Catalog(logger);
            
            FileCatalogLoader cat = new FileCatalogLoader("DemoCatalog.txt", logger);
            var OutputCatalog = cat.LoadCatalog(testCatalog);

            var found = OutputCatalog.GetItemByProductCode("Apples");

            Assert.IsNotNull(found);
        }


    }
}
