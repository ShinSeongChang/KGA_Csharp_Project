using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterTower
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
            double player_Atk = 300;
            double critical_damage = player_Atk * 1.5;
            int critical_Chance = 90;
            int evasion_Chance = 3;

            critical_damage = Math.Truncate(critical_damage);

            int stage_Count = 0;
            int last_Stage = 8;
            int boss_Count = 0;
            int skil_Addcount = 0;
            int kill_Count = 0;

            string cursor = "<==";
            int cursor_X = 128;
            int cursor_Y = 45;

            // 메인 반복 시작지점

            while (true)
            {

                draw_Ui.Draw_Scene();
                draw_Ui.Main_Painting();
                draw_Ui.main_info();
                Draw_Cursor(ref cursor, ref cursor_X, ref cursor_Y);

                Console.SetCursorPosition(145, 43);
                Console.Write(" < 여 정 의 길 >");
                Console.SetCursorPosition(136, 45);
                Console.Write(" [ 현재 층 ] : {0} 층", stage_Count);
                Console.SetCursorPosition(136, 47);
                Console.Write(" [ 정   상 ] : {0} 층", last_Stage);

                Console.SetCursorPosition(148, 51);
                Console.Write(" < 메 뉴 > ");
                Console.SetCursorPosition(136, 54);
                Console.Write(" [ 캐 릭 터 정 보 창 ] : I");
                Console.SetCursorPosition(136, 56);
                Console.Write(" [  게  임   종  료  ] : ESC");

                if(cursor_Y == 45)
                {
                    Draw_Select001();
                }
                else if(cursor_Y == 50)
                {
                    Draw_Select002();
                }
                else if (cursor_Y == 55)
                {
                    Draw_Select003();
                }

                Console.SetCursorPosition(65, 45);
                Console.Write("무 장 을   정 비 한 다  ( 패널티 X,  미미한 스텟 강화 )");
                Console.SetCursorPosition(65, 50);
                Console.Write("수 련 을 한 다         (체력소모 발생,강한폭의 스텟강화)");
                Console.SetCursorPosition(65, 55);
                Console.Write("휴  식  을  취  한  다  ( 최대체력 40 % ~ 70 % 회복 )");

                Console.WriteLine();
                
                ConsoleKeyInfo user_Input = Console.ReadKey();


                // 메인화면 커서 이동, 메뉴키 입력 로직
                switch(user_Input.Key)
                {
                    case ConsoleKey.I:
                        player.Draw_Info_Window();
                        player.Charactor_Info(ref player_Hp, ref player_Max_Hp, ref player_Atk,
                            ref critical_Chance, ref evasion_Chance, ref stage_Count, ref skil_Addcount);
                        draw_Ui.Draw_Player();

                        Console.ReadKey();
                        break;

                    case ConsoleKey.Escape:
                        return;

                    case ConsoleKey.UpArrow:
                        cursor_Y -= 5;

                        if(cursor_Y <= 45)
                        {
                            cursor_Y = 45;
                            continue;
                        }
                        else if(cursor_Y == 54)
                        {
                            cursor_Y = 50;
                            continue;
                        }

                        break;

                    case ConsoleKey.DownArrow:
                        cursor_Y += 5;

                        if(cursor_Y >= 55)
                        {
                            cursor_Y = 55;
                            continue;
                        }

                        break;

                }
                // 메인화면 커서 이동, 메뉴키 입력 로직


                // 커서 이동 후 분기점 선택 로직
                if (cursor_Y == 45 && user_Input.Key == ConsoleKey.Enter)
                {
                    random_Buff.Select_1(ref player_Atk, ref critical_Chance, ref evasion_Chance,
                        ref player_Max_Hp, ref player_Hp);      // 버프를 먼저 받고

                    battle.Play_Battle(ref player_Hp, ref player_Max_Hp, ref player_Atk, ref critical_damage,
                        ref critical_Chance, ref evasion_Chance, ref stage_Count, ref last_Stage, ref boss_Count, ref skil_Addcount);
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
                else if( cursor_Y == 50 && user_Input.Key == ConsoleKey.Enter)
                {
                    random_Buff.Select_2(ref player_Hp, ref player_Atk, ref critical_Chance, ref evasion_Chance);

                    battle.Play_Battle(ref player_Hp, ref player_Max_Hp, ref player_Atk, ref critical_damage,
                        ref critical_Chance, ref evasion_Chance, ref stage_Count, ref last_Stage, ref boss_Count, ref skil_Addcount);

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
                else if (cursor_Y == 55 && user_Input.Key == ConsoleKey.Enter)
                {
                    random_Buff.Select_3(ref player_Hp, ref player_Max_Hp);

                    battle.Play_Battle(ref player_Hp, ref player_Max_Hp, ref player_Atk, ref critical_damage,
                        ref critical_Chance, ref evasion_Chance, ref stage_Count, ref last_Stage, ref boss_Count, ref skil_Addcount);

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
                // 커서 이동 후 분기점 선택 로직

            }
            // 메인 반복 종료지점

        }
        


        public void Draw_Cursor(ref string cursor, ref int x, ref int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(cursor);
        }

        public void Draw_Select001()
        {
            Console.SetCursorPosition(60, 44);
            Console.WriteLine("┌┌───────────────────────────────────────────────────────────┐ ");
            Console.SetCursorPosition(60, 45);
            Console.WriteLine("││                                                           │ ");
            Console.SetCursorPosition(60, 46);
            Console.WriteLine("││___________________________________________________________│ ");
            Console.SetCursorPosition(60, 47);
            Console.WriteLine("│/___________________________________________________________/ ");

            Console.SetCursorPosition(60, 49);
            Console.WriteLine("┌────────────────────────────────────────────────────────────┐ ");
            Console.SetCursorPosition(60, 50);
            Console.WriteLine("│                                                            │ ");
            Console.SetCursorPosition(60, 51);
            Console.WriteLine("└────────────────────────────────────────────────────────────┘ ");

            Console.SetCursorPosition(60, 54);
            Console.WriteLine("┌────────────────────────────────────────────────────────────┐ ");
            Console.SetCursorPosition(60, 55);
            Console.WriteLine("│                                                            │ ");
            Console.SetCursorPosition(60, 56);
            Console.WriteLine("└────────────────────────────────────────────────────────────┘ ");

        }

        public void Draw_Select002()
        {
            Console.SetCursorPosition(60, 44);
            Console.WriteLine("┌────────────────────────────────────────────────────────────┐ ");
            Console.SetCursorPosition(60, 45);
            Console.WriteLine("│                                                            │ ");
            Console.SetCursorPosition(60, 46);
            Console.WriteLine("└────────────────────────────────────────────────────────────┘ ");

            Console.SetCursorPosition(60, 49);
            Console.WriteLine("┌┌───────────────────────────────────────────────────────────┐ ");
            Console.SetCursorPosition(60, 50);
            Console.WriteLine("││                                                           │ ");
            Console.SetCursorPosition(60, 51);
            Console.WriteLine("││___________________________________________________________│ ");
            Console.SetCursorPosition(60, 52);
            Console.WriteLine("│/___________________________________________________________/ ");


            Console.SetCursorPosition(60, 54);
            Console.WriteLine("┌────────────────────────────────────────────────────────────┐ ");
            Console.SetCursorPosition(60, 55);
            Console.WriteLine("│                                                            │ ");
            Console.SetCursorPosition(60, 56);
            Console.WriteLine("└────────────────────────────────────────────────────────────┘ ");

        }

        public void Draw_Select003()
        {

            Console.SetCursorPosition(60, 44);
            Console.WriteLine("┌────────────────────────────────────────────────────────────┐ ");
            Console.SetCursorPosition(60, 45);
            Console.WriteLine("│                                                            │ ");
            Console.SetCursorPosition(60, 46);
            Console.WriteLine("└────────────────────────────────────────────────────────────┘ ");

            Console.SetCursorPosition(60, 49);
            Console.WriteLine("┌────────────────────────────────────────────────────────────┐ ");
            Console.SetCursorPosition(60, 50);
            Console.WriteLine("│                                                            │ ");
            Console.SetCursorPosition(60, 51);
            Console.WriteLine("└────────────────────────────────────────────────────────────┘ ");

            Console.SetCursorPosition(60, 54);
            Console.WriteLine("┌┌───────────────────────────────────────────────────────────┐ ");
            Console.SetCursorPosition(60, 55);
            Console.WriteLine("││                                                           │ ");
            Console.SetCursorPosition(60, 56);
            Console.WriteLine("││___________________________________________________________│ ");
            Console.SetCursorPosition(60, 57);
            Console.WriteLine("│/___________________________________________________________/ ");
        }

    }

}
