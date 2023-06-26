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
        PlayerInfo charactor_Info = new PlayerInfo();
        Battle battle = new Battle();

        public void Play_Game()
        {            

            while (true)
            {
                draw_Ui.Draw_Sene();

                Console.SetCursorPosition(10, 1);
                Console.Write("캐릭터 이름 \t 체력 : ");
                Console.SetCursorPosition(90, 1);
                Console.Write("현재 스테이지 진행정도");

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

                switch(user_Input.Key)
                {
                    case ConsoleKey.I:
                        charactor_Info.Draw_Info_Window();
                        charactor_Info.Charactor_Info();
                        break;

                    case ConsoleKey.Escape:
                        return;

                    case ConsoleKey.B:
                        battle.Play_Battle();
                        break;

                }



            }
            

        }
    }
}
