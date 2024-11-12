using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace 格鬥遊戲
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.創建角色 set ATT/ DEF / DEX / HP = 10; ATT, DEF / DEX = random(6, 11)
            //2.從1號for loop到最後一號，兩兩對戰,敗者淘汰。輪完後血量重置後再兩兩對戰，直到剩下一人。
            //3.對戰時DEX高的先攻，相同則編號小的先攻
            //4.damage = ATT - DEF
            //  damage <= 1, damage = 1;
            //5.顯示damage及當前血量。
            //6.顯示最後一名玩家。
            Console.WriteLine("請輸入參加競賽人數：");
            int countCompetitor = int.Parse(Console.ReadLine());
            Queue<Player> competitorRemainging = new Queue<Player>();
            Player finalWinner = null;
            for (int i = 1; i <= countCompetitor; i++)
            {
                string serialNumber = $"player{i : D2}";
                Console.WriteLine($"請輸入第 {i} 位角色名稱：");
                Player player = new Player(serialNumber, Console.ReadLine());
                competitorRemainging.Enqueue(player);
                
            }

            //Console.WriteLine("輸入角色名稱：");
            //Player player01 = new Player(Console.ReadLine());
            //Console.WriteLine($"已創建角色{player01.name}!");
            //Console.WriteLine("輸入角色名稱：");
            //Player player02 = new Player(Console.ReadLine());
            //Console.WriteLine($"已創建角色{player02.name}!");
            //Console.WriteLine("輸入角色名稱：");
            //Player player03 = new Player(Console.ReadLine());
            //Console.WriteLine($"已創建角色{player03.name}!");
            //Console.WriteLine("輸入角色名稱：");
            //Player player04 = new Player(Console.ReadLine());
            //Console.WriteLine($"已創建角色{player04.name}!");
            Queue<Player> battleWinners = new Queue<Player>();
            int gameRound = 0;
            while (finalWinner == null)
            {
                Console.WriteLine();
                Console.WriteLine($"          現在進行第 {++gameRound} 輪對戰！！");
                while (competitorRemainging.Count > 1)
                {
                    Player playerA = competitorRemainging.Dequeue();
                    Player playerB = competitorRemainging.Dequeue();
                    Console.WriteLine($"步上擂台的是 {playerA.name} 選手和 {playerB.name} 選手！");
                    battleWinners.Enqueue(startFighting(playerA, playerB));
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

            Console.WriteLine($"最後的贏家為 {finalWinner.name} 選手！！");
            Console.ReadKey();



        }
        static Player startFighting(Player playerA, Player playerB)
        {
            Player winner = null;
            playerA.HP = 10;
            playerB.HP = 10;
            Console.WriteLine("        戰鬥開始！！");
            Console.WriteLine($"{playerA.name}選手的各項數據為：");
            Console.WriteLine($"攻擊：{playerA.ATT}，防禦：{playerA.DEF}，敏捷：{playerA.DEX}");
            Console.WriteLine($"{playerB.name}選手的各項數據為：");
            Console.WriteLine($"攻擊：{playerB.ATT}，防禦：{playerB.DEF}，敏捷：{playerB.DEX}");

            while (true)
            {
                if (playerA.DEX >= playerB.DEX)
                {
                    playerA.PunchOpponent(playerB);
                    if (playerB.HP > 0)
                    {
                        playerB.PunchOpponent(playerA);
                    }
                    else
                    {
                        Console.WriteLine($"{playerB.name} 選手倒下了！！");
                        Console.WriteLine($"勝利者是 {playerA.name} 選手！！");
                        winner = playerA;
                        break;
                    }
                }
                else
                {
                    playerB.PunchOpponent(playerA);
                    if (playerA.HP > 0)
                    {
                        playerA.PunchOpponent(playerB);
                    }
                    else
                    {
                        Console.WriteLine($"{playerA.name} 選手倒下了！！");
                        Console.WriteLine($"勝利者是 {playerB.name} 選手！！");
                        winner = playerB;
                        break;
                    }
                }
            }
            return winner;
        }

    }
}
