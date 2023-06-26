using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterTop
{
    public class Battle
    {
        MonsterBase monster = new MonsterBase();
        PlayerInfo player = new PlayerInfo();
        Sene draw_Ui = new Sene();


        public void Play_Battle()
        {            
            Skeletone monster_Skeletone = new Skeletone();
            monster_Skeletone.Initailze_Monster("해골병사", 60, 7);

            Zombie monster_Zombie = new Zombie();
            monster_Zombie.Initailze_Monster("좀비", 100, 1);

            draw_Ui.Draw_Sene();

            int battle_count = 0;

            while (true)
            {
              

                if(battle_count %2 == 0)
                {
                    draw_Ui.Draw_Sene();

                    Console.SetCursorPosition(90, 3);
                    monster_Zombie.Print_Monster();

                    Console.SetCursorPosition(90, 40);
                    Console.Write("플레이어 체력   : {0}", player.playerHp);
                    Console.SetCursorPosition(90, 42);
                    Console.Write("플레이어 공격력 : {0}", player.playerAtk);

                    ConsoleKeyInfo user_Input = Console.ReadKey();

                    switch (user_Input.Key)
                    {
                        case ConsoleKey.Escape:
                            return;
                        case ConsoleKey.Enter:
                            Attack_Monster(player.playerAtk,);

                            break;

                    }


                }
                else if(battle_count %2 == 1)
                { 

                }
                
                battle_count++;
                
            }
            

        }

        public int Attack_Monster(int player_Atk, int monster_Hp)
        {
            return monster_Hp -= player_Atk;
        }

        public int Attack_Player(int monster_Atk, int  player_Hp)
        {
            return player_Hp -= monster_Atk;
        }
    }
}
