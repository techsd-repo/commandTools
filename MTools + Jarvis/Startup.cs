using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MTools___Jarvis
{
    class Startup
    {
        static void Main(string[] args)
        {
            string dataset;
            Console.WriteLine("How many counters would you like to use (CPU AND MEM only supp. right now)\n");
            string c1Xcnum = Console.ReadLine();
            Thread.Sleep(100);

            Console.WriteLine("Please give the counter dataset sep. by commas");
            dataset = Console.ReadLine();
        }
    }
}