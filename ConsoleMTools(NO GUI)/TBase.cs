using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace ConsoleMTools_NO_GUI_
{
     
    public static class TBase
    {
        public static bool disableMon = false;
        public static string choice;
        public static bool runSysMonWithAlerts; // Will impl. this later, not our focus right now

        public static string sysmonCounterDataSet;


        static void Main(string[] args)
        {
            openMain();
            
            if (choice == "1") //To run sysmon with alerts
            {
                //Confirmation
                Console.WriteLine("You chose to run sysmon with alerts. Are you sure? (y/n)");
                string c1con = Console.ReadLine();
                //Get number of counters here
                Console.WriteLine("How many counters would you like to use (CPU AND MEM only supp. right now)\n");
                string c1Xcnum = Console.ReadLine();
                Thread.Sleep(100);

                Console.WriteLine("Please give the counter dataset sep. by commas");
                sysmonCounterDataSet = Console.ReadLine();

            }

            if (choice == "3") //For running a plain old process
            {
                Console.WriteLine("What process would you like to run(exe file)");
                string processOpen = Console.ReadLine();
                Console.WriteLine("Running " + processOpen + "...");
                Thread.Sleep(200);
                runProcessWithoutURLOpener(processOpen);
                openMain();
            }

            if (choice == "4") // For running a process with a URL
            {
                Console.WriteLine("Please enter the file you want to run: ");
                string processOpen2 = Console.ReadLine();
                Console.WriteLine("Please enter the URL you want to use: ");
                string processOpen2URL = Console.ReadLine();
                Console.WriteLine("Opening " + processOpen2 + " with URL: " + processOpen2URL);
                Thread.Sleep(200);
                runProcessWithURL(processOpen2URL, processOpen2URL);
               
            }
        }
        public static void openMain() {
            //Opening
            Console.WriteLine("Welcome to MTools v1.0 Beta CMD edition (GUI is coming later)\n");
            Thread.Sleep(200);
            //test for version control
            //Options for Tools
            Console.WriteLine("Choose what tool you need:\n 1) Run sysmon(with alerts)\n 2) Run sysmon (without alerts NOT AVAIL.)\n 3) Run a process\n 4) Run a browser witha URL\n 5) Run a strip down browser(with IE render)\n");
            choice = Console.ReadLine();
        }
        
        //Function to create a process and run sysmon
        public static void runSysMonProcess(string arg = null) //For alerts (impl later)
        {

            Process sysMonAProcess = new Process();
            sysMonAProcess.StartInfo.FileName = "MTools + Jarvis.exe";

        }  

        //Function for running a process without a URL
        public static void runProcessWithoutURLOpener(string fileName)
        {
            Process processWithoutURL = new Process();
            processWithoutURL.StartInfo.FileName = fileName;
            processWithoutURL.Start();
            
        }

        public static void runProcessWithURL(string file, string url) {
            Process processURL = new Process();
            processURL.StartInfo.FileName = file;
            processURL.StartInfo.Arguments = url;
            processURL.Start();


        }
    
    } // class
} // namespace
