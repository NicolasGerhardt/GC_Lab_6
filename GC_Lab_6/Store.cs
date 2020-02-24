using System;
using System.Collections.Generic;

namespace GC_Lab_6
{
    public class Store
    {
        private Inventory stock;
        private ShoppingCart cart;
        private bool isShopping;

        public Store() { stock = new Inventory(); cart = new ShoppingCart(); isShopping = false; }

        public void Shopping()
        {

            
            string displayBuffer = "you may type \'help\' at anytime to see a list of commands.\n";
            isShopping = true;

            while (isShopping)
            {
                Console.Clear();
                DisplayInventory();
                Console.WriteLine("Your cart:");
                Console.WriteLine(cart.GetReceipt());
                displayBuffer += "What would you like to do?\n > ";
                Console.Write(displayBuffer);
                string input = Console.ReadLine().ToLower();
                displayBuffer = string.Empty;
                
                switch (input)
                {
                    case string s when s.Contains("add"):
                        displayBuffer += AddSingleToCart(input);
                        break;
                    case string s when s.Contains("remove"):
                        displayBuffer += RemoveSingleFromCart(input);
                        break;
                    case string s when s.Contains("help"):
                        displayBuffer += GetHelpInfo();
                        break;
                    case string s when s.Contains("leave"):
                        displayBuffer += AttemptToLeave(input);
                        break;
                    default:
                        displayBuffer += $"I don't understand! \'{input}\'\n";
                        break;
                }
            }

            Console.WriteLine(displayBuffer);
        }

        private string AttemptToLeave(string input)
        {
            string message = string.Empty;

            if (cart.Items.Count > 0)
            {
                message +=  $"You have {cart.SubTotal.ToString("C")} of songs in your cart.\n";
                message += $"Either will need to eitehr \'buy\' or \'remove all\' items from your cart before leaving.\n";
            }
            else
            {
                message += "Thank you for coming by!";
                isShopping = false;
            }
            
            
            return message;
        }

        private string RemoveSingleFromCart(string input)
        {
            input = input.Replace("remove", " ").Trim();

            if (input == "all")
            {
                RemoveAllFromCart();
                return "Everything has been removed from your cart.";
            }

            while (true)
            {
                List<Product> found = SearchForSongInCart(input);

                if (found.Count == 1)
                {
                    var song = found[0];
                    bool gotQuanitty = false;
                    int qty;
                    do
                    {
                        Console.Write($"How many \'{song.SongName}\' would you like to remove?\n > ");
                        input = Console.ReadLine();
                        gotQuanitty = int.TryParse(input, out qty);
                        if (!gotQuanitty && input == "all")
                        {
                            gotQuanitty = true;
                            qty = cart.Items[song];
                        }
                        if (gotQuanitty) Console.WriteLine("must be a number");
                    } while (!gotQuanitty);
                    qty = cart.RemoveFromCart(song, qty);
                    stock.AddToStock(song, qty);
                    return $"Removed {qty} x {song.SongName} by {song.Artist} from your cart.\n";
                }
                else if (found.Count > 1)
                {
                    Console.WriteLine("We found these: ");
                    DisplayList(found);
                    Console.Write("Which song would you like to remove? \n > ");
                    input = Console.ReadLine().ToLower().Trim();
                }
                else
                {
                    return $"could not find \'{input}\' in your cart.\n";
                }
            }
        }

        private void RemoveAllFromCart()
        {
            foreach (Product song in cart.Items.Keys)
            {
                stock.AddToStock(song, cart.Items[song]);
            }
            cart = new ShoppingCart();
        }

        private string AddSingleToCart(string input)
        {
            input = input.Replace("add", " ").Trim();

            while (true)
            {
                List<Product> found = SearchForSongInStock(input);

                if (found.Count == 1)
                {
                    var song = found[0];
                    bool gotQuanitty = false;
                    int qty;
                    do
                    {
                        Console.Write($"How many \'{song.SongName}\' would you like to add?\n > ");
                        input = Console.ReadLine();
                        gotQuanitty = int.TryParse(input, out qty);
                        if (gotQuanitty) Console.WriteLine("must be a number");
                    } while (!gotQuanitty);
                    qty = stock.RemoveFromStock(song, qty);
                    cart.AddProduct(song, qty);
                    return $"Added {song.SongName} by {song.Artist} to your cart.\n";
                }
                else if (found.Count > 1)
                {
                    Console.WriteLine("We found these: ");
                    DisplayList(found);
                    Console.Write("Which song would you like to add? \n > ");
                    input = Console.ReadLine().ToLower().Trim();
                }
                else
                {
                    return $"could not find \'{input}\' in our inventory.\n";
                }
            }
        }

        private static void DisplayList(List<Product> found)
        {

            foreach (Product song in found)
            {
                if (found.Count > 0)
                {
                    Console.WriteLine($" - {song.SongName} by {song.Artist}");
                }

            }


        }



        private List<Product> SearchForSongInCart(string input)
        {
            return SearchForSongIn(cart.Items, input);
        }

        private List<Product> SearchForSongInStock(string input)
        {
            return SearchForSongIn(stock.Songs, input);
        }

        private List<Product> SearchForSongIn(Dictionary<Product, int> dict, string input)
        {
            List<Product> found = new List<Product>();

            foreach (Product product in dict.Keys)
            {
                if (product.SongName.ToLower().Contains(input))
                {
                    found.Add(product);
                }
            }
            return found;
        }

        private string GetHelpInfo()
        {
            string output = string.Empty;
            output += "Type \'add\' and the name of the song you want to add to your cart \n";
            output += "Type \'remove\' and the name of the song you want to remove from your cart \n";
            output += "When you are ready to cashout, type \'buy\' \n";
            output += "When you are ready to leave, type \'leave\' \n";
            return output;
        }

        private void DisplayInventory()
        {
            Console.WriteLine("===================================================================================================");
            Console.WriteLine($"| {"Qty",3} | {"Song Name",-35} | {"Artist",-20} | {"Genre",-15} | {"Price",10} |");
            Console.WriteLine("|=================================================================================================|");

            foreach (Product song in stock.Songs.Keys)
            {
                if (stock.Songs[song] > 0)
                {
                    Console.WriteLine($"| {stock.Songs[song],3} | {song.SongName,-35} | {song.Artist,-20} | {song.Category,-15} | {song.Price,10:C} |");
                }

            }
            Console.WriteLine("===================================================================================================");

        }


    }
}
