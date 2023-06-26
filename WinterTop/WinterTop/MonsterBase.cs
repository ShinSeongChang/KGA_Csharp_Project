using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterTop
{
    
    public class MonsterBase
    {
        protected string monster_Name;
        protected int monster_Hp;
        protected int monster_Atk;

        public virtual void Initailze_Monster(string name, int hp, int atk)
        {
            monster_Name = name;
            monster_Hp = hp;
            monster_Atk = atk;
        }

        public virtual void Print_Monster()
        { 
            Console.WriteLine("몬스터 이름   : {0}", monster_Name);
            Console.SetCursorPosition(90, 5);
            Console.WriteLine("몬스터 체력   : {0}", monster_Hp);
            Console.SetCursorPosition(90, 7);
            Console.WriteLine("몬스터 공격력 :  {0}", monster_Atk);
        }
    }
}
