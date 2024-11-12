using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 格鬥遊戲_架構版_
{
    internal class Fight
    {

        public static Player PK(Player playerA, Player playerB)
        {
            Player winner = StartFighting(playerA, playerB);
            Console.WriteLine($"步上擂台的是 {playerA.name} 選手和 {playerB.name} 選手！");
            return (winner);
        }

        static Player StartFighting(Player playerA, Player playerB)
        {
            Player winner = null;
            playerA.Recorver();
            playerB.Recorver();

            Console.WriteLine("        戰鬥開始！！");
            playerA.ShowInfo();
            playerB.ShowInfo();

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
