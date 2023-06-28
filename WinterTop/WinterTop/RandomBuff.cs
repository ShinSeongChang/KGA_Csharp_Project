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
        Scene draw_Ui = new Scene();
        List<string> skil_Name = new List<string>();
        List<int> skil_value = new List<int>();

        // 분기점 1을 선택했을 경우
        public void Select_1(ref double atk, ref int crichance, ref int evasion, ref double max_Hp,
            ref double hp)  
        {
            draw_Ui.Draw_Sene();
            draw_Ui.main_info();
            double random_Atk = random.NextDouble();
            int random_Cri = random.Next(0, 4);             // 크리티컬 증가량 0 ~ 3 %
            int random_Evasion = random.Next(0, 3);         // 회피율 증가량 0 ~ 2 %
            double random_Max_Hp = random.NextDouble();

            while(random_Atk < 0.1 || random_Atk > 0.5)     // 공격력 증가량 10 ~ 50 %
            {
                random_Atk = random.NextDouble();
            }
            while(random_Max_Hp < 0.1 || random_Max_Hp > 0.2) // 최대체력 증가량 10 ~ 20 %
            {
                random_Max_Hp = random.NextDouble() ;
            }

            int random_Buff = random.Next(0, 4);  // 무작위 버프 4종류


            if (random_Buff == 0)                               // 공격력 증가일 경우
            {
                double save_Atk = Math.Truncate(atk * random_Atk);

                Console.SetCursorPosition(70, 54);
                Console.Write("공격력 증가량 : {0} %", Math.Truncate(random_Atk * 100));
                Console.SetCursorPosition(70, 56);
                Console.Write("공격력 증가 : {0} + {1}", atk, save_Atk);

                atk += save_Atk;
                
            }
            else if(random_Buff == 1)                       // 크리티컬 확률 증가일 경우
            {
                Console.SetCursorPosition(70, 54);
                Console.Write("크리티컬 확률 증가 : {0} % + {1} %", crichance, random_Cri);
                crichance += random_Cri;
                
            }
            else if (random_Buff == 2)                      // 회피율 증가일 경우
            {
                Console.SetCursorPosition(70, 54);
                Console.Write("회피율 증가 : {0} % + {1} %", evasion, random_Evasion);
                evasion += random_Evasion;

            }
            else if (random_Buff == 3)                      // 최대체력 증가일 경우
            {
                double save_Hp = Math.Truncate(max_Hp * random_Max_Hp);

                Console.SetCursorPosition(70, 54);
                Console.WriteLine("최대체력 증가량 :  {0} %", Math.Truncate(random_Max_Hp * 100));
                Console.SetCursorPosition(70, 56);
                Console.Write("최대체력 증가 : {0} + {1}", max_Hp, save_Hp);

                max_Hp += save_Hp;
                hp += save_Hp;

                if(hp >= max_Hp)
                {
                    hp = max_Hp;
                }
                

            }


            Console.ReadKey();

        }
        // 분기점 1 종료


        // 분기점 2를 선택했을 경우
        public void Select_2(ref double hp, ref double atk, ref int crichance, ref int evasion)            
        {
            draw_Ui.Draw_Sene();
            draw_Ui.main_info();

            double random_Hp = random.NextDouble();
            double random_Atk = random.NextDouble();
            int random_Cri = random.Next(5, 11);
            int random_Evasion = random.Next(5, 11);

            while(random_Hp < 0.2 || random_Hp > 0.4)
            {
                random_Hp = random.NextDouble();
            }
            while(random_Atk < 0.6)
            {
                random_Atk = random.NextDouble() ;
            }

            int random_Buff = 0;
            random_Buff = random.Next(0, 3);

            if (random_Buff == 0)
            {
                double save_Hp = Math.Truncate(hp * random_Hp);
                double save_Atk = Math.Truncate(atk * random_Atk);

                Console.SetCursorPosition(70, 50);
                Console.WriteLine("체력 감소량 :  {0} %", Math.Truncate(random_Hp * 100));
                Console.SetCursorPosition(70, 52);
                Console.WriteLine("체력 감소 : {0} - {1}", hp, save_Hp);
                Console.SetCursorPosition(70, 54);
                Console.Write("공격력 증가량 : {0} %", atk, Math.Truncate(random_Atk * 100));
                Console.SetCursorPosition(70, 56);
                Console.Write("공격력 증가 : {0} + {1}", atk, save_Atk);

                atk += save_Atk;
                hp -= save_Hp;
            }
            else if (random_Buff == 1)
            {
                double save_Hp = Math.Truncate(hp * random_Hp);

                Console.SetCursorPosition(70, 52);
                Console.WriteLine("체력 감소량 :  {0} %", Math.Truncate(random_Hp * 100));
                Console.SetCursorPosition(70, 54);
                Console.WriteLine("체력 감소 : {0} - {1}", hp, save_Hp);
                Console.SetCursorPosition(70, 56);
                Console.Write("크리티컬 확률 증가 : {0}% + {1}%", crichance, random_Cri);
                crichance += random_Cri;
                hp -= save_Hp;
            }
            else if (random_Buff == 2)
            {
                double save_Hp = Math.Truncate(hp * random_Hp);

                Console.SetCursorPosition(70, 52);
                Console.WriteLine("체력 감소량 :  {0} %", Math.Truncate(random_Hp * 100));
                Console.SetCursorPosition(70, 54);
                Console.WriteLine("체력 감소 : {0} - {1}", hp, save_Hp);
                Console.SetCursorPosition(70, 56);
                Console.Write("회피율 증가 : {0}% + {1}%", evasion, random_Evasion);
                evasion += random_Evasion;
                hp -= save_Hp;
            }

            Console.ReadKey();
        }
        // 분기점 2 종료


        // 분기점 3을 선택했을 경우
        public void Select_3(ref double hp, ref double max_hp)
        {

            draw_Ui.Draw_Sene();
            draw_Ui.main_info();
            //draw_Ui.Draw_Heal();

            double random_Hp = random.NextDouble();

            while(random_Hp < 0.4 || random_Hp > 0.7)
            {
                random_Hp = random.NextDouble();
            }

            double save_Hp = Math.Truncate(max_hp * random_Hp);

            Console.SetCursorPosition(70, 54);
            Console.WriteLine("체력 회복량 : {0} %", Math.Truncate(random_Hp * 100));
            Console.SetCursorPosition(70, 56);
            Console.WriteLine("체력 회복 : {0} + {1}", hp, save_Hp);

            hp += save_Hp;

            if (hp >= max_hp)
            {
                hp = max_hp;              
            }            

            Console.ReadKey();
        }
        // 분기점 3 종료
    }
}
