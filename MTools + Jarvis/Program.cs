using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Speech.Synthesis;
using ConsoleMTools_NO_GUI_;
using MTools___Jarvis;
using System.Text.RegularExpressions;




namespace MTools___Jarvis
{
   
    public class Program
    {

        private static SpeechSynthesizer synth = new SpeechSynthesizer();
        
        //Where all the magic happens
        static void Main(string[] args)
        {
            Startup.runStartup();           
            if (TBase.disableMon == false)
            {
                #region perfCounters
                //m-cpu counter
                PerformanceCounter perfCpuCount = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
                perfCpuCount.NextValue();
                //m-mem counter
                PerformanceCounter perfMemoryCount = new PerformanceCounter("Memory", "Available MBytes");
                perfMemoryCount.NextValue();
                //m-uptime counter
                PerformanceCounter perfUptimeCount = new PerformanceCounter("System", "System Up Time");
                perfUptimeCount.NextValue();
                PerformanceCounter perfDiskCount = new PerformanceCounter("PhysicalDisk", "Disk Bytes/sec", "_Total");
                perfDiskCount.NextValue();
                #endregion

                #region uptimeIntro
                SpeakAPI("Welcome to Jarvis one point oh!", VoiceGender.Male);

                TimeSpan uptimeSpan = TimeSpan.FromSeconds(perfUptimeCount.NextValue());
                string vocalUptime = String.Format("The current system uptime is {0} days {1} hours {2} minutes and {3} seconds",
                    (int)uptimeSpan.TotalDays,
                    (int)uptimeSpan.Hours,
                    (int)uptimeSpan.Minutes,
                    (int)uptimeSpan.Seconds);
                SpeakAPI(vocalUptime, VoiceGender.Male);
                #endregion

                while (true)
                {
                    float currCpuPer = perfCpuCount.NextValue();
                    float currAvaMem = perfMemoryCount.NextValue();
                    float currDisk = perfDiskCount.NextValue();
                    


                    //Searching the Startup.dataset for the counters
                    bool sysmDatacpu = Regex.IsMatch(Startup.dataset, "\bcpu\b");
                    bool sysmDatamem = Regex.IsMatch(Startup.dataset, "\bmem\b");
                    bool sysmDataphydisk = Regex.IsMatch(Startup.dataset, "\bphydisk\b");

                    bool sysmonAlerts = Regex.IsMatch(Startup.sysmonWithAlerts, "\by\b");

                    #region cpuCounter
                    if (sysmDatacpu == true)
                    {
                        //CPU update code here
                        Console.WriteLine("CPU Load {0}%", currCpuPer);
                        if (currCpuPer > 70)
                        {
                            //CPU 100
                            if (currCpuPer == 100)
                            {
                                if (sysmonAlerts == true)
                                {
                                    //Speak 100
                                    string cpuLoadVocal = String.Format("WARNING: Your CPU is about to catch fire!!");
                                    SpeakAPI(cpuLoadVocal, VoiceGender.Male, 3);
                                }
                                
                            }
                            else
                            {
                                if (sysmonAlerts == true)
                                {
                                     //Else: if cpuLoad > 70 speak current
                                string cpuLoadVocal = String.Format("The current CPU load is {0}%", (int)currCpuPer);
                                SpeakAPI(cpuLoadVocal, VoiceGender.Male, 2);
                                }
                            }
                        }
                    #endregion

                        #region memCounter
                        if (sysmDatamem == true)
                    {
                        //Memory update code here

                        //Memoy Handle
                        Console.WriteLine("Avail. Mem: {0}MB", currAvaMem);
                        Thread.Sleep(1000);
                        //Logic
                        if (currAvaMem < 850)
                        {
                            if (sysmonAlerts == true)
                            {
                                string memAvaVocal = String.Format("You have {0}Megabytes of memory ", (int)currAvaMem);
                                SpeakAPI(memAvaVocal, VoiceGender.Male, 2);    
                            }
                            
                        }

                    }
                        #endregion

                        #region Disk Counter
                        //Logic

                        if (sysmDataphydisk == true)
                        {
                            Console.WriteLine("Disk Usage: {0} bytes/sec", currDisk);

                            if (currDisk > 475)
                            {
                                string phyDiskVocal = string.Format("Your current disk usage is {0} bytes per second", currDisk);
                                SpeakAPI(phyDiskVocal, VoiceGender.Male, 2);
                            }
                        }
                        
                        #endregion
                    }
                    Thread.Sleep(1000);
                }//end of loop
            }
        }
        #region functions
        //Speak function(API)
        public static void SpeakAPI(string message, VoiceGender voiceGender)
        {
            synth.SelectVoiceByHints(voiceGender);
            synth.Speak(message);
        }
        //Override (so if you don't want to change the rate, you have that option)
        public static void SpeakAPI(string message, VoiceGender voiceGender, int rate)
        {
            synth.Rate = rate;
            SpeakAPI(message, voiceGender);
        }

        public static void OpenProcess(string exe)
        {
            Process p1 = new Process();
            p1.StartInfo.FileName = exe;

        }


    }
}
        #endregion