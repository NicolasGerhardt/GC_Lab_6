using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Lab_6
{
    public class Product
    {
        private string songName;
        private string category;
        private string artist;
        private double price;
        
        public string RapSheet { get { return category + ", " + songName + ", " + artist + ", " + price; } }

        public Product(string songName, string category, string artist, double price)
        { 
            this.songName = songName;
            this.category = category;
            this.artist = artist;
            this.price = price;
           
        }

        public Product()
        {

        }

        public string SongName { get => songName; set => songName = value; }
        public string Category { get => category; set => category = value; }
        public string Artist { get => artist; set => artist = value; }
        public double Price { get => price; set => price = value; }
       
    }
}
