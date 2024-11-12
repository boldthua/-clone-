using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace 格鬥遊戲_架構版_
{
    internal class Program
    {
        //1.創建角色
        //2.開始遊戲
        //3.show winner

        static void Main(string[] args)
        {

            Console.WriteLine("請輸入遊玩人數:");
            int number = int.Parse(Console.ReadLine());
            Game game = new Game();
            game.CreatePlayer(number);
            game.StartGame();
            Player player = game.ShowWinner();

            Console.WriteLine($"勝利者是:{player.name}");
            


    }
}
