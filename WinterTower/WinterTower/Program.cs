﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinterTower
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(240, 62);

            Scene draw_Ui = new Scene();

            draw_Ui.Darw_Background();
            draw_Ui.Draw_Scene();            
            draw_Ui.Draw_TitlePainting();
            Thread.Sleep(1000);
            draw_Ui.Draw_Title();

        }
    }
}
