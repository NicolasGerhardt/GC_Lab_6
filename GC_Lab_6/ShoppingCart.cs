using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Lab_6
{
    public class ShoppingCart
    {
        public Dictionary<Product, int> Items { get; private set; }

        public ShoppingCart()
        {
            Items = new Dictionary<Product, int>();
        }

        /// <summary>
        /// Adds an item to the shopping cart
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public void AddProduct(Product product, int quantity)
        {
            Items.Add(product, quantity);
        }
    }
}
