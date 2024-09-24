using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class ShopManager
    {
        public static void Shop(Player player, List<Item> shopItems)
        {
            bool exitShop = false;

            while (!exitShop) 
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("상점");
                Console.ResetColor();
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine($"\n[보유 골드]\n{player.Gold}G\n");
                Console.WriteLine("[아이템 목록]");

                for(int i = 0; i < shopItems.Count; i++)
                {
                    shopItems[i].ShowItemInfo();
                }

                Console.WriteLine("\n1. 아이템 구매");
                Console.WriteLine("2. 아이템 판매");
                Console.WriteLine("0. 나가기");
                Console.Write("\n원하시는 행동을 입력해주세요\n>>");
                string input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("상점 - 아이템 구매");
                        Console.ResetColor();
                        Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                        Console.WriteLine($"\n[보유 골드]\n{player.Gold}G\n");
                        Console.WriteLine("[아이템 목록]");

                        for (int i = 0; i < shopItems.Count; i++)
                        {
                            shopItems[i].ShowItemInfo();
                        }

                        Console.WriteLine("\n0. 나가기");
                        Console.Write("\n원하시는 행동을 입력해주세요\n>>");

                        string itemInput = Console.ReadLine();
                        int itemIndex;
                        if (int.TryParse(itemInput, out itemIndex) && itemIndex >= 1 && itemIndex <= shopItems.Count)
                        {
                            player.BuyItem(shopItems[itemIndex - 1]);
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                        }
                        break;
                        case "2":
                        player.GetInventory();
                        string sellItemInput = Console.ReadLine();
                        int sellItemIndex;
                        if (int.TryParse(sellItemInput, out sellItemIndex) && sellItemIndex >= 1 && sellItemIndex <= player.Inventory.Count)
                        {
                            player.SellItem(player.Inventory[sellItemIndex - 1]);
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                        }
                        break;
                    case "0":
                        exitShop = true;
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
}
