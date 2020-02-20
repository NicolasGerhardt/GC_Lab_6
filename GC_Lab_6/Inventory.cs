using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Lab_6
{
    public static class Inventory
    {
        public static Dictionary< Product, int> songs = new Dictionary<Product, int>()
        { 
            
            {new Product{SongName="Baby Got Back", Artist="Sir MixALot", Category="Hip-Hop", Price=30.00 },10 },
            {new Product{SongName="DevBuild",Artist="Riley",Category="Backend Flames",Price= 45.00},10 },
            {new Product{SongName="Africa",Artist="Toto",Category="Awful Sounds",Price= 45.00},10 },
            {new Product{SongName="Don't Stop Bel",Artist="Journey",Category="Alter",Price= 15.00},10 },
            {new Product{SongName="He Lives in You",Artist="Robert Robinson",Category="Gossip",Price= 145.00},10 },
            {new Product{SongName="BOB",Artist="Nic",Category="Freestyle",Price= 450.00},10 },
            {new Product{SongName="ROB",Artist="Ollie",Category="Freestyle",Price= 450.00},10 },
            {new Product{SongName="You Make me Wanna",Artist="Usher",Category="R&B",Price= 25.00},10 },
            {new Product{SongName="Monster",Artist="Skillet",Category="Rock",Price= 10.00},10 },
            {new Product{SongName="Wing$",Artist="Macklemore",Category="Hip-Hop",Price= 15.00},10 },
            {new Product{SongName="Overload",Artist="John Legend",Category="R&B",Price= 75.00},10 },
            {new Product{SongName="FreeStyle Friday Fire",Artist="Ollie",Category="Freestyle",Price= 745.00},10 },
            {new Product{SongName="Toss a Coin to Your Witcher",Artist="Bard",Category= "SoundTrack",Price= 5.00},10 },
                                 

        };

    }
}
