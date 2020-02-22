using System;
using System.Collections.Generic;

namespace GC_Lab_6
{
    public class Store
    {
        private Inventory stock;

        public Store() { stock = new Inventory(); }

        public void Shopping()
        {

            ShoppingCart cart = new ShoppingCart();
            string displayBuffer = "you may type \'help\' at anytime to see a list of commands.\n";

            while (true)
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
                        displayBuffer += AddSingleToCart(cart, input);
                        break;
                    case string s when s.Contains("remove"):
                        displayBuffer += RemoveSingleFromCart(cart, input);
                        break;
                    case string s when s.Contains("buy"):
                        displayBuffer += BuySinglesInCart(cart, input);
                        break;
                    case string s when s.Contains("help"):
                        displayBuffer += GetHelpInfo();
                        break;
                    case string s when (s.Contains("leave") || s.Contains("quit")):
                        return;
                    default:
                        displayBuffer += $"I don't understand! \'{input}\'\n";
                        break;
                }
            }
        }

        private string BuySinglesInCart(ShoppingCart cart, string input)
        {
            // TODO: Complete this method
            throw new NotImplementedException();
        }

        private string RemoveSingleFromCart(ShoppingCart cart, string input)
        {
            // TODO: Complete this method
            throw new NotImplementedException();
        }

        private string AddSingleToCart(ShoppingCart cart, string input)
        {
            input = input.Replace("add ", " ").Trim();

            while (true)
            {
                List<Product> found = SearchForSong(input);

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



        private List<Product> SearchForSong(string input)
        {
            List<Product> found = new List<Product>();

            foreach (Product product in stock.Songs.Keys)
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
            output += "Type \'add\' and the name of the song you want to add. \n";
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
