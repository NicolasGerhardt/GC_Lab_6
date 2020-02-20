using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Lab_6
{
    public class ShoppingCart
    {
        public Dictionary<Product, int> Items { get; private set; }
        public double SubTotal
        {
            get
            {
                double _subtotal = 0;

                foreach (Product product in Items.Keys)
                {
                    _subtotal += Items[product] * product.Price;
                }

                return _subtotal;
            }
        }
        public double Tax { get { return SubTotal * 0.06; } }

        public double Total { get { return SubTotal + Tax; } }


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

        public string GetReceipt()
        {
            string output = string.Empty;

            foreach (Product item in Items.Keys)
            {
                string lineItem = $"{item.SongName} by {item.Artist}";
                output += $"{Items[item]} x {lineItem,-35} -- {item.Price.ToString("C")}\n";
            }
            output += "================================================\n";
            output += $"subtotal: {SubTotal.ToString("C")}\n";
            output += $"  6% Tax: {Tax.ToString("C")}\n";
            output += $"   Total: {Total.ToString("C")}\n";

            return output;
        }
    }
}
