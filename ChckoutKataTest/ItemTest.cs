using CheckoutKataGmuca.DataObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKataTest
{
    class ItemTest
    {

        /// <summary>
        /// Test to create simple item from text
        /// </summary>
        [Test]
        public void SimpleItemCreationSucessTest()
        {
            Item newItem = new Item("Apples|0.5");
            Assert.Pass();
        }

        /// <summary>
        /// Test to create item with special price from text
        /// </summary>
        [Test]
        public void SpecialPriceItemCreationSucessTest()
        {
            Item newItem = new Item("Bananas|0.7|2|1.0");
            Assert.Pass();
        }

        /// <summary>
        /// Test to throw error ITEM:02
        /// </summary>
        [Test]
        public void ItemThrowPriceParseError()
        {
            try
            {
                Item NewItem = new Item("Apples|x");
            }
            catch (Exception)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        /// <summary>
        /// Test to throw error ITEM:01
        /// </summary>
        [Test]
        public void ItemThrowLengthError()
        {
            try
            {
                Item NewItem = new Item("Apples");
            }
            catch (Exception)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        /// <summary>
        /// Test to throw error ITEM:03
        /// </summary>
        [Test]
        public void ItemThrowSpecialOfferNumberError()
        {
            try
            {
                Item NewItem = new Item("Bananas|0.7|x|1.0");
            }
            catch (Exception)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        /// <summary>
        /// Test to throw error ITEM:04
        /// </summary>
        [Test]
        public void ItemThrowSpecialOfferPriceError()
        {
            try
            {
                Item NewItem = new Item("Bananas|0.7|1|x");
            }
            catch (Exception)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }



    }
}
