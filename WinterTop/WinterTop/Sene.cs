using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinterTop
{
    public class Sene
    {
        
        public void Draw_Sene()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");
            Console.WriteLine("│                                                                                                                     │");          
            Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘");
            
        }

        public void Draw_Title()
        {
            Sene draw_Ui = new Sene();
            MainPlay init_Game = new MainPlay();

            Console.SetCursorPosition(50, 5);
            Console.Write("Title Sene");
            Console.SetCursorPosition(45, 30);
            Console.WriteLine("Enter 키를 눌러 입장");
            Console.SetCursorPosition(45, 32);
            Console.WriteLine("ESC 키를 눌러 게임 종료");

            while (true)
            {
                ConsoleKeyInfo game_Init = Console.ReadKey();

                if(game_Init.Key == ConsoleKey.Escape)
                {
                    Draw_Sene();

                    Console.SetCursorPosition(45, 20);                    
                    Console.WriteLine("게임을 종료합니다...");
                    Console.SetCursorPosition(35, 25);

                    return;
                }
                else if (game_Init.Key == ConsoleKey.Enter)
                {
                    Draw_Sene();

                    Console.SetCursorPosition(45, 20);
                    Console.WriteLine("게임 입장");
                    Thread.Sleep(500);

                    init_Game.Play_Game();
                    
                    // 메인 플레이중 게임종료를 눌렀을시
                    draw_Ui.Draw_Sene();
                    draw_Ui.Draw_Title();
                    return;
                    // 메인 플레이중 게임종료를 눌렀을시
                }
                else
                {
                    Draw_Sene();

                    Console.SetCursorPosition(45, 20);
                    Console.Write("키 입력이 올바르지 않습니다.");
                    Console.SetCursorPosition(45, 22);
                    Console.Write("게임 입장 : Enter");
                    Console.SetCursorPosition(45, 24);
                    Console.Write("게임 종료 : ESC");

                }


            }


        }

        public void Battle_Sene()
        {
            Draw_Sene();
        }

    }
}
