using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterTop
{
    public class MainPlay
    {
        Scene draw_Ui = new Scene();        
        Battle battle = new Battle();
        PlayerInfo player = new PlayerInfo();
        RandomBuff random_Buff = new RandomBuff();

        public void Play_Game()
        {
            double player_Hp = 150;
            double player_Max_Hp = 150;
            double player_Atk = 500;
            double critical_damage = player_Atk * 1.5;
            int critical_Chance = 5;
            int evasion_Chance = 3;

            critical_damage = Math.Truncate(critical_damage);

            int stage_Count = 0;
            int last_Stage = 8;
            int boss_Count = 0;
            
            // 메인 반복 시작지점

            while (true)
            {
                draw_Ui.Draw_Scene();
                draw_Ui.main_info();


                Console.SetCursorPosition(145, 43);
                Console.Write(" < 여 정 의 길 >");
                Console.SetCursorPosition(136, 45);
                Console.Write(" [ 현재 층 ] : {0} 층", stage_Count);
                Console.SetCursorPosition(136, 47);
                Console.Write(" [ 정   상 ] : {0} 층", last_Stage);

                Console.SetCursorPosition(105, 15);
                Console.WriteLine("Main Scene");

                Console.SetCursorPosition(148, 51);
                Console.Write(" < 메 뉴 > ");
                Console.SetCursorPosition(136, 54);
                Console.Write(" [ 캐 릭 터 정 보 창 ] : I");
                Console.SetCursorPosition(136, 56);
                Console.Write(" [  게  임   종  료  ] : ESC");

                Console.SetCursorPosition(70, 46);
                Console.Write("분기점 1 : 노 패널티, 스텟 미약하게 강화");
                Console.SetCursorPosition(70, 49);
                Console.Write("분기점 2 : 랜덤 패널티, 중간단계 스텟 강화");
                Console.SetCursorPosition(70, 52);
                Console.Write("분기점 3 : 체력 회복?");

                

                Console.WriteLine();
                
                ConsoleKeyInfo user_Input = Console.ReadKey();

                if(user_Input.Key == ConsoleKey.I)      // 플레이어 정보창 열기
                {
                    player.Draw_Info_Window();
                    player.Charactor_Info(ref player_Hp, ref player_Max_Hp, ref player_Atk,
                        ref critical_Chance, ref evasion_Chance, ref stage_Count);
                }
                else if(user_Input.Key == ConsoleKey.Escape)    // 게임 종료
                {
                    return;
                }
                else if(user_Input.Key == ConsoleKey.D1)    // 분기점 1 선택
                {
                    random_Buff.Select_1(ref player_Atk, ref critical_Chance, ref evasion_Chance,
                        ref player_Max_Hp, ref player_Hp);      // 버프를 먼저 받고

                    battle.Play_Battle(ref player_Hp, ref player_Max_Hp, ref player_Atk, ref critical_damage,
                        ref critical_Chance, ref evasion_Chance, ref stage_Count, ref last_Stage, ref boss_Count);
                                                                // 전투를 시작하게 된다.
                    if (player_Hp <= 0)
                    {
                        Console.SetCursorPosition(110, 25);
                        Console.Write("플레이어 사망...");
                        return;
                    }
                    else if (boss_Count == 1 && player_Hp >= 0)
                    {
                        Console.SetCursorPosition(110, 25);
                        Console.Write("게임 승리!");

                        Console.ReadKey();
                        return;
                    }
                }
                else if (user_Input.Key == ConsoleKey.D2)
                {
                    random_Buff.Select_2(ref player_Hp, ref player_Atk, ref critical_Chance, ref evasion_Chance);

                    battle.Play_Battle(ref player_Hp, ref player_Max_Hp, ref player_Atk, ref critical_damage,
                        ref critical_Chance, ref evasion_Chance, ref stage_Count, ref last_Stage, ref boss_Count);

                    if (player_Hp <= 0)
                    {
                        Console.SetCursorPosition(110, 25);
                        Console.Write("플레이어 사망...");
                        return;
                    }
                    else if (boss_Count == 1 && player_Hp >= 0)
                    {
                        Console.SetCursorPosition(110, 25);
                        Console.Write("게임 승리!");

                        Console.ReadKey();
                        return;
                    }
                }
                else if (user_Input.Key == ConsoleKey.D3)
                {
                    random_Buff.Select_3(ref player_Hp, ref player_Max_Hp);
                    
                    battle.Play_Battle(ref player_Hp, ref player_Max_Hp, ref player_Atk, ref critical_damage,
                        ref critical_Chance, ref evasion_Chance, ref stage_Count, ref last_Stage, ref boss_Count);

                    if (player_Hp <= 0)
                    {
                        Console.SetCursorPosition(110, 25);
                        Console.Write("플레이어 사망...");
                        return;
                    }
                    else if (boss_Count >= 1 && player_Hp >= 0)
                    {
                        Console.SetCursorPosition(110, 25);
                        Console.Write("게임 승리!");

                        Console.ReadKey();
                        return;
                    }
                }

            }

            // 메인 반복 종료지점
            
        }
    }
}
