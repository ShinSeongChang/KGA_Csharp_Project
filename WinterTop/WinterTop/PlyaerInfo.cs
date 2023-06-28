using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterTop
{

    public class PlayerInfo
    {
        public void Draw_Info_Window()
        {
            
            Console.SetCursorPosition(75, 10);
            Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(75, 11);
            Console.WriteLine("│  ┌──────────────────────────────────────────┐                             │");
            Console.SetCursorPosition(75, 12);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 13);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 14);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 15);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 16);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 17);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 18);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 19);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 20);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 21);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 22);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 23);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 24);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 25);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 26);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 27);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 28);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 29);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 30);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 31);
            Console.WriteLine("│  └──────────────────────────────────────────┘                             │");
            Console.SetCursorPosition(75, 32);
            Console.WriteLine("│                                                                           │");
            Console.SetCursorPosition(75, 33);
            Console.WriteLine("│                                                                           │");
            Console.SetCursorPosition(75, 34);
            Console.WriteLine("│                                                                           │");
            Console.SetCursorPosition(75, 35);
            Console.WriteLine("│                                                                           │");
            Console.SetCursorPosition(75, 36);
            Console.WriteLine("│                                                                           │");
            Console.SetCursorPosition(75, 37);
            Console.WriteLine("└───────────────────────────────────────────────────────────────────────────┘");            
            
        }

        public void Charactor_Info(ref double hp, ref double max_hp, ref double atk, ref int cri, ref int evasion)
        {
            Console.SetCursorPosition(125, 11);
            Console.Write(" 체력   : {0} / {1}", hp, max_hp);
            Console.SetCursorPosition(125, 13);
            Console.Write(" 공격력 : {0}", atk);
            Console.SetCursorPosition(125, 15);
            Console.Write(" 회피율 : {0} %", evasion);
            Console.SetCursorPosition(125, 17);
            Console.Write(" 크리티컬 확률 : {0} % ", cri);
            Console.SetCursorPosition(79, 32);
            Console.Write("<스킬 슬롯>");
            Console.SetCursorPosition(79, 34);
            Console.Write("(비어 있음)");

            Console.SetCursorPosition(119, 0);
            Console.ReadKey();
        }

    }
}
