using System;
using Xunit;
using GC_Lab_6;

namespace GC_Lab_6_Test
{
    public class Product_Test
    {
        [Fact]
        public void ProductClass_POCO_Test()
        {
            // AvenagersAssemble
            Product product = new Product();
            product.SongName = "Roe";
            product.Category = "Freestyle";
            product.Artist = "Nic & Ollie";
            product.Price = 500.00;
            string expected = $"Freestyle, Roe, Nic & Ollie, {500.00}";

            // Action
            string actual = product.RapSheet;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]

        public void ProductClass_SongName_Test()
        {
            Product product = new Product();
            product.SongName = "This is the song that never ends";
        }
    }
}
