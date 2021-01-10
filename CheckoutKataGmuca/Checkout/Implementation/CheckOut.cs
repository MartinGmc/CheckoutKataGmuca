using CheckoutKataGmuca.Catalog.Interface;
using CheckoutKataGmuca.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckoutKataGmuca.Checkout.Implementation
{
    public class CheckOut : IcheckOut
    {
        private ICatalog productCatalog;
        private MyLogger logger;
        private List<Item> items = new List<Item>();
        private double sumTotalCached = -1;

        public CheckOut(ICatalog catalog, MyLogger logger)
        {
            this.productCatalog = catalog;
            this.logger = logger;
        }
        
        public bool Scan(string productCode)
        {
            logger.logInfo($"Scanned {productCode}");
            var item = productCatalog.GetItemByProductCode(productCode);
            if (item != null)
            {
                items.Add(item);
                //clear cache
                sumTotalCached = -1;
                return true;
            }
            else
            {
                return false;
            }
        }

        public double Total()
        {
            //if have in cache return from cache
            if (sumTotalCached > 0) return sumTotalCached;
            else
            {
                sumTotalCached = 0;
                List<string> countedCodes = new List<string>();
                
                foreach (var item in items)
                {
                    if (!countedCodes.Contains(item.ProductCode)){
                        countedCodes.Add(item.ProductCode);
                        var thisItem = items.Where(p => p.ProductCode == item.ProductCode).ToList();
                        if (item.SpecOffer != null)
                        {
                            sumTotalCached = sumTotalCached + (thisItem.Count / item.SpecOffer.Number) * item.SpecOffer.Price;
                            sumTotalCached = sumTotalCached + (thisItem.Count % item.SpecOffer.Number) * item.Price;
                        }
                        else
                        {
                            sumTotalCached = sumTotalCached + (item.Price * thisItem.Count);
                        }
                    }
                }
            }
            return sumTotalCached;
        }
    }
}
