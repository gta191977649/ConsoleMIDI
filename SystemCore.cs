using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Un4seen.Bass;
using System.Diagnostics;
using System.Timers;
using Un4seen.Bass.Misc;
namespace ConsoleMIDI
{

    class SystemCore
    {
        protected static int origRow;
        protected static int origCol;
        
         
        public static int StreamHandle;
        private static Un4seen.Bass.Misc.Visuals BassV = new Un4seen.Bass.Misc.Visuals();
        public static void Init()//程序构造函数
        {

            Bass.BASS_PluginLoad("bass.dll");
           
        }



        public static void Play(string filepath)
        {
            Bass.BASS_Free();
            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            StreamHandle = Bass.BASS_StreamCreateFile(filepath, 0, 0, BASSFlag.BASS_DEFAULT);
           
            Bass.BASS_ChannelPlay(StreamHandle, false);
            Console.WriteLine("Created Steam:"+ filepath);
            //Draw Bars
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(DrawTimer);
            aTimer.Interval = 100;
            aTimer.Start();

            Console.CursorVisible = false;
        }
        private static void DrawTimer(object source, ElapsedEventArgs e)
        {
            
            //  BassV.DetectPeakFrequency(StreamHandle,out data);

            //  SystemGUI.DrawBars(0,10, Convert.ToInt16(Math.Round(data[1] * 100)));

        }
        public static void DrawBars(int Channel,int level)
        {
           
            int i,based=3;
            for (i = 20; i > level; i--)
            { 
                WriteAt("▇", Channel, based+i);
            }
            
        }
        protected static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.WriteLine(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
    }
}
