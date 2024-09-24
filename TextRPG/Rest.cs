using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Rest
    {
        public static void Resting(Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("휴식하기");
            Console.ResetColor();
            Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {player.Gold} G)");
            Console.WriteLine("\n1. 휴식하기\n0. 나가기");
            Console.Write("\n원하시는 행동을 입력해주세요\n>>");
            string input = Console.ReadLine();

            switch (input) 
            {
                case "1":
                    if (player.Gold >= 500 && player.Health < 100)
                    {
                        player.Gold -= 500;
                        player.Health = 100;
                        Console.WriteLine("휴식이 완료되었습니다.");
                    }
                    else if (player.Health >= 100)
                    {
                        Console.WriteLine("이미 체력이 100입니다.");
                    }
                    else
                    {
                        Console.WriteLine("골드가 부족합니다.");
                    }
                break;
                case "0":
                break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                break;
            }
            Console.WriteLine("\n계속하려면 아무 키나 누르세요...");
            Console.ReadKey();
        }
    }
}
