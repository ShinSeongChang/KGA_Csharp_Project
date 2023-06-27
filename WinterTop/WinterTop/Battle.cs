using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WinterTop
{
    public class Battle
    {     
        Scene draw_Ui = new Scene();
        Random rand = new Random();
        List<string> monster_Name = new List<string>();
        List<int> monster_Hp = new List<int>();
        List<int> monster_Atk = new List<int>();

        List<string> Boss_Name = new List<string>();
        List<int> Boss_Hp = new List<int>();
        List<int> Boss_Atk = new List<int>();

        public void Play_Battle(ref int hp, ref int atk, ref int crit, ref int cri_chace,
            ref int heal, ref int heal_chance, ref int stage_Count)
        {
            
            monster_Name.Add("좀비");
            monster_Hp.Add(100);
            monster_Atk.Add(5);
            monster_Name.Add("해골병사");
            monster_Hp.Add(60);
            monster_Atk.Add(13);
            monster_Name.Add("광신도");
            monster_Hp.Add(150);
            monster_Atk.Add(20);

            Boss_Name.Add("리치킹");
            Boss_Hp.Add(500);
            Boss_Atk.Add(50);

            int random_Monster = rand.Next(0, monster_Name.Count);            

            draw_Ui.Draw_Sene();

            int battle_count = 0;

            // 보스 몬스터 조우
            #region
            if (stage_Count == 4)
            {
                while (true)
                {
                    int random_Crit = rand.Next(0, 100);

                    // 배틀 탈출조건
                    if (hp <= 0)
                    {
                        draw_Ui.Draw_Sene();
                        Console.SetCursorPosition(110, 25);
                        Console.WriteLine("전투 패배");
                        Console.ReadLine();

                        hp = 0;
                        break;

                    }
                    else if (Boss_Hp[0] <= 0)
                    {
                        draw_Ui.Draw_Sene();
                        Console.SetCursorPosition(110, 25);
                        Console.WriteLine("전투 승리");
                        Console.ReadLine();

                        break;
                    }
                    // 배틀 탈출조건

                    // 유저가 공격하는 턴
                    if (battle_count % 2 == 0)
                    {
                        draw_Ui.Draw_Sene();

                        Console.SetCursorPosition(130, 3);
                        Console.WriteLine("몬스터 이름   : {0}", Boss_Name[0]);
                        Console.SetCursorPosition(130, 5);
                        Console.WriteLine("몬스터 체력   : {0}", Boss_Hp[0]);
                        Console.SetCursorPosition(130, 7);
                        Console.WriteLine("몬스터 공격력 :  {0}", Boss_Atk[0]);

                        Console.SetCursorPosition(90, 40);
                        Console.Write("플레이어 체력   : {0}", hp);
                        Console.SetCursorPosition(90, 42);
                        Console.Write("플레이어 공격력 : {0}", atk);

                        ConsoleKeyInfo user_Input = Console.ReadKey();

                        if (user_Input.Key == ConsoleKey.Escape)
                        {
                            return;
                        }
                        else if (user_Input.Key == ConsoleKey.Enter)
                        {
                            if (random_Crit < cri_chace)
                            {

                                Attack_Boss(ref atk, ref hp);

                                Console.SetCursorPosition(50, 25);
                                Console.Write("크리티컬 발생");
                                Console.ReadKey();

                                continue;
                            }

                            Attack_Boss(ref atk, ref hp);
                        }

                    }
                    // 유저가 공격하는 턴

                    else
                    {
                        Attack_Player_Boss(ref atk, ref hp);
                    }

                    battle_count++;
                }

                return;
            }
            #endregion
            // 보스 몬스터 조우

            // 일반 몬스터 조우
            #region
            while (true)
            {
                int random_Crit = rand.Next(0, 100);

                // 배틀 탈출조건
                if (hp <= 0)
                {
                    draw_Ui.Draw_Sene();
                    Console.SetCursorPosition(110, 25);
                    Console.WriteLine("전투 패배");
                    Console.ReadLine();

                    hp = 0;
                    break;

                }
                else if (monster_Hp[random_Monster] <= 0)
                {
                    draw_Ui.Draw_Sene();
                    Console.SetCursorPosition(110, 25);
                    Console.WriteLine("전투 승리");
                    Console.ReadLine();

                    break;
                }
                // 배틀 탈출조건

                // 유저가 공격하는 턴
                if (battle_count % 2 == 0)
                {
                    draw_Ui.Draw_Sene();

                    Console.SetCursorPosition(145, 3);
                    Console.WriteLine("몬스터 이름   : {0}", monster_Name[random_Monster]);
                    Console.SetCursorPosition(145, 5);
                    Console.WriteLine("몬스터 체력   : {0}", monster_Hp[random_Monster]);
                    Console.SetCursorPosition(145, 7);
                    Console.WriteLine("몬스터 공격력 :  {0}", monster_Atk[random_Monster]);

                    Console.SetCursorPosition(90, 40);
                    Console.Write("플레이어 체력   : {0}", hp);
                    Console.SetCursorPosition(90, 42);
                    Console.Write("플레이어 공격력 : {0}", atk);

                    ConsoleKeyInfo user_Input = Console.ReadKey();

                    if(user_Input.Key == ConsoleKey.Escape)
                    {
                        return;
                    }
                    else if(user_Input.Key == ConsoleKey.Enter)
                    {
                        if (random_Crit < cri_chace)
                        {
                           
                            Attack_Monster(ref random_Monster, ref crit, ref hp);

                            Console.SetCursorPosition(110, 25);
                            Console.Write("크리티컬 발생");
                            Console.ReadKey();

                            battle_count++;
                            continue;
                        }

                        Attack_Monster(ref random_Monster, ref atk, ref hp);
                    }

                }
                // 유저가 공격하는 턴

                else
                {
                    Attack_Player(ref random_Monster, ref atk, ref hp);
                }

                battle_count++;
            }
            
            #endregion
            // 일반 몬스터 조우
            
        }

        public void Attack_Monster(ref int random_Monster, ref int atk, ref int hp)
        {
            draw_Ui.Draw_Sene();
            monster_Hp[random_Monster] -= atk;

            Console.SetCursorPosition(130, 3);
            Console.WriteLine("몬스터 이름   : {0}", monster_Name[random_Monster]);
            Console.SetCursorPosition(130, 5);
            Console.WriteLine("몬스터 체력   : {0}", monster_Hp[random_Monster]);
            Console.SetCursorPosition(130, 7);
            Console.WriteLine("몬스터 공격력 :  {0}", monster_Atk[random_Monster]);

            Console.SetCursorPosition(90, 40);
            Console.Write("플레이어 체력   : {0}", hp);
            Console.SetCursorPosition(90, 42);
            Console.Write("플레이어 공격력 : {0}", atk);
        }

        public void Attack_Player(ref int random_Monster, ref int atk, ref int hp)
        {
            hp -= monster_Atk[random_Monster];

            Console.SetCursorPosition(130, 3);
            Console.WriteLine("몬스터 이름   : {0}", monster_Name[random_Monster]);
            Console.SetCursorPosition(130, 5);
            Console.WriteLine("몬스터 체력   : {0}", monster_Hp[random_Monster]);
            Console.SetCursorPosition(130, 7);
            Console.WriteLine("몬스터 공격력 :  {0}", monster_Atk[random_Monster]);

            Console.SetCursorPosition(90, 40);
            Console.Write("플레이어 체력   : {0}", hp);
            Console.SetCursorPosition(90, 42);
            Console.Write("플레이어 공격력 : {0}", atk);
        }

        public void Attack_Boss(ref int atk, ref int hp)
        {
            draw_Ui.Draw_Sene();
            Boss_Hp[0] -= atk;

            Console.SetCursorPosition(130, 3);
            Console.WriteLine("몬스터 이름   : {0}", Boss_Name[0]);
            Console.SetCursorPosition(130, 5);
            Console.WriteLine("몬스터 체력   : {0}", Boss_Hp[0]);
            Console.SetCursorPosition(130, 7);
            Console.WriteLine("몬스터 공격력 :  {0}", Boss_Atk[0]);

            Console.SetCursorPosition(90, 40);
            Console.Write("플레이어 체력   : {0}", hp);
            Console.SetCursorPosition(90, 42);
            Console.Write("플레이어 공격력 : {0}", atk);
        }

        public void Attack_Player_Boss(ref int atk, ref int hp)
        {
            hp -= Boss_Atk[0];

            Console.SetCursorPosition(130, 3);
            Console.WriteLine("몬스터 이름   : {0}", Boss_Name[0]);
            Console.SetCursorPosition(130, 5);
            Console.WriteLine("몬스터 체력   : {0}", Boss_Hp[0]);
            Console.SetCursorPosition(130, 7);
            Console.WriteLine("몬스터 공격력 :  {0}", Boss_Atk[0]);

            Console.SetCursorPosition(90, 40);
            Console.Write("플레이어 체력   : {0}", hp);
            Console.SetCursorPosition(90, 42);
            Console.Write("플레이어 공격력 : {0}", atk);
        }
    }
}
