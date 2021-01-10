using CheckoutKataGmuca.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKataGmuca.Checkout
{
    interface IcheckOut
    {
        /// <summary>
        /// chack if provided product code is present in catalog and add it into checkout.
        /// </summary>
        /// <param name="productCode">productcode of product</param>
        /// <returns>true if sucessfuly added, fals if product is not in catalog</returns>
        abstract bool Scan(string productCode);

        /// <summary>
        /// get tpotal sum of checkout
        /// </summary>
        /// <returns>total sum of price of all items</returns>
        abstract double Total();

    }
}
