using CheckoutKataGmuca.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKataGmuca.Catalog.Interface
{
    public interface ICatalog
    {
        /// <summary>
        /// Get item from catalog identified by productcode
        /// </summary>
        /// <param name="productCode">product code of item</param>
        /// <returns>item with productcode</returns>
        abstract Item GetItemByProductCode(string productCode);

        /// <summary>
        /// adds item to catalog
        /// Must check if is not item with same product code already
        /// if yes, item will not be added (returned false)
        /// </summary>
        /// <param name="item">item to add</param>
        /// <returns>true if sucess false if not sucess</returns>
        abstract bool AddItemToCatalog(Item item);

        /// <summary>
        /// get all items in catalog
        /// </summary>
        /// <returns>list of items in catalog</returns>
        abstract List<Item> GetItems();
    }
}
