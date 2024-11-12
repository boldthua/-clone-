using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 格鬥遊戲
{
    internal class Player
    {
        private string serialNumber;
        public string name;
        public int ATT;
        public int DEF;
        public int DEX;
        public int HP = 10;

        public Player(string serialNumber, string name)
        {
            this.serialNumber = serialNumber;
            Random random = new Random(Guid.NewGuid().GetHashCode());
            this.name = name;
            this.ATT = random.Next(6, 11);
            this.DEF = random.Next(6, 11);
            this.DEX = random.Next(6, 11);
        }

       

        public void PunchOpponent(Player playerB)
        {
            Console.WriteLine($"{name} 選手的攻擊！");
            int damage = ATT - playerB.DEX;
            if (damage < 1)
            {
                damage = 1;
            }
            playerB.HP = playerB.HP - damage;

            if (playerB.HP < 0)
                playerB.HP = 0;
            Console.WriteLine($"對 {playerB.name} 選手造成了 {damage} 點的傷害！！");
            Console.WriteLine($"{playerB.name} 選手的血點剩餘 {playerB.HP} 點。");
        }
    }
}
