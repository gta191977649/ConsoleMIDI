using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Un4seen.Bass;
using System.Diagnostics;
using System.Timers;

namespace ConsoleMIDI
{
    class Program
    {
        public static int StreamHandle;
        private static Un4seen.Bass.Misc.Visuals Visuals = new Un4seen.Bass.Misc.Visuals();
        public static Double[] data = new Double[16];
        static void Main(string[] args)
        {

            Console.CursorVisible = false;
            Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;
            // Console.WriteLine(Properties.Resources.MIDITITLE);
            SystemGUI.Welcome();


            
            
            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);


            string URL = Console.ReadLine();
            StreamHandle = Bass.BASS_StreamCreateFile(URL, 0, 0, 0);

            Bass.BASS_ChannelPlay(StreamHandle, false);


            System.Timers.Timer myTimer = new System.Timers.Timer();
            myTimer.Elapsed += new ElapsedEventHandler(OnHandleSpecturm);
            myTimer.Interval = 33.33333333;
            myTimer.Enabled = true;
           

            Console.ReadLine();
            /*
            
            ConsoleKeyInfo cki;
            do
            {
                cki = Console.ReadKey();
                SystemKeyDetectMainLoop(cki);

            } while (cki.Key != ConsoleKey.Escape);

    */
        }

        public static void OnHandleSpecturm(Object source, ElapsedEventArgs e)
        {
            // Un4seen.BassWasapi.det
          


            /* Console.WriteLine("GET DATA:" +freq);
             Console.WriteLine("GET DATA ROUND:" + Math.Round(freq * 10));
             */
            data[0] = Visuals.DetectFrequency(StreamHandle, 20, 40, true);
            data[1] = Visuals.DetectFrequency(StreamHandle,50, 70, true);
            data[2] = Visuals.DetectFrequency(StreamHandle, 80,120, true);
            data[3] = Visuals.DetectFrequency(StreamHandle, 130, 150, true);
            data[4] = Visuals.DetectFrequency(StreamHandle, 160, 190, true);
            data[5] = Visuals.DetectFrequency(StreamHandle, 200,220, true);
            data[6] = Visuals.DetectFrequency(StreamHandle, 210, 250, true);
            data[7] = Visuals.DetectFrequency(StreamHandle, 260, 280, true);
            data[8] = Visuals.DetectFrequency(StreamHandle, 290, 310, true);

            data[9] = Visuals.DetectFrequency(StreamHandle,320,340, true);
            data[10] = Visuals.DetectFrequency(StreamHandle,350, 370, true);
            data[11] = Visuals.DetectFrequency(StreamHandle, 380, 400, true);
            data[12] = Visuals.DetectFrequency(StreamHandle,410, 430, true);
            data[13] = Visuals.DetectFrequency(StreamHandle,440, 460, true);
            data[14] = Visuals.DetectFrequency(StreamHandle,470, 490, true);
            data[15] = Visuals.DetectFrequency(StreamHandle,500, 520, true);

            // DrawBars(0,Convert.ToInt16(data)*10);
            //   Console.WriteLine(data*100);

            Console.Clear();
            SystemGUI.Welcome();
            SystemGUI.DrawBar(0, 30, Convert.ToInt16(Math.Round(data[0] * 100)));
            SystemGUI.DrawBar(2, 30, Convert.ToInt16(Math.Round(data[1] * 100)));
            SystemGUI.DrawBar(4, 30, Convert.ToInt16(Math.Round(data[2] * 100)));
            SystemGUI.DrawBar(6, 30, Convert.ToInt16(Math.Round(data[3] * 100)));
            SystemGUI.DrawBar(8, 30, Convert.ToInt16(Math.Round(data[4] * 100)));
            SystemGUI.DrawBar(10, 30, Convert.ToInt16(Math.Round(data[5] * 100)));
            SystemGUI.DrawBar(12, 30, Convert.ToInt16(Math.Round(data[6] * 100)));
            SystemGUI.DrawBar(14, 30, Convert.ToInt16(Math.Round(data[7] * 100)));

            SystemGUI.DrawBar(16, 30, Convert.ToInt16(Math.Round(data[8] * 100)));
            SystemGUI.DrawBar(18, 30, Convert.ToInt16(Math.Round(data[9] * 100)));
            SystemGUI.DrawBar(20, 30, Convert.ToInt16(Math.Round(data[10] * 100)));
            SystemGUI.DrawBar(22, 30, Convert.ToInt16(Math.Round(data[11] * 100)));
            SystemGUI.DrawBar(24, 30, Convert.ToInt16(Math.Round(data[12] * 100)));
            SystemGUI.DrawBar(26, 30, Convert.ToInt16(Math.Round(data[13] * 100)));
            SystemGUI.DrawBar(28, 30, Convert.ToInt16(Math.Round(data[14] * 100)));
            SystemGUI.DrawBar(30, 30, Convert.ToInt16(Math.Round(data[15] * 100)));
            /*
            SystemGUI.DrawBar(7, 20, 0);
            */
        }

        public static void Init()
        {
            SystemGUI.SystemBackGround = ConsoleColor.DarkBlue;

            SystemGUI.Init();


            SystemGUI.DrawTopMenu();
        }

        public static void Refreash()
        {
            Console.Clear();
            SystemGUI.Init();
            SystemGUI.DrawTopMenu();
        }

        public static void SystemKeyDetectMainLoop(ConsoleKeyInfo info)
        {
            Refreash();
            if (info.Key == ConsoleKey.F1) SystemGUI.DrawSubMenu(0, 1, 10, SystemGUI.FileMenuItems);
            if (info.Key == ConsoleKey.F2) SystemGUI.DrawSubMenu(8, 1, 10, SystemGUI.ViewMenuItems);

            
        }
        
 
    }
}
