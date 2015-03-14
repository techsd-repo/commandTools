using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Speech.Synthesis;
using ConsoleMTools_NO_GUI_;
using System.Text.RegularExpressions;




namespace MTools___Jarvis
{
    public class Program
    {

        private static SpeechSynthesizer synth = new SpeechSynthesizer();
        
        //Where all the magic happens
        static void Main(string[] args)
        {
            if (TBase.disableMon == false)
            {
                #region perfc
                //m-cpu counter
                PerformanceCounter perfCpuCount = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
                perfCpuCount.NextValue();
                //m-mem counter
                PerformanceCounter perfMemoryCount = new PerformanceCounter("Memory", "Available MBytes");
                perfMemoryCount.NextValue();
                //m-uptime counter
                PerformanceCounter perfUptimeCount = new PerformanceCounter("System", "System Up Time");
                perfUptimeCount.NextValue();
                #endregion

               


                SpeakAPI("Welcome to Jarvis one point oh!", VoiceGender.Male);

                TimeSpan uptimeSpan = TimeSpan.FromSeconds(perfUptimeCount.NextValue());
                string vocalUptime = String.Format("The current system uptime is {0} days {1} hours {2} minutes and {3} seconds",
                    (int)uptimeSpan.TotalDays,
                    (int)uptimeSpan.Hours,
                    (int)uptimeSpan.Minutes,
                    (int)uptimeSpan.Seconds);
                SpeakAPI(vocalUptime, VoiceGender.Male);

                while (true)
                {
                    float currCpuPer = perfCpuCount.NextValue();
                    float currAvaMem = perfMemoryCount.NextValue();

                    //Searching the TBase.sysmonCounterDataSet for the counters
                    bool sysmonData1 = Regex.IsMatch(TBase.sysmonCounterDataSet, "\bcpu\b");
                    bool sysmonData2 = Regex.IsMatch(TBase.sysmonCounterDataSet, "\bmem\b");

                    if (sysmonData1 == true)
                    {
                        //CPU update code here
                    }

                    if (sysmonData2 == true)
                    {
                        //Memory update code here
                    }

                    Console.WriteLine("CPU Load {0}%", currCpuPer);
                    if (currCpuPer > 70)
                    {
                        //CPU 100
                        if (currCpuPer == 100)
                        {
                            //Speak 100
                            string cpuLoadVocal = String.Format("WARNING: Your CPU is about to catch fire!!");
                            SpeakAPI(cpuLoadVocal, VoiceGender.Male, 3);
                        }
                        else
                        {
                            //Else: if cpuLoad > 70 speak current
                            string cpuLoadVocal = String.Format("The current CPU load is {0}%", (int)currCpuPer);
                            SpeakAPI(cpuLoadVocal, VoiceGender.Male, 2);
                        }

                        //Memoy Handle
                        Console.WriteLine("Avail. Mem: {0}MB", currAvaMem);
                        Thread.Sleep(1000);
                        //Logic
                        if (currCpuPer > 70)
                        {
                            if (currCpuPer == 100)
                            {
                                string cpuLoadVocal = String.Format("WARNING: Your CPU is about to catch fire!!");
                                SpeakAPI(cpuLoadVocal, VoiceGender.Male, 3);
                            }
                            else
                            {
                                string cpuLoadVocal = String.Format("The current CPU load is {0}%", (int)currCpuPer);
                                SpeakAPI(cpuLoadVocal, VoiceGender.Male, 2);
                            }
                        }
                        if (currAvaMem < 850)
                        {
                            string memAvaVocal = String.Format("You have {0}Megabytes of memory ", (int)currAvaMem);
                            SpeakAPI(memAvaVocal, VoiceGender.Male, 2);
                        }

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