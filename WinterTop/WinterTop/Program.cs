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
            Console.SetWindowSize(120, 55);

            Sene draw_Ui = new Sene();

            draw_Ui.Draw_Sene();
            draw_Ui.Draw_Title();


        }
    }
}
