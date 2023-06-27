using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterTop
{
    public class RandomBuff
    {
        Random random = new Random();
        PlayerInfo player = new PlayerInfo();
        public void Select_1(ref int atk, ref int crichance)
        {
            player.Draw_Info_Window();
            player.Charactor_Info();

            int random_Atk = random.Next(1, 6);
            int random_Cri = random.Next(1, 4);

            int random_Buff = 0;
            random_Buff = random.Next(0, 2);

            if(random_Buff == 0)
            {
                Console.SetCursorPosition(45, 23);
                Console.Write("공격력 증가 : {0} + {1}", atk, random_Atk);
                atk += random_Atk;
                
            }
            else if(random_Buff == 1)
            {
                Console.SetCursorPosition(45, 23);
                Console.Write("크리티컬 확률 증가 : {0}% + {1}%", crichance, random_Cri);
                crichance += random_Cri;
                
            }

            Console.ReadKey();

        }

        public void Select_2(ref int hp, ref int atk, ref int crichance)
        {
            player.Draw_Info_Window();
            player.Charactor_Info();

            int random_Hp = random.Next(hp/10, hp/20);
            int random_Atk = random.Next(5, 16);
            int random_Cri = random.Next(3, 7);

            int random_Buff = 0;
            random_Buff = random.Next(0, 2);

            if (random_Buff == 0)
            {
                Console.SetCursorPosition(45, 21);
                Console.WriteLine("체력 감소 : {0} - {1}", hp, random_Hp);
                Console.SetCursorPosition(45, 23);
                Console.Write("공격력 증가 : {0} + {1}", atk, random_Atk);
                atk += random_Atk;
                hp -= random_Hp;
            }
            else if (random_Buff == 1)
            {
                Console.SetCursorPosition(45, 21);
                Console.WriteLine("체력 감소 : {0} - {1}", hp, random_Hp);
                Console.SetCursorPosition(45, 23);
                Console.Write("크리티컬 확률 증가 : {0}% + {1}%", crichance, random_Cri);
                crichance += random_Cri;
                hp -= random_Hp;
            }

            Console.ReadKey();
        }

        public void Select_3()
        {

        }
    }
}
