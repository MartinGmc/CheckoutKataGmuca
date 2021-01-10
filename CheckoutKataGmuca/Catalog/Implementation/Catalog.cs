using CheckoutKataGmuca.Catalog.Interface;
using CheckoutKataGmuca.DataObjects;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CheckoutKataGmuca.Catalog.Implementation
{
    public class Catalog : ICatalog
    {

        private MyLogger _logger;
        private List<Item> CatalogItems;

        public Catalog(MyLogger logger)
        {
            this._logger = logger;
            CatalogItems = new List<Item>();
        }

        public bool AddItemToCatalog(Item item)
        {

            var duplicitItem = GetItemByProductCode(item.ProductCode);
            if (duplicitItem == null)
            {
                CatalogItems.Add(item);
                _logger.logInfo($"item added suecessful {item.ProductCode}");
                return true;
            }
            else
            {
                _logger.logWarning($"Duplicate entry in Catalog {item.ProductCode} item ignored.");
                return false;
            }
        }

        public Item GetItemByProductCode(string productCode)
        {
            return CatalogItems.FirstOrDefault(p => p.ProductCode == productCode);
        }

        public List<Item> GetItems()
        {
            return CatalogItems;
        }
    }
}
