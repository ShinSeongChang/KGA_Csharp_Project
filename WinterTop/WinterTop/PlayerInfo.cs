using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterTop
{

    public class PlayerInfo
    {

        public void Draw_Info_Window()
        {
            
            Console.SetCursorPosition(75, 3);
            Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(75, 4);
            Console.WriteLine("│  ┌──────────────────────────────────────────┐                             │");
            Console.SetCursorPosition(75, 5);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 6);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 7);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 8);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 9);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 10);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 11);
            Console.WriteLine("│  │                                          │                             │");
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
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 32);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 33);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 34);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 35);
            Console.WriteLine("│  │                                          │                             │");
            Console.SetCursorPosition(75, 36);
            Console.WriteLine("│  └──────────────────────────────────────────┘                             │");
            Console.SetCursorPosition(75, 37);
            Console.WriteLine("└───────────────────────────────────────────────────────────────────────────┘");            
            
        }

        public void Charactor_Info(ref double hp, ref double max_hp, ref double atk, ref int cri, ref int evasion, ref int stage_Count, ref int skil_Addcount)
        {           

            if(stage_Count >= 6)
            {
                Console.SetCursorPosition(130, 5);
                Console.Write(" < 능 력 치 >");
                Console.SetCursorPosition(125, 8);
                Console.Write(" 체력   : {0} / {1}", hp, max_hp);
                Console.SetCursorPosition(125, 10);
                Console.Write(" 공격력 : {0}", atk);
                Console.SetCursorPosition(125, 12);
                Console.Write(" 회피율 : {0} %", evasion);
                Console.SetCursorPosition(125, 14);
                Console.Write(" 크리티컬 확률 : {0} % ", cri);
                Console.SetCursorPosition(130, 18);
                Console.Write("< 스 킬 슬 롯 >");
                Console.SetCursorPosition(130, 20);
                Console.Write(" 스 킬 1");
                Console.SetCursorPosition(130, 21);
                Console.Write(" 스 킬 2");
                Console.SetCursorPosition(130, 22);
                Console.Write(" 스 킬 3");

                

            }
            else if (stage_Count >= 4)
            {
                Console.SetCursorPosition(130, 5);
                Console.Write(" < 능 력 치 >");
                Console.SetCursorPosition(125, 8);
                Console.Write(" 체력   : {0} / {1}", hp, max_hp);
                Console.SetCursorPosition(125, 10);
                Console.Write(" 공격력 : {0}", atk);
                Console.SetCursorPosition(125, 12);
                Console.Write(" 회피율 : {0} %", evasion);
                Console.SetCursorPosition(125, 14);
                Console.Write(" 크리티컬 확률 : {0} % ", cri);
                Console.SetCursorPosition(130, 18);
                Console.Write("< 스 킬 슬 롯 >");
                Console.SetCursorPosition(130, 20);
                Console.Write(" 스 킬 1");
                Console.SetCursorPosition(130, 21);
                Console.Write(" 스 킬 2");

            }
            else if (stage_Count >= 2)
            {
                Console.SetCursorPosition(130, 5);
                Console.Write(" < 능 력 치 >");
                Console.SetCursorPosition(125, 8);
                Console.Write(" 체력   : {0} / {1}", hp, max_hp);
                Console.SetCursorPosition(125, 10);
                Console.Write(" 공격력 : {0}", atk);
                Console.SetCursorPosition(125, 12);
                Console.Write(" 회피율 : {0} %", evasion);
                Console.SetCursorPosition(125, 14);
                Console.Write(" 크리티컬 확률 : {0} % ", cri);
                Console.SetCursorPosition(130, 18);
                Console.Write("< 스 킬 슬 롯 >");
                Console.SetCursorPosition(130, 20);
                Console.Write(" 스 킬 1");

            }
            else //if(stage_Count <2)
            {
                Console.SetCursorPosition(130, 5);
                Console.Write(" < 능 력 치 >");
                Console.SetCursorPosition(125, 8);
                Console.Write(" 체력   : {0} / {1}", hp, max_hp);
                Console.SetCursorPosition(125, 10);
                Console.Write(" 공격력 : {0}", atk);
                Console.SetCursorPosition(125, 12);
                Console.Write(" 회피율 : {0} %", evasion);
                Console.SetCursorPosition(125, 14);
                Console.Write(" 크리티컬 확률 : {0} % ", cri);
                Console.SetCursorPosition(130, 18);
                Console.Write("< 스 킬 슬 롯 >");
                Console.SetCursorPosition(130, 20);
                Console.Write(" (비 어 있 음)");

            }

            //foreach(var skil in user_Skilname)
            //{                    
            //    Console.SetCursorPosition(129, y);
            //    Console.WriteLine("{0}", skil);
            //    y++;
            //}
            
        }

    }
}
