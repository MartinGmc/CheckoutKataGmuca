using CheckoutKataGmuca.Catalog.Implementation;
using CheckoutKataGmuca.Catalog.Interface;
using CheckoutKataGmuca.Checkout;
using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace CheckoutKataGmuca
{
    class Program
    {
        private static MyLogger logger;
        private static ICatalog catalog;
        private static IcheckOut checkout;
        private static ICatalogLoader CatalogLoader;

        static void Main(string[] args)
        {
            //initialize logger
            logger = new MyLogger();

            //initialize catalog
            catalog = new Catalog.Implementation.Catalog(logger);
            CatalogLoader = new FileCatalogLoader("DemoCatalog.txt",logger);

            CatalogLoader.LoadCatalog(catalog);

            //initialize checkout
            checkout = new Checkout.Implementation.CheckOut(catalog, logger);

            var catalogItems = catalog.GetItems();
            StringBuilder ProductList = new StringBuilder();
            foreach (var item in catalogItems)
            {
                ProductList.Append(item.ProductCode + ",");
            }
            Console.WriteLine($"Loaded products : {ProductList.ToString()}");
            Console.WriteLine("please enter first product to scan: (Q to quit || T to total)");
            string input = "";
            while (input != "Q")
            {
                input = Console.ReadLine();
                if (input == "T") Console.WriteLine($"TOTAL :{checkout.Total()}");
                else
                {
                    if (checkout.Scan(input)) Console.WriteLine("OK");
                    else Console.WriteLine("Product not found in catalog");
                }
            }

            
        }
    }
}
