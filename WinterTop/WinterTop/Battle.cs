using System;
using System.Collections.Generic;
using System.Data;
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
        PlayerInfo player = new PlayerInfo();

        List<string> monster_Name = new List<string>();
        List<double> monster_Hp = new List<double>();
        List<double> monster_Max_Hp = new List<double>();
        List<double> monster_Atk = new List<double>();

        List<string> Boss_Name = new List<string>();
        List<double> Boss_Hp = new List<double>();
        List<double> Boss_Max_Hp = new List<double>();
        List<double> Boss_Atk = new List<double>();

        public void Play_Battle(ref double hp, ref double max_hp, ref double atk, ref double crit,
            ref int cri_chance, ref int evasion, ref int stage_Count, ref int last_stage)
        {
            
            monster_Name.Add("좀비");
            monster_Hp.Add(Math.Truncate(max_hp * 1.1));
            monster_Max_Hp.Add(Math.Truncate(max_hp * 1.1));            
            monster_Atk.Add(Math.Truncate(atk * 0.2));
            monster_Name.Add("해골병사");
            monster_Hp.Add(Math.Truncate(max_hp * 0.6));
            monster_Max_Hp.Add(Math.Truncate(max_hp * 0.6));
            monster_Atk.Add(Math.Truncate(atk * 0.4));
            monster_Name.Add("광신도");
            monster_Hp.Add(Math.Truncate(max_hp * 1.2));
            monster_Max_Hp.Add(Math.Truncate(max_hp * 1.2));
            monster_Atk.Add(Math.Truncate(atk * 0.5));

            Boss_Name.Add("리치킹");
            Boss_Hp.Add(max_hp*2);
            Boss_Max_Hp.Add(max_hp*2);
            Boss_Atk.Add(atk*1.5);

            int random_Monster = rand.Next(0, monster_Name.Count-1);            

            draw_Ui.Draw_Sene();

            int battle_count = 0;

            // 보스 몬스터 조우
            #region
            if (stage_Count >= last_stage)
            {
                while (true)
                {
                    int random_Crit = rand.Next(0, 100);
                    int random_evasion = rand.Next(0, 100);

                    // 배틀 탈출조건
                    if (hp <= 0)        // 플레이어 사망시
                    {
                        draw_Ui.Draw_Sene();
                        Console.SetCursorPosition(110, 25);
                        Console.WriteLine("전투 패배");
                        Console.ReadLine();

                        hp = 0;
                        break;

                    }
                    else if (Boss_Hp[0] <= 0)       // 몬스터 사망시
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

                        Console.SetCursorPosition(142, 4);
                        Console.WriteLine("몬스터 이름   : {0}", Boss_Name[0]);
                        Console.SetCursorPosition(142, 6);
                        Console.WriteLine("몬스터 체력   : {0} / {1}", Boss_Hp[0], 
                            Boss_Max_Hp[random_Monster]);
                        Console.SetCursorPosition(142, 8);
                        Console.WriteLine("몬스터 공격력 :  {0}", Boss_Atk[0]);

                        Console.SetCursorPosition(63, 50);
                        Console.Write("플레이어 체력   : {0} / {1}", hp, max_hp);
                        Console.SetCursorPosition(63, 52);
                        Console.Write("플레이어 공격력 : {0}", atk);

                        ConsoleKeyInfo user_Input = Console.ReadKey();

                        if (user_Input.Key == ConsoleKey.Escape)
                        {
                            return;
                        }
                        else if (user_Input.Key == ConsoleKey.Enter)
                        {
                            if (random_Crit < cri_chance)
                            {

                                Attack_Boss(ref atk, ref hp, ref max_hp);

                                Console.SetCursorPosition(50, 25);
                                Console.Write("크리티컬 발생");
                                Console.ReadKey();

                                continue;
                            }

                            Attack_Boss(ref atk, ref hp, ref max_hp);
                        }

                    }
                    // 유저가 공격하는 턴

                    else
                    {
                        if (evasion >= random_evasion)
                        {
                            battle_count++;
                            continue;
                        }

                        Attack_Player_Boss(ref atk, ref hp, ref max_hp);
                    }

                    battle_count++;
                }

                stage_Count++;
                return;
            }
            #endregion
            // 보스 몬스터 조우

            // 일반 몬스터 조우
            #region
            while (true)
            {
                int random_Crit = rand.Next(0, 100);
                int random_evasion = rand.Next(0, 100);

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

                    stage_Count++;
                    break;
                }
                // 배틀 탈출조건

                // 유저가 공격하는 턴
                if (battle_count % 2 == 0)
                {
                    draw_Ui.Draw_Sene();
                    draw_Ui.battle_Info();

                    Console.SetCursorPosition(142, 4);
                    Console.WriteLine("몬스터 이름   : {0}", monster_Name[random_Monster]);
                    Console.SetCursorPosition(142, 6);
                    Console.WriteLine("몬스터 체력   : {0} / {1}", Math.Truncate(monster_Hp[random_Monster]),
                        monster_Max_Hp[random_Monster]);
                    Console.SetCursorPosition(142, 8);
                    Console.WriteLine("몬스터 공격력 :  {0}", Math.Truncate(monster_Atk[random_Monster]));

                    Console.SetCursorPosition(63, 50);
                    Console.Write("플레이어 체력   : {0} / {1}", hp, max_hp);
                    Console.SetCursorPosition(63, 52);
                    Console.Write("플레이어 공격력 :    {0}", atk);

                    ConsoleKeyInfo user_Input = Console.ReadKey();

                    if(user_Input.Key == ConsoleKey.Escape)     // 배틀 빠져나가기
                    {
                        return;
                    }
                    else if (user_Input.Key == ConsoleKey.I)    // 캐릭터 정보창 열람
                    {
                        player.Draw_Info_Window();
                        player.Charactor_Info(ref hp, ref max_hp, ref atk, ref cri_chance, ref evasion);

                        continue;
                    }
                    else if(user_Input.Key == ConsoleKey.Enter) // 공격 버튼
                    {
                        if (random_Crit < cri_chance)           // 크리티컬이 발동했을 때
                        {
                           
                            Attack_Monster(ref random_Monster, ref crit, ref hp, ref max_hp);

                            Console.SetCursorPosition(110, 25);
                            Console.Write("크리티컬 발생");
                            Console.ReadKey();

                            battle_count++;  
                            continue;
                        }

                        Attack_Monster(ref random_Monster, ref atk, ref hp, ref max_hp);
                    }

                }
                // 유저가 공격하는 턴

                // 몬스터가 공격하는 턴
                else
                {
                    if(evasion >= random_evasion)       // 유저의 회피가 발동했을 때
                    {
                        battle_count++;                 // 몬스터의 공격없이 턴이 넘어간다.
                        continue;
                    }

                    Attack_Player(ref random_Monster, ref atk, ref hp, ref max_hp);
                }
                // 몬스터가 공격하는 턴

                battle_count++;     // 공격 턴 넘김
            }
            
            #endregion
            // 일반 몬스터 조우
            
        }

        public void Attack_Monster(ref int random_Monster, ref double atk, ref double hp, ref double max_hp)
        {
            draw_Ui.Draw_Sene();
            draw_Ui.battle_Info();
            Math.Truncate(monster_Hp[random_Monster] -= atk);

            Console.SetCursorPosition(142, 4);
            Console.WriteLine("몬스터 이름   : {0}", monster_Name[random_Monster]);
            Console.SetCursorPosition(142, 6);
            Console.WriteLine("몬스터 체력   : {0} / {1}", monster_Hp[random_Monster],
                monster_Max_Hp[random_Monster]);
            Console.SetCursorPosition(142, 8);
            Console.WriteLine("몬스터 공격력 :  {0}", monster_Atk[random_Monster]);

            Console.SetCursorPosition(63, 50);
            Console.Write("플레이어 체력   : {0} / {1}", hp, max_hp);
            Console.SetCursorPosition(63, 52);
            Console.Write("플레이어 공격력 : {0}", atk);
        }

        public void Attack_Player(ref int random_Monster, ref double atk, ref double hp, ref double max_hp)
        {
            Math.Truncate(hp -= monster_Atk[random_Monster]);

            Console.SetCursorPosition(142, 4);
            Console.WriteLine("몬스터 이름   : {0}", monster_Name[random_Monster]);
            Console.SetCursorPosition(142, 6);
            Console.WriteLine("몬스터 체력   : {0} / {1}", monster_Hp[random_Monster],
                monster_Max_Hp[random_Monster]);
            Console.SetCursorPosition(142, 8);
            Console.WriteLine("몬스터 공격력 :  {0}", monster_Atk[random_Monster]);

            Console.SetCursorPosition(63, 50);
            Console.Write("플레이어 체력   : {0} / {1}", hp, max_hp);
            Console.SetCursorPosition(63, 52);
            Console.Write("플레이어 공격력 : {0}", atk);
        }

        public void Attack_Boss(ref double atk, ref double hp, ref double max_hp)
        {
            draw_Ui.Draw_Sene();
            Math.Truncate(Boss_Hp[0] -= atk);

            Console.SetCursorPosition(142, 4);
            Console.WriteLine("몬스터 이름   : {0}", Boss_Name[0]);
            Console.SetCursorPosition(142, 6);
            Console.WriteLine("몬스터 체력   : {0} / {1}", Boss_Hp[0], Boss_Max_Hp[0]);
            Console.SetCursorPosition(142, 8);
            Console.WriteLine("몬스터 공격력 :  {0}", Boss_Atk[0]);

            Console.SetCursorPosition(63, 50);
            Console.Write("플레이어 체력   : {0} / {1}", hp, max_hp);
            Console.SetCursorPosition(63, 52);
            Console.Write("플레이어 공격력 : {0}", atk);
        }

        public void Attack_Player_Boss(ref double atk, ref double hp, ref double max_hp)
        {
            Math.Truncate(hp -= Boss_Atk[0]);

            Console.SetCursorPosition(142, 4);
            Console.WriteLine("몬스터 이름   : {0}", Boss_Name[0]);
            Console.SetCursorPosition(142, 6);
            Console.WriteLine("몬스터 체력   : {0} / {1}", Boss_Hp[0], Boss_Max_Hp[0]);
            Console.SetCursorPosition(142, 8);
            Console.WriteLine("몬스터 공격력 :  {0}", Boss_Atk[0]);

            Console.SetCursorPosition(63, 50);
            Console.Write("플레이어 체력   : {0} / {1}", hp, max_hp);
            Console.SetCursorPosition(63, 52);
            Console.Write("플레이어 공격력 : {0}", atk);
        }

    }
}
