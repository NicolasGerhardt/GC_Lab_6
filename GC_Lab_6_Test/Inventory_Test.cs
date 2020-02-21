using GC_Lab_6;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GC_Lab_6_Test
{
    public class Inventory_Test
    {
        [Fact]
        public static void AddToStock_AddNonExistingProductToStock_NonExistingProdcutExists()
        {
            Product song = new Product();
            var stock = new Inventory();
            int expected = 5;

            stock.AddToStock(song, expected);

            Assert.True(stock.Songs.ContainsKey(song));
            Assert.Equal(expected, stock.Songs[song]);
        }

        [Fact]
        public static void AddToStock_AddZeroToStock_NoChangeInStockLevels()
        {
            Product song = new Product();
            var stock = new Inventory();
            int expected = 5;
            stock.AddToStock(song, 0);

            stock.AddToStock(song, expected);

            Assert.True(stock.Songs.ContainsKey(song));
            Assert.Equal(expected, stock.Songs[song]);
        }

        [Fact]
        public static void AddToStock_Add3ToStock_QuantityUpThree()
        {
            Product song = new Product();
            var stock = new Inventory();
            int expected = 5;
            stock.AddToStock(song, 2);

            stock.AddToStock(song, 3);

            Assert.True(stock.Songs.ContainsKey(song));
            Assert.Equal(expected, stock.Songs[song]);
        }

        [Fact]
        public static void AddToStock_AddNegitiveToStock_NoChangeInStockLevels()
        {
            Product song = new Product();
            var stock = new Inventory();
            int expected = 5;
            stock.AddToStock(song, expected);

            stock.AddToStock(song, -3);

            Assert.True(stock.Songs.ContainsKey(song));
            Assert.Equal(expected, stock.Songs[song]);
        }

        [Fact]
        public static void RemoveFromStock_RemoveNonExistingProductToStock_ZeroItemsReturned()
        {
            Product song = new Product();
            var stock = new Inventory();
            int expected = 5;
            stock.AddToStock(song, 10);

            stock.RemoveFromStock(song, expected);

            Assert.True(stock.Songs.ContainsKey(song));
            Assert.Equal(expected, stock.Songs[song]);
        }

        [Fact]
        public static void RemoveFromStock_RemoveZeroToStock_NoChangeInStockLevels()
        {
            Product song = new Product();
            var stock = new Inventory();
            int expected = 5;
            stock.AddToStock(song, 5);

            stock.RemoveFromStock(song, 0);

            Assert.True(stock.Songs.ContainsKey(song));
            Assert.Equal(expected, stock.Songs[song]);
        }

        [Fact]
        public static void RemoveFromStock_remove3FromStock_QuantityDownthree()
        {
            Product song = new Product();
            var stock = new Inventory();
            int expected = 5;
            stock.AddToStock(song, 8);

            stock.RemoveFromStock(song, 3);

            Assert.True(stock.Songs.ContainsKey(song));
            Assert.Equal(expected, stock.Songs[song]);
        }

        [Fact]
        public static void RemoveFromStock_RemoveNegitiveFromStock_NoChangeInStockLevels()
        {
            Product song = new Product();
            var stock = new Inventory();
            int expected = 5;
            stock.AddToStock(song, expected);

            stock.RemoveFromStock(song, -3);

            Assert.True(stock.Songs.ContainsKey(song));
            Assert.Equal(expected, stock.Songs[song]);
        }

        [Fact]
        public static void RemoveFromStock_RemoveMoreThanInStock_ZeroStockLeft()
        {
            Product song = new Product();
            var stock = new Inventory();
            int expected = 0;
            stock.AddToStock(song, 2);

            stock.RemoveFromStock(song, 5);

            Assert.True(stock.Songs.ContainsKey(song));
            Assert.Equal(expected, stock.Songs[song]);
        }
    }
}
