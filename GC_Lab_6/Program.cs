using System;

namespace GC_Lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            store.Shopping();
            store = null;
        }
    }
}
