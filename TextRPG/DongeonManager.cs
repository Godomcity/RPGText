using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class DongeonManager
    {
        public static void EnterDongeon(Player player, Dongeon dongeon)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("던전입장");
            Console.ResetColor();
            Console.WriteLine("이곳에서 던전으로 들어가전 활동을 할 수 있습니다.");
            Console.WriteLine("\n1. 쉬운 던전    | 방어력 5 이상 권장");
            Console.WriteLine("2. 일반 던전    | 방어력 11 이상 권장");
            Console.WriteLine("3. 어려운 던전    | 방어력 17 이상 권장");
            Console.WriteLine("0. 나가기");
            Console.Write("\n원하시는 행동을 입력해주세요\n>>");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    dongeon.IsEasyClear = true;
                    if (player.Defense >= dongeon.EasyReDef)
                    {
                        player.DongeonClear(dongeon);
                    }
                    else
                    {
                        Random rnd = new Random();
                        double chance = rnd.NextDouble();
                        if (chance <= 0.4)
                        {
                            player.DongeonFail();
                        }
                        else
                        {
                            player.DongeonClear(dongeon);
                        }
                    }
                    break;
                case "2":
                    Console.Clear();
                    dongeon.IsNormalClear = true;
                    if (player.Defense >= dongeon.NormalReDef)
                    {
                        player.DongeonClear(dongeon);
                    }
                    else
                    {
                        Random rnd = new Random();
                        double chance = rnd.NextDouble();
                        if (chance <= 0.4)
                        {
                            player.DongeonFail();
                        }
                        else
                        {
                            player.DongeonClear(dongeon);
                        }
                    }
                    break;
                case "3":
                    Console.Clear();
                    dongeon.IsDifficultClear = true;
                    if (player.Defense >= dongeon.DifficultReDef)
                    {
                        player.DongeonClear(dongeon);
                    }
                    else
                    {
                        Random rnd = new Random();
                        double chance = rnd.NextDouble();
                        if (chance <= 0.4)
                        {
                            player.DongeonFail();
                        }
                        else
                        {
                            player.DongeonClear(dongeon);
                        }
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
