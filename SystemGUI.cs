using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleMIDI
{
  
    //子菜单Struct
    struct SubMenus
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;
        public bool Taken;
    }

    class SystemGUI
    {
        public static ConsoleColor SystemBackGround;

        public static String[] TopMenuItems = new String[3];
        public static String[] FileMenuItems = new String[3];
        public static String[] ViewMenuItems = new String[2];

        public static SubMenus[] SubMenuHandle = new SubMenus[10];



        public static void Welcome()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(ConsoleMIDI.Properties.Resources.Title);
            Console.SetCursorPosition(125, 10);
            Console.WriteLine("Ver 0.0.1");
            Console.SetCursorPosition(125, 11);
            Console.WriteLine("ブンチョウ-プロジェクト");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to init the system...");
        }

        public static void Init()
        {
            Console.BackgroundColor = SystemBackGround;

            Console.Clear();
            ConstractMenuItems();

            

        }
        public static void DrawBar(int x, int y, int value)
        {

          
            Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine(name);

            if (value > 19) value = 19;

            // string ScreenBuffer ="";

            Console.SetCursorPosition(x, y);
            for (int i = 0; i < value; i++)
            {
                Console.Write("▆");
                Console.SetCursorPosition(x, y--);
            }



        }


        public static void ConstractMenuItems()//菜单构造函数
        {
            TopMenuItems[0] = "Files";
            TopMenuItems[1] = "View";
            TopMenuItems[2] = "Help";
            //----------------------------------------------------
            FileMenuItems[0] = "Open";
            FileMenuItems[1] = "Open Folder";
            FileMenuItems[2] = "Exit";
            //----------------------------------------------------
            ViewMenuItems[0] = "GUI...";
            ViewMenuItems[1] = "Settings";
        }
        //功能函数
        public static int GetArraysTotalLength(String[] Get)
        {

            int totalLength = 0;
         
            for(int i= 0; i < Get.GetUpperBound(0)+1; i++)
            {
                totalLength += Get[i].Length;
            }

          
            return totalLength;
        }
        /*
             ==================== [ 判断菜单是否占用 ] ====================
        */

        public static int GetSubMenuFreeSlot()
        {
            for (int i = 0; i< SubMenuHandle.GetLength(0);i++)
            {
                if (!SubMenuHandle[i].Taken) return i;
            }
            return -1;
        }
        /*
            ==================== [ GUI绘制函数 ] ====================
        */

        public static bool DestroyMenu(int HandleID)
        {

            Console.SetCursorPosition(SubMenuHandle[HandleID].X, SubMenuHandle[HandleID].Y);

            int Width = SubMenuHandle[HandleID].Width;
            int Height = SubMenuHandle[HandleID].Height;

            for (int p = 0; p < Height+3; p++)
            {
                for (int i = 0; i < Width * 2 + 3; i++)
                {
                    Console.BackgroundColor = SystemBackGround;
                    Console.Write(" ");

                }
                Console.SetCursorPosition(SubMenuHandle[HandleID].X, SubMenuHandle[HandleID].Y+p);
            }
  



            return true;
        }
        //绘制子菜单
        public static int DrawSubMenu(int x, int y,int width,String[] items)
        {
            //判断能否构造

            int Slot = GetSubMenuFreeSlot();
            if (GetSubMenuFreeSlot() == -1) return -1;

            Console.SetCursorPosition(x, y);
            Console.Write("┏");

            //绘制 ┏━━━━━━━━━━━━━━━━┓ 部分
         
            for(int i = 0;i < width;i++)
            {
                if(i == width -1) Console.Write("┓");
                else Console.Write("━");
            }
            Console.SetCursorPosition(x, y + 1);
            //绘制子菜单项目 ┃
      
            for (int i = 0; i < items.GetUpperBound(0)+1;i++)
            {
                string Draw = "┃ " + items[i].ToString();
                Console.Write(Draw);

                // Console.WriteLine(Draw.Length);
                
                Console.SetCursorPosition(x+ width*2, y + i+1);
                Console.Write("┃");
                
                Console.SetCursorPosition(x+1 + Draw.Length, y + i + 1);
                int LeftSpace = width*2  - Draw.Length;
               

                for (int s = 0;s < LeftSpace-1; s++)
                {
           
                    Console.Write(" ");
                }
                

                //光标移下
                Console.SetCursorPosition(x, y +i+2);
               
            }
            //Console.WriteLine("Im here");
            //绘制最低线条

            Console.Write("┗");
            for (int e = 0; e < width; e++)
            {
                if (e == width - 1) Console.Write("┛");
                else Console.Write("━");
            }
            //绘制阴影部分(横向)
            Console.SetCursorPosition(x+1, y+ items.GetUpperBound(0) +3); //移动光标

            for (int sv = 0;sv < width*2+2; sv++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");

            }
            Console.SetCursorPosition(x+width*2+2,y+1); //移动光标
            for (int sh =0; sh < items.Length*2 +1; sh++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
                Console.SetCursorPosition(x + width * 2 + 2, y+sh);
            }
            //讯息赋值
            SubMenuHandle[Slot].Width = width;
            SubMenuHandle[Slot].Height = items.GetUpperBound(0) + 2;
            SubMenuHandle[Slot].Taken = true;
            SubMenuHandle[Slot].X = x;
            SubMenuHandle[Slot].Y = y;

            return Slot;
        }
        public static void DrawTopMenu()
        {
            //移动光标到最上面
            Console.SetCursorPosition(0, 0);
            //设置背景色
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            //遍历绘制文本
        
            //填满文本
            Console.BufferWidth = Console.WindowWidth;
            /*
            for (int i = 0; i < TopMenuItems.Length -1; i++)
            {
                Console.Write("  " + TopMenuItems[i]);
            }*/
            int Stringsize = GetArraysTotalLength(TopMenuItems) + 2 * (TopMenuItems.GetUpperBound(0));
            
   
            for(int i = 0;i< Console.BufferWidth - Stringsize; i++)
            {
                if(i < TopMenuItems.GetUpperBound(0) + 1 && TopMenuItems[i] != null) Console.Write("  " + TopMenuItems[i]);
                else Console.Write(" ");

            }
            //DrawSubMenu(0,1,10, FileMenuItems);
          //  DestroyMenu(0);

        }
    }
}
