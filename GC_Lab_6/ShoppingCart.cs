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
            if (quantity < 0) return;

            if (Items.ContainsKey(product))
            {
                Items[product] += quantity;
            }
            else
            {
                Items.Add(product, quantity);
            }
        }

        public int RemoveFromCart(Product song, int quantity)
        {
            if (quantity < 0) return 0;
            if (!Items.ContainsKey(song)) return 0;

            if (Items[song] > quantity)
            {
                Items[song] -= quantity;
                return quantity;
            }

            quantity = Items[song];
            Items.Remove(song);
            return quantity;
        }

        public string GetReceipt()
        {
            string output = ToString();

            output += "================================================\n";
            output += $"subtotal: {SubTotal.ToString("C")}\n";
            output += $"  6% Tax: {Tax.ToString("C")}\n";
            output += $"   Total: {Total.ToString("C")}\n";

            return output;
        }

        public override string ToString()
        {
            string output = string.Empty;

            if (Items.Count == 0)
            {
                output += "Oh NO! The cart is empty!";
            }

            foreach (Product item in Items.Keys)
            {
                string lineItem = $"{item.SongName} by {item.Artist}";
                output += $"{Items[item]} x {lineItem,-35} -- {item.Price.ToString("C")}\n";
            }

            return output;
        }
    }
}
