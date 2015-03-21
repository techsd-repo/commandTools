using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MTools___Jarvis
{
    public static class Startup
    {
        public static string c1Xcnum;
        public static string dataset = " ";
        public static string sysmonWithAlerts;
       
        public static void runStartup()
        {
            Console.WriteLine("How many counters would you like to use (cpu, mem, phydisk)\n");
            c1Xcnum = Console.ReadLine();
            Thread.Sleep(100);

            Console.WriteLine("Please give the counter dataset sep. by commas");
            dataset = Console.ReadLine();
            Thread.Sleep(100);

            Console.WriteLine("Do you want to run sysmon with alerts? (y/n)");
            sysmonWithAlerts = Console.ReadLine();
            Thread.Sleep(100);

        }
    }

   
}