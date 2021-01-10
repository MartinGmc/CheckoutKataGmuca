using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKataGmuca.DataObjects
{
    public class Item
    {
        /// <summary>
        /// no param constructor for tests. (not for real use)
        /// </summary>
        public Item()
        { }
        
        /// <summary>
        /// Constructor
        /// Expecting Data in format
        /// PRODUCTCODE|PRICE|SPECIALOFFERNUMBER|SPECIALOFFERPRICE
        /// SPECIALOFFERNUMBER and SPECIALOFFERPRICE are optional
        /// </summary>
        /// <param name="itemFromFile">Item represented as string</param>
        public Item(string itemFromFile)
        {
            //try
            //{
                string[] splitted = itemFromFile.Split('|');
                //item must have first two parameters
                if (splitted.Length >= 2)
                {
                    this.ProductCode = splitted[0];

                    try
                    {
                        this.Price = double.Parse(splitted[1]);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"ERROR ITEM:02 Cannot parse price for creating Item data:{itemFromFile} cannot parse:{splitted[1]} exception: {ex.Message}");
                    }
                }
                else
                {
                    throw new Exception($"ERROR ITEM:01 Invalid input data for creating Item data: {itemFromFile}");
                }
                //another two parameters are optional but if they are, must be both
                if (splitted.Length == 4)
                {
                    this.SpecOffer = new ItemSpecialOffer();

                    try
                    {
                        this.SpecOffer.Number = int.Parse(splitted[2]);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"ERROR ITEM:03 Cannot parse Number for creating ItemSpecialOffer data:{itemFromFile} cannot parse:{splitted[2]} exception: {ex.Message}");
                    }

                    try
                    {
                        this.SpecOffer.Price = double.Parse(splitted[3]);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"ERROR ITEM:04 Cannot parse price for creating ItemSpecialOffer data:{itemFromFile} cannot parse:{splitted[3]} exception: {ex.Message}");
                    }

                }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception($"ERROR ITEM:05 Unexpected exception occured when parsing data:{itemFromFile} exception: {ex.Message} stackTrace: {ex.StackTrace}");
            //}
        }

        public string ProductCode { get; set; }
        public double Price { get; set; }
        public ItemSpecialOffer SpecOffer { get; set; }
    }
}
