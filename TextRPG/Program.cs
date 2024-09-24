namespace TextRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(01, "Chad( 전사 )", 10, 5, 100, 10000);

            Dongeon dongeon = new Dongeon(5, 11, 17, "쉬운 던전", "일반 던전", "어려운 던전");

            List<Item> items = new List<Item>()
            {
                new Item("수련자의 갑옷", "방어력 +5", "수련에 도움을 주는 갑옷입니다.", 1000, 0, 5, ItemType.Armor),
                new Item("무쇠갑옷", "방어력 +9", "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000, 0, 9, ItemType.Armor),
                new Item("스파르타의 갑옷", "방어력 +15", "스파르타 전사들이 사용했다는 전설의 갑옷입니다.", 3500, 0, 15, ItemType.Armor),
                new Item("워모그의 갑옷", "방어력 +30", "다른 세계에서 넘어온 초월적인 갑옷입니다.", 5000, 0, 30, ItemType.Armor),
                new Item("낡은 검", "공격력 +2", "쉽게 볼 수 있는 낡은 검 입니다.", 600, 2, 0, ItemType.Weapon),
                new Item("청동 도끼", "공격력 +5", "어디선가 사용됐던거 같은 도끼입니다.", 1500, 5, 0, ItemType.Weapon),
                new Item("스파르타의 창", "공격력 +7", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 3000, 7, 0, ItemType.Weapon),
                new Item("굶줄인 히드라", "공격력 +15", "다른 세계에서 넘어온 초월적인 검 입니다.", 5000, 15, 0, ItemType.Weapon)
            };

            bool isExit = false;

            while (!isExit)
            {
                Console.Clear();
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리 관리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("4. 던전입장");
                Console.WriteLine("5. 휴식하기");
                Console.WriteLine("0. 나가기");
                Console.Write("\n원하시는 행동을 입력해주세요\n>>");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        player.ShowStatus();
                        break;
                    case "2":
                        InventoryManager.Inventory(player);
                        break;
                    case "3":
                        ShopManager.Shop(player, items);
                        break;
                    case "4":
                        DongeonManager.EnterDongeon(player, dongeon);
                    break;
                    case "5":
                        Rest.Resting(player);
                    break;
                    case "0":
                        isExit = true;
                        Console.WriteLine("마을을 떠납니다.");
                        break;
                    default:
                        Console.WriteLine("- 잘못된 입력입니다.");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
