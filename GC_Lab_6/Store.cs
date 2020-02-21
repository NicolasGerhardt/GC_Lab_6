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
            DisplayInventory();

            while (true)
            {
                Console.Clear();
                DisplayInventory();
                Console.WriteLine("Your cart:");
                Console.WriteLine(cart.GetReceipt());
                Console.WriteLine("|Avalible Commands:");
                Console.WriteLine("|- Add Song Single");
                Console.WriteLine("|- Refresh screen");
                Console.WriteLine("|- help");
                Console.Write("What would you like to do?\n > ");
                string input = Console.ReadLine().ToLower();
                
                switch (input)
                {
                    case string s when s.Contains("refresh"):
                        Console.Clear();
                        DisplayInventory();
                        break;
                    case string s when s.Contains("add"):
                        AddSingleToCart(cart, input);
                        break;
                    case string s when s.Contains("help"):
                        DisplayHelp();
                        break;
                    case string s when (s.Contains("leave") || s.Contains("quit")):
                        return;
                    default:
                        Console.WriteLine($"I don't understand! \'{input}\'\n");
                        break;
                }
            }
        }

        private void AddSingleToCart(ShoppingCart cart, string input)
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
                    return;
                }
                else if (found.Count > 1)
                {
                    Console.WriteLine("We found these: ");
                    DisplayList(found);
                }
                else
                {
                    Console.WriteLine("We ain't find shit!");
                    DisplayInventory();
                }
                Console.Write("Which song would you like to add? \n > ");
                input = Console.ReadLine().ToLower().Trim();

            }


            // check if input already has a song title, artist or genere in it. 
            // TODO: complete Add Function



        }

        private static void DisplayList(List<Product> found)
        {

            foreach (Product song in found)
            {
                if (found.Count > 0)
                {
                    Console.WriteLine($" {song.ToString()}");
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

        private static void DisplayHelp()
        {
            Console.WriteLine("Type in the command for the thing that you want to do!");
            Console.WriteLine();
            // TODO: make this more useful
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
