using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class InventoryManager
    {
        public static void Inventory(Player player)
        {
            bool exitIven = false;

            while(!exitIven)
            {
                player.ShowInventory();
                string input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        player.EquipedItem();
                        if (int.TryParse(Console.ReadLine(), out int equipIdx) && 
                            equipIdx >= 1 && equipIdx <= player.Inventory.Count)
                        {
                            player.EquipItem(equipIdx - 1);
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                        }
                        break;
                    case "0":
                        exitIven = true;
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
