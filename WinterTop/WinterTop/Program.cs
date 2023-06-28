using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterTop
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(200, 62);

            Scene draw_Ui = new Scene();

            draw_Ui.Draw_Sene();
            draw_Ui.Draw_Title();

        }
    }
}
