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
    }
}
