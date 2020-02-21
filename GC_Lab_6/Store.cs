using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Lab_6
{
    public class Store
    {
        public Inventory Stock { get; private set; }
        public Store()
        {
            Stock = new Inventory();
        }

        public void DisplayInventory()
        {
            Console.WriteLine("===================================================================================================");
            Console.WriteLine($"| {"Qty",3} | {"Song Name",-35} | {"Artist",-20} | {"Genre",-15} | {"Price", 10} |");
            Console.WriteLine("|=================================================================================================|");

            foreach (Product song in Stock.Songs.Keys)
            {
                if (Stock.Songs[song] > 0)
                {
                    Console.WriteLine($"| {Stock.Songs[song],3} | {song.SongName,-35} | {song.Artist,-20} | {song.Category,-15} | {song.Price,10:C} |");
                }

            }
            Console.WriteLine("===================================================================================================");

        }

        public void Shopping()
        {
            
            ShoppingCart cart = new ShoppingCart();
            DisplayInventory();

            while (true)
            {
                Console.WriteLine("|Avalible Commands:");
                Console.WriteLine("|- Add Song Single");
                Console.WriteLine("|- See Cart");
                Console.WriteLine("|- Refresh screen");
                Console.WriteLine("|- help");
                Console.Write("What would you like to do?\n > ");
                string input = Console.ReadLine().ToLower();
                Console.Clear();
                DisplayInventory();
                switch (input)
                {
                    case string s when s.Contains("refresh"):
                        Console.Clear();
                        DisplayInventory();
                        break;
                    case string s when s.Contains("add"):
                        AddSingleToCart(cart, input);
                        break;
                    case string s when s.Contains("cart"):
                        Console.WriteLine("Your cart:");
                        Console.WriteLine(cart.ToString());
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

        private static void DisplayHelp()
        {
            Console.WriteLine("Type in the command for the thing that you want to do!");
            Console.WriteLine( );
            // TODO: make this more useful
        }

        private static void AddSingleToCart(ShoppingCart cart, string input)
        {
            Console.WriteLine("attempting to add");

            // check if input already has a song title, artist or genere in it. 
            // TODO: complete Add Function

        }
    }
}
