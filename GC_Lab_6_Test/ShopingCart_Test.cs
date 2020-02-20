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
    }
}
