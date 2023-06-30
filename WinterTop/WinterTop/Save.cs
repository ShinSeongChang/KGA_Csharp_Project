using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterTop
{
    internal class Save
    {

        // 메인화면 분기점 선택 로직 세이브


        //if(user_Input.Key == ConsoleKey.I)      // 플레이어 정보창 열기
        //{
        //    player.Draw_Info_Window();
        //    player.Charactor_Info(ref player_Hp, ref player_Max_Hp, ref player_Atk,
        //        ref critical_Chance, ref evasion_Chance, ref stage_Count, ref skil_Addcount);
        //    draw_Ui.Draw_Player();

        //    Console.ReadKey();
        //}
        //else if(user_Input.Key == ConsoleKey.Escape)    // 게임 종료
        //{
        //    return;
        //}
        //if(user_Input.Key == ConsoleKey.D1)    // 분기점 1 선택
        //{
        //    random_Buff.Select_1(ref player_Atk, ref critical_Chance, ref evasion_Chance,
        //        ref player_Max_Hp, ref player_Hp);      // 버프를 먼저 받고

        //    battle.Play_Battle(ref player_Hp, ref player_Max_Hp, ref player_Atk, ref critical_damage,
        //        ref critical_Chance, ref evasion_Chance, ref stage_Count, ref last_Stage, ref boss_Count, ref skil_Addcount);
        //                                                // 전투를 시작하게 된다.
        //    if (player_Hp <= 0)
        //    {
        //        Console.SetCursorPosition(110, 25);
        //        Console.Write("플레이어 사망...");
        //        return;
        //    }
        //    else if (boss_Count == 1 && player_Hp >= 0)
        //    {
        //        Console.SetCursorPosition(110, 25);
        //        Console.Write("게임 승리!");

        //        Console.ReadKey();
        //        return;
        //    }
        //}
        //else if (user_Input.Key == ConsoleKey.D2)
        //{
        //    random_Buff.Select_2(ref player_Hp, ref player_Atk, ref critical_Chance, ref evasion_Chance);

        //    battle.Play_Battle(ref player_Hp, ref player_Max_Hp, ref player_Atk, ref critical_damage,
        //        ref critical_Chance, ref evasion_Chance, ref stage_Count, ref last_Stage, ref boss_Count, ref skil_Addcount);

        //    if (player_Hp <= 0)
        //    {
        //        Console.SetCursorPosition(110, 25);
        //        Console.Write("플레이어 사망...");
        //        return;
        //    }
        //    else if (boss_Count == 1 && player_Hp >= 0)
        //    {
        //        Console.SetCursorPosition(110, 25);
        //        Console.Write("게임 승리!");

        //        Console.ReadKey();
        //        return;
        //    }
        //}
        //else if (user_Input.Key == ConsoleKey.D3)
        //{
        //    random_Buff.Select_3(ref player_Hp, ref player_Max_Hp);

        //    battle.Play_Battle(ref player_Hp, ref player_Max_Hp, ref player_Atk, ref critical_damage,
        //        ref critical_Chance, ref evasion_Chance, ref stage_Count, ref last_Stage, ref boss_Count, ref skil_Addcount);

        //    if (player_Hp <= 0)
        //    {
        //        Console.SetCursorPosition(110, 25);
        //        Console.Write("플레이어 사망...");
        //        return;
        //    }
        //    else if (boss_Count >= 1 && player_Hp >= 0)
        //    {
        //        Console.SetCursorPosition(110, 25);
        //        Console.Write("게임 승리!");

        //        Console.ReadKey();
        //        return;
        //    }
        //}
    }
}
