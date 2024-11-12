using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace 格鬥遊戲_架構版_
{
    internal class Game
    {
        //1.創建角色
        //2.開始遊戲

        //3.show winner
        Queue<Player> competitorRemainging = new Queue<Player>();
        Queue<Player> battleWinners = new Queue<Player>();
        Player finalWinner = null;


        public void CreatePlayer(int playersCount)
        {
            for (int i = 1; i <= playersCount; i++)
            {
                string serialNumber = $"player{i: D2}";
                Console.WriteLine($"請輸入第 {i} 位角色名稱：");
                Player player = new Player(serialNumber, Console.ReadLine());
                competitorRemainging.Enqueue(player);

            }
        }

        public void StartGame()
        {
            int gameRound = 0;

            while (finalWinner == null)
            {
                Console.WriteLine();
                Console.WriteLine($"          現在進行第 {++gameRound} 輪對戰！！");
                while (competitorRemainging.Count > 1)
                {
                    Player playerA = competitorRemainging.Dequeue();
                    Player playerB = competitorRemainging.Dequeue();

                    battleWinners.Enqueue(Fight.PK(playerA, playerB));
                }
                if (competitorRemainging.Count > 0)
                {
                    for (int i = 0; i < competitorRemainging.Count; i++)
                    {
                        Player luckyMan = competitorRemainging.Dequeue();
                        battleWinners.Enqueue(luckyMan);
                        Console.WriteLine($"{luckyMan.name} 選手輪空晉級！潮爽的！！");
                    }
                }
                if (battleWinners.Count == 1)
                {
                    finalWinner = battleWinners.Dequeue();
                    break;
                }

                competitorRemainging = battleWinners;
                battleWinners = new Queue<Player>();
            }
        }





        public Player ShowWinner()
        {
            return finalWinner;
        }
    }
}
