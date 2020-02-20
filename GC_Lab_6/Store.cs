using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Lab_6
{
    public static class Store
    {
        public static void DisplayInventory()
        {
            Console.WriteLine($"{"Song Name",-35} | {"Artist",-20} | {"Genre",-15} | {"Price", 10}");
            Console.WriteLine("----------------------------------------------------------------------------");

            foreach (Product song in Inventory.songs.Keys)
            {
                Console.WriteLine($"{song.SongName, -35} | {song.Artist, -20} | {song.Category, -15} | {song.Price,10:C}");
            }

        }

        public static void Shopping()
        {
            ShoppingCart cart = new ShoppingCart();

            Console.WriteLine("\n1. Add Single");
            Console.Write("What would you like to do?");
            string input = Console.ReadLine().ToLower().Trim();

            switch (input)
            {
                case "add single":
                    AddSingleToCart(cart);
                    break;

                default:
                    Console.WriteLine($"I don't understand! \'{input}\'");
                    break;
            }
        }

        private static void AddSingleToCart(ShoppingCart cart)
        {
            throw new NotImplementedException();
        }
    }
}
