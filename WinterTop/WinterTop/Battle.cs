using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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

        List<string> skillist_Name = new List<string>();        
        List<int> skillist_Count = new List<int>();
        List<int> skillist_MaxCount = new List<int>();

        List<string> user_Skilname = new List<string>();
        List<int> user_SkilCount = new List<int>();
        List<int> user_MaxSkilCount = new List<int>();
        public void Play_Battle(ref double hp, ref double max_hp, ref double atk, ref double crit, ref int cri_chance, ref int evasion, 
            ref int stage_Count, ref int last_stage, ref int boss_Count)
        {

            // 스킬 리스트 목록
            skillist_Name.Add("스킬1");
            skillist_Count.Add(5);
            skillist_MaxCount.Add(5);
            skillist_Name.Add("스킬2");
            skillist_Count.Add(3);
            skillist_MaxCount.Add(3);
            skillist_Name.Add("스킬3");
            skillist_Count.Add(1);
            skillist_MaxCount.Add(1);
            // 스킬 리스트 목록

            // 몬스터 목록
            #region
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

            //보스
            monster_Name.Add("z리치킹z");
            monster_Hp.Add(Math.Truncate(max_hp*2));
            monster_Max_Hp.Add(Math.Truncate(max_hp*2));
            monster_Atk.Add(Math.Truncate(atk*1.5));
            #endregion
            // 몬스터 목록

            int skil_Addcount = 0;

            // 스테이지 2단계 진행시마다 유저는 순차적으로 스킬을 획득
            if(stage_Count % 2 == 0)
            {
                user_Skilname.Add(skillist_Name[skil_Addcount]);
                user_SkilCount.Add(skillist_Count[skil_Addcount]);
                user_MaxSkilCount.Add(skillist_MaxCount[skil_Addcount]);

                skil_Addcount++;
            }
            // 스테이지 2단계 진행시마다 유저는 순차적으로 스킬을 획득


            int random_Monster = rand.Next(0, (monster_Name.Count-2));   
            
            if(stage_Count >= last_stage)
            {
                random_Monster = monster_Name.Count - 1;
            }

            int battle_count = 0;

            string cursor = "<==";
            int cursor_X = 80;
            int cursor_Y = 54;

            // 보스 몬스터 조우
            #region
            if (stage_Count == last_stage)
            {
                while (true)
                {
                    int random_Crit = rand.Next(0, 100);
                    int random_evasion = rand.Next(0, 100);

                    // 배틀 탈출조건
                    if (hp <= 0)                                          // 플레이어 사망시
                    {
                        draw_Ui.Draw_Scene();
                        Console.SetCursorPosition(110, 25);
                        Console.WriteLine("전투 패배");
                        Console.ReadLine();

                        hp = 0;
                        break;

                    }
                    else if (monster_Hp[monster_Hp.Count - 1] <= 0)       // 몬스터 사망시
                    {
                        draw_Ui.Draw_Scene();
                        Console.SetCursorPosition(110, 25);
                        Console.WriteLine("전투 승리");
                        Console.ReadLine();

                        boss_Count++;
                        break;
                    }
                    // 배틀 탈출조건


                    // 유저가 공격하는 턴
                    if (battle_count % 2 == 0)
                    {
                        draw_Ui.Draw_Scene();
                        draw_Ui.Draw_InfoWindow();
                        Draw_Cursor(ref cursor, ref cursor_X, ref cursor_Y);
                        Draw_BattleInfo(ref hp, ref max_hp, ref atk, ref random_Monster);

                        ConsoleKeyInfo user_Input = Console.ReadKey();

                        switch (user_Input.Key)
                        {

                            case ConsoleKey.Escape:
                                return;

                            case ConsoleKey.I:
                                player.Draw_Info_Window();
                                player.Charactor_Info(ref hp, ref max_hp, ref atk, ref cri_chance, ref evasion, ref stage_Count);

                                break;
                            case ConsoleKey.UpArrow:
                                cursor_Y--;

                                if (cursor_Y <= 54)
                                {
                                    cursor_Y = 54;
                                }

                                break;
                            case ConsoleKey.DownArrow:
                                cursor_Y++;

                                if (cursor_Y >= 56)
                                {
                                    cursor_Y = 56;
                                }

                                break;

                        }

                        if (cursor_Y == 54 && user_Input.Key == ConsoleKey.Enter)       // 공격을 선택시
                        {
                            if (random_Crit < cri_chance)                               // 크리티컬이 발동했을 때
                            {
                                Attack_Monster(ref random_Monster, ref crit, ref hp, ref max_hp);

                                Console.SetCursorPosition(110, 25);
                                Console.Write("크리티컬 발생");
                                Console.ReadKey();

                                battle_count++;
                                continue;
                            }

                            Attack_Monster(ref random_Monster, ref atk, ref hp, ref max_hp);
                            battle_count++;
                        }
                        else if (cursor_Y == 56 && user_Input.Key == ConsoleKey.Enter)   // 스킬을 선택시
                        {

                            while (true)     // 스킬창 목록에 가두기
                            {
                                Draw_SkilWindow();
                                Draw_SkilInfo();
                                Draw_Cursor(ref cursor, ref cursor_X, ref cursor_Y);

                                user_Input = Console.ReadKey();

                                switch (user_Input.Key)
                                {

                                    case ConsoleKey.Escape:
                                        return;

                                    case ConsoleKey.I:
                                        player.Draw_Info_Window();
                                        player.Charactor_Info(ref hp, ref max_hp, ref atk, ref cri_chance, ref evasion, ref stage_Count);

                                        break;
                                    case ConsoleKey.UpArrow:
                                        cursor_Y--;

                                        if (cursor_Y <= 54)
                                        {
                                            cursor_Y = 54;
                                        }

                                        break;
                                    case ConsoleKey.DownArrow:
                                        cursor_Y++;

                                        if (cursor_Y >= 56)
                                        {
                                            cursor_Y = 56;
                                        }

                                        break;
                                }


                                if (true)    // 스킬 확정시, break로 스킬창 목록을 나간다.
                                {
                                    break;
                                }


                            }

                            battle_count++;
                            Console.ReadKey();

                        }

                    }


                    // 유저가 공격하는 턴

                    // 몬스터가 공격하는 턴
                    else
                    {
                        if (evasion >= random_evasion)       // 유저의 회피가 발동했을 때
                        {
                            Console.SetCursorPosition(110, 25);
                            Console.Write("회피 발생");
                            Console.ReadKey();

                            battle_count++;                 // 몬스터의 공격없이 턴이 넘어간다.
                            continue;
                        }

                        Attack_Player(ref random_Monster, ref atk, ref hp, ref max_hp);
                        battle_count++;
                    }
                    // 몬스터가 공격하는 턴

                }

            }
            #endregion
            // 보스 몬스터 조우


            // 일반 몬스터 조우
            #region
            else
            {
                while (true)
                {
                    int random_Crit = rand.Next(0, 100);
                    int random_evasion = rand.Next(0, 100);

                    // 배틀 탈출조건
                    if (hp <= 0)
                    {
                        draw_Ui.Draw_Scene();
                        Console.SetCursorPosition(110, 25);
                        Console.WriteLine("전투 패배");
                        Console.ReadLine();

                        hp = 0;
                        break;

                    }
                    else if (monster_Hp[random_Monster] <= 0)
                    {
                        draw_Ui.Draw_Scene();
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
                        draw_Ui.Draw_Scene();
                        draw_Ui.Draw_InfoWindow();
                        Draw_Cursor(ref cursor, ref cursor_X, ref cursor_Y);
                        Draw_BattleInfo(ref hp, ref max_hp, ref atk, ref random_Monster);

                        // 커서를 움직이는 로직
                        ConsoleKeyInfo user_Input = Console.ReadKey();
                        switch (user_Input.Key)
                        {

                            case ConsoleKey.Escape:
                                return;

                            case ConsoleKey.I:
                                player.Draw_Info_Window();
                                player.Charactor_Info(ref hp, ref max_hp, ref atk, ref cri_chance, ref evasion, ref stage_Count);

                                break;
                            case ConsoleKey.UpArrow:
                                cursor_Y--;

                                if (cursor_Y <= 54)
                                {
                                    cursor_Y = 54;
                                }

                                break;
                            case ConsoleKey.DownArrow:
                                cursor_Y++;

                                if (cursor_Y >= 56)
                                {
                                    cursor_Y = 56;
                                }

                                break;

                        }
                        // 커서를 움직이는 로직

                        // 유저가 원하는 행동을 지목했을때
                        if (cursor_Y == 54 && user_Input.Key == ConsoleKey.Enter)       // 공격을 선택시
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
                            battle_count++;
                        }
                        else if(cursor_Y == 56 && user_Input.Key == ConsoleKey.Enter)   // 스킬을 선택시
                        {
                            
                            while(true)     // 스킬창 목록에 가두기
                            {
                                Draw_SkilWindow();
                                Draw_SkilInfo();
                                Draw_Cursor(ref cursor, ref cursor_X, ref cursor_Y);

                                user_Input = Console.ReadKey();

                                switch (user_Input.Key)
                                {

                                    case ConsoleKey.Escape:
                                        return;

                                    case ConsoleKey.I:
                                        player.Draw_Info_Window();
                                        player.Charactor_Info(ref hp, ref max_hp, ref atk, ref cri_chance, ref evasion, ref stage_Count);

                                        break;
                                    case ConsoleKey.UpArrow:
                                        cursor_Y--;

                                        if (cursor_Y <= 54)
                                        {
                                            cursor_Y = 54;
                                        }

                                        break;
                                    case ConsoleKey.DownArrow:
                                        cursor_Y++;

                                        if (cursor_Y >= 56)
                                        {
                                            cursor_Y = 56;
                                        }

                                        break;
                                }


                                if(true)    // 스킬 확정시, break로 스킬창 목록을 나간다.
                                {
                                    break;
                                }

                                
                            }

                            battle_count++;
                            Console.ReadKey();
                        }

                    }
                    // 유저가 공격하는 턴

                    // 몬스터가 공격하는 턴
                    else
                    {
                        if (evasion >= random_evasion)       // 유저의 회피가 발동했을 때
                        {
                            battle_count++;                 // 몬스터의 공격없이 턴이 넘어간다.
                            continue;
                        }

                        Attack_Player(ref random_Monster, ref atk, ref hp, ref max_hp);
                        battle_count++;
                    }
                    // 몬스터가 공격하는 턴

                }


            }                            
            #endregion
            // 일반 몬스터 조우
            
        }

        public void Attack_Monster(ref int random_Monster, ref double atk, ref double hp, ref double max_hp)
        {
            draw_Ui.Draw_Scene();
            draw_Ui.Draw_InfoWindow();
            Math.Truncate(monster_Hp[random_Monster] -= atk);

            Draw_BattleInfo(ref hp, ref max_hp, ref atk, ref random_Monster);
        }

        public void Attack_Player(ref int random_Monster, ref double atk, ref double hp, ref double max_hp)
        {
            draw_Ui.Draw_Scene();
            draw_Ui.Draw_InfoWindow();
            Math.Truncate(hp -= monster_Atk[random_Monster]);

            Draw_BattleInfo(ref hp, ref max_hp, ref atk, ref random_Monster);
        }

        public void Draw_Cursor(ref string cursor, ref int x, ref int y)
        {
            Console.SetCursorPosition(x,y);
            Console.Write(cursor);
        }

        public void Draw_BattleInfo(ref double hp, ref double max_hp, ref double atk, ref int random_Monster)
        {
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
            Console.SetCursorPosition(63, 54);
            Console.Write("공격");
            Console.SetCursorPosition(63, 56);
            Console.Write("스킬");
        }

        public void Draw_SkilWindow()
        {
            Console.SetCursorPosition(59, 48);
            Console.Write("┌───────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(59, 49);
            Console.Write("│                                                       │");
            Console.SetCursorPosition(59, 50);
            Console.Write("│                                                       │");
            Console.SetCursorPosition(59, 51);
            Console.Write("│                                                       │");
            Console.SetCursorPosition(59, 52);
            Console.Write("│                                                       │");
            Console.SetCursorPosition(59, 53);
            Console.Write("│                                                       │");
            Console.SetCursorPosition(59, 54);
            Console.Write("│                                                       │");
            Console.SetCursorPosition(59, 55);
            Console.Write("│                                                       │");
            Console.SetCursorPosition(59, 56);
            Console.Write("│                                                       │");
            Console.SetCursorPosition(59, 57);
            Console.Write("│                                                       │");
            Console.SetCursorPosition(59, 58);
            Console.Write("└───────────────────────────────────────────────────────┘");

        }

        public void Draw_SkilInfo()
        {
            int y = 49;

            Console.SetCursorPosition(61, 49);
            Console.Write("< 스 킬 목 록 >");

            foreach(var skil in user_Skilname)
            {
                y += 2;
                Console.SetCursorPosition(61, y);
                Console.Write("{0}", skil);
            }
           
        }

    }
}
