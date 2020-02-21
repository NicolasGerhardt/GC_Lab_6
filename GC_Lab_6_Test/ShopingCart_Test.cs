using GC_Lab_6;
using Xunit;

namespace GC_Lab_6_Test
{
    public class ShopingCart_Test
    {
        [Fact]
        public void Cart_hasCollectionOfItmes_NotNull()
        {
            ShoppingCart cart = new ShoppingCart();


            // Assert

            Assert.NotNull(cart.Items);
        }

        [Fact]
        public void Cart_addingProdcutToCart_ItemInDictionary()
        {
            ShoppingCart cart = new ShoppingCart();

            Product testItem = new Product();

            cart.AddProduct(testItem, 1);
            

            // Assert

            Assert.Equal(1, cart.Items[testItem]);
        }

        [Fact]
        public void Cart_GetSubTotal_SubtotalAmount()
        {
            ShoppingCart cart = new ShoppingCart();
            double expectedSubtotal = 4.97;
            Product testItem = new Product("Holland, 1945", "Ska", "Netural Milk Hotel", 2.99);
            Product testItem2 = new Product("Ruler of Everything", "Rich", "Tally Hall", 0.99);
            cart.AddProduct(testItem, 1);
            cart.AddProduct(testItem2, 2);

            double actualSubTotal = cart.SubTotal;
            // Assert

            Assert.Equal(expectedSubtotal, actualSubTotal, 2);
        }

        [Fact]
        public void Cart_GetTax_TaxAmount()
        {
            ShoppingCart cart = new ShoppingCart();
            double expectedSubtotal = 4.97 * 0.06; // Assuming 6% sales tax
            Product testItem = new Product("Holland, 1945", "Ska", "Netural Milk Hotel", 2.99);
            Product testItem2 = new Product("Ruler of Everything", "Rich", "Tally Hall", 0.99);
            cart.AddProduct(testItem, 1);
            cart.AddProduct(testItem2, 2);

            double actualSubTotal = cart.Tax;
            // Assert

            Assert.Equal(expectedSubtotal, actualSubTotal, 2);
        }

        [Fact]
        public void Cart_GetTotal_TotalAmount()
        {
            ShoppingCart cart = new ShoppingCart();
            double expectedSubtotal = 4.97 * 1.06; // Assuming 6% sales tax
            Product testItem = new Product("Holland, 1945", "Ska", "Netural Milk Hotel", 2.99);
            Product testItem2 = new Product("Ruler of Everything", "Rich", "Tally Hall", 0.99);
            cart.AddProduct(testItem, 1);
            cart.AddProduct(testItem2, 2);

            double actualSubTotal = cart.Total;
            // Assert

            Assert.Equal(expectedSubtotal, actualSubTotal, 2);
        }

        [Fact]
        public void GetReceipt_RequestReceiptwithTwoProducts_GetStringOutupt()
        {
            ShoppingCart cart = new ShoppingCart();
            Product testItem = new Product("Holland, 1945", "Ska", "Netural Milk Hotel", 2.99);
            Product testItem2 = new Product("Ruler of Everything", "Rich", "Tally Hall", 0.99);
            cart.AddProduct(testItem, 1);
            cart.AddProduct(testItem2, 2);
            string expected = string.Empty;
            expected += "1 x Holland, 1945 by Netural Milk Hotel -- $2.99\n";
            expected += "2 x Ruler of Everything by Tally Hall   -- $0.99\n";
            expected += "================================================\n";
            expected += "subtotal: $4.97\n";
            expected += "  6% Tax: $0.30\n";
            expected += "   Total: $5.27\n";

            string actual = cart.GetReceipt();

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void ToString_RequestReceiptwithTwoProducts_GetStringOutupt()
        {
            ShoppingCart cart = new ShoppingCart();
            Product testItem = new Product("Holland, 1945", "Ska", "Netural Milk Hotel", 2.99);
            Product testItem2 = new Product("Ruler of Everything", "Rich", "Tally Hall", 0.99);
            cart.AddProduct(testItem, 1);
            cart.AddProduct(testItem2, 2);
            string expected = string.Empty;
            expected += "1 x Holland, 1945 by Netural Milk Hotel -- $2.99\n";
            expected += "2 x Ruler of Everything by Tally Hall   -- $0.99\n";

            string actual = cart.ToString();

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void ToString_EmptyCart_EmptyCartMessage()
        {
            ShoppingCart cart = new ShoppingCart();
            
            string expected = "Oh NO! The cart is empty!";

            string actual = cart.ToString();

            Assert.Equal(expected, actual);

        }
    }
}
