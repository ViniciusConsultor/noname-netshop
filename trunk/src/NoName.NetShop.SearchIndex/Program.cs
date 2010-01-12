using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using NoName.NetShop.Search;

namespace NoName.NetShop.SearchIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            DataProcessor.Process("product");
            Console.Read();
        }
    }
}
