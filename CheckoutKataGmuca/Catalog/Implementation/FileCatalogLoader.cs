using CheckoutKataGmuca.Catalog.Interface;
using CheckoutKataGmuca.DataObjects;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CheckoutKataGmuca.Catalog.Implementation
{
    public class FileCatalogLoader : ICatalogLoader
    {
        private string fileToLoad;
        private MyLogger logger;
        
        public FileCatalogLoader(string filename, MyLogger logger)
        {
            this.fileToLoad = filename;
            this.logger = logger;
        }
        
        public ICatalog LoadCatalog(ICatalog CatalogToFill)
        {
            logger.logInfo($"Loading Catalog started filename: {fileToLoad}");
            var lines = File.ReadAllLines(fileToLoad);
            foreach (var line in lines)
            {
                try
                {
                    Item NewItem = new Item(line);
                    CatalogToFill.AddItemToCatalog(NewItem);
                }
                catch (Exception ex)
                {
                    logger.logWarning($"problem loading item {line} item ignored. problem: {ex.Message}");
                }
            }
            return CatalogToFill;

        }
    }
}

