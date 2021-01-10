using CheckoutKataGmuca.DataObjects;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKataGmuca.Catalog.Interface
{
    interface ICatalogLoader
    {
        /// <summary>
        /// fills catalog with catalog items
        /// </summary>
        /// <param name="CatalogToFill">catalog to fill</param>
        /// <returns>filled catalog</returns>
        abstract ICatalog LoadCatalog(ICatalog CatalogToFill);
    }
}
