using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterTop
{
    public class MainPlay
    {
        Sene draw_Ui = new Sene();        
        Battle battle = new Battle();
        PlayerInfo player = new PlayerInfo();
        RandomBuff random_Buff = new RandomBuff();
        

        public void Play_Game()
        {
            int player_Hp = 150;
            int player_Atk = 15;
            int critical_damage = player_Atk * 2;
            int critical_Chance = 5;
            int heal = 7;
            int heal_Chance = 20;

            int stage_Count = 0;

            

            while (true)
            {
                draw_Ui.Draw_Sene();

                Console.SetCursorPosition(10, 1);
                Console.Write("캐릭터 체력 : {0}", player_Hp);
                Console.SetCursorPosition(90, 1);
                Console.Write("스테이지 : {0} / 4", stage_Count);

                Console.SetCursorPosition(55, 5);
                Console.WriteLine("Main Sene");

                Console.SetCursorPosition(45, 10);
                Console.Write("여기부터");
                Console.SetCursorPosition(45, 30);
                Console.Write("여기까지 스토리?, 혹은 캐릭터?");

                Console.SetCursorPosition(40, 40);
                Console.Write("분기점 1 : 노 패널티, 스텟 미약하게 강화");
                Console.SetCursorPosition(40, 42);
                Console.Write("분기점 2 : 랜덤 패널티, 중간단계 스텟 강화");
                Console.SetCursorPosition(40, 44);
                Console.Write("분기점 3 : 어떤 분기점을 넣을까....");

                Console.SetCursorPosition(2, 52);
                Console.Write("게임 종료 : ESC \t\t\t\t\t\t\t\t\t\t   캐릭터 정보창 : I");

                Console.WriteLine();
                
                ConsoleKeyInfo user_Input = Console.ReadKey();

                if(user_Input.Key == ConsoleKey.B)
                {
                    battle.Play_Battle(ref player_Hp,ref player_Atk, ref critical_damage, 
                        ref critical_Chance, ref heal, ref heal_Chance, ref stage_Count);

                    if (player_Hp <= 0)
                    {
                        return;
                    }

                    stage_Count++;
                }
                else if(user_Input.Key == ConsoleKey.I)
                {
                    player.Draw_Info_Window();
                    player.Charactor_Info();
                }
                else if(user_Input.Key == ConsoleKey.Escape)
                {
                    return;
                }
                else if(user_Input.Key == ConsoleKey.D1)
                {
                    random_Buff.Select_1(ref player_Atk, ref critical_Chance);
                }
                else if (user_Input.Key == ConsoleKey.D2)
                {
                    random_Buff.Select_2(ref player_Hp, ref player_Atk, ref critical_Chance);
                }
                else if (user_Input.Key == ConsoleKey.D3)
                {

                }


            }
            

        }
    }
}
