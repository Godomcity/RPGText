using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Player
    {
        public int Lv {  get; set; }
        public string Job { get; set; }
        public float Attack { get; set; }
        public int Defense { get; set; }
        public int Health { get; set; }
        public float Gold { get; set; }
        public List<Item> Inventory { get; set; }
        public Item EquippedWeapon { get; set; }
        public Item EquippedArmor { get; set; }

        public Player(int lv, string job, float attack, int defense, int health, float gold)
        {
            Lv = lv;
            Job = job;
            Attack = attack;
            Defense = defense;
            Health = health;
            Gold = gold;
            Inventory = new List<Item>();
        }

        public void ShowStatus()
        {

            int equipedAttack = EquippedWeapon != null ? EquippedWeapon.AttackBouns : 0;
            int equipedDefense = EquippedArmor != null ? EquippedArmor.DefenseBouns : 0;
            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상태 보기");
            Console.ResetColor();
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine($"\nLv. {Lv}");
            Console.WriteLine($"{Job}");
            Console.WriteLine($"공격력: {Attack} {(equipedAttack > 0 ? $"(+{equipedAttack})" : "")}");
            Console.WriteLine($"방어력: {Defense} {(equipedDefense > 0 ? $"(+{equipedDefense})" : "")}");
            Console.WriteLine($"체력: {Health}");
            Console.WriteLine($"보유 골드: {Gold} G\n");
        }

        public void ShowInventory()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("인벤토리");
            Console.ResetColor();

            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("\n[아이템 목록]");
            if (Inventory.Count > 0)
            {
                for (int i = 0; i < Inventory.Count; i++)
                {
                    Console.WriteLine($"{Inventory[i].GetItemInfo()}");
                }
            }
            else
            {
                Console.WriteLine("인벤토리에 아이템이 없습니다.");
            }
            Console.WriteLine("\n1. 장착 관리\n0. 나가기");
            Console.Write("\n원하시는 행동을 입력해주세요\n>>");
        }

        public void GetInventory()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상점 - 아이템 판매");
            Console.ResetColor();

            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("\n[아이템 목록]");
            if (Inventory.Count > 0)
            {
                for (int i = 0; i < Inventory.Count; i++)
                {
                    Console.WriteLine($"{Inventory[i].ShowInventory()}");
                }
            }
            else
            {
                Console.WriteLine("보유중인 아이템이 없습니다.");
            }
            Console.WriteLine("\n0. 나가기");
            Console.Write("\n원하시는 행동을 입력해주세요\n>>");
        }

        public void EquipedItem()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.ResetColor();

            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("\n[아이템 목록]");
            if (Inventory.Count > 0)
            {
                for (int i = 0; i < Inventory.Count; i++)
                {
                    Console.WriteLine($"{Inventory[i].GetItemInfo()}");
                }
            }
            else
            {
                Console.WriteLine("인벤토리에 아이템이 없습니다.");
            }
            Console.WriteLine("\n0. 나가기");
            Console.Write("\n원하시는 행동을 입력해주세요\n>>");
        }

        public void BuyItem(Item item)
        {
            if (item.IsBuy)
            {
                Console.WriteLine($"{item.Name}은(는) 이미 구매한 아이템 입니다.");
                return;
            }

            if (Gold >= item.Price)
            {
                Gold -= item.Price;
                Inventory.Add(item);
                item.IsBuy = true;
                Console.WriteLine($"{item.Name}을(를) 구매완료했습니다.");
            }
            else
            {
                Console.WriteLine("골드가 부족합니다.");
            }
        }

        public void SellItem(Item item)
        {
            Gold += item.Price * 0.85f;
            Inventory.Remove(item);
            item.IsBuy = true;
            Console.WriteLine($"{item.Name}을(를) 판매완료했습니다.");
        }

        public void EquipItem(int itemIdx)
        {
            Item item = Inventory[itemIdx];
            if (!item.IsEquipped)
            {
                if (item.Type == ItemType.Weapon)
                {
                    if (EquippedWeapon == null)
                    {
                        Attack += item.AttackBouns;
                        Defense += item.DefenseBouns;
                        item.IsEquipped = true;
                        Console.WriteLine($"{item.Name}을(를) 창착했습니다.");
                        Console.WriteLine($"공격력 +{item.AttackBouns}, 방어력 +{item.DefenseBouns} 적용되었습니다.");
                        EquippedWeapon = item;
                    }
                    else
                    {
                        Console.WriteLine("무기를 이미 장착중 입니다.");
                    }
                }
                else
                {
                    if (EquippedArmor == null)
                    {
                        Attack += item.AttackBouns;
                        Defense += item.DefenseBouns;
                        item.IsEquipped = true;
                        Console.WriteLine($"{item.Name}을(를) 창착했습니다.");
                        Console.WriteLine($"공격력 +{item.AttackBouns}, 방어력 +{item.DefenseBouns} 적용되었습니다.");
                        EquippedArmor = item;
                    }
                    else
                    {
                        Console.WriteLine("방어구를 이미 장착중 입니다.");
                    }
                }
            }
            else
            {
                if (item.Type == ItemType.Weapon)
                {
                    EquippedWeapon = null;
                }
                else
                {
                    EquippedArmor = null;
                }
                Attack -= item.AttackBouns;
                Defense -= item.DefenseBouns;
                item.IsEquipped = false;
                Console.WriteLine($"{item.Name}(을)를 해체했습니다.");
                Console.WriteLine($"공격력 -{item.AttackBouns}, 방어력 -{item.DefenseBouns} 적용되었습니다.");
            }
        }

        public void DongeonClear(Dongeon dongeon)
        {
            Lv++;
            Attack += 0.5f;
            Defense += 1;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("던전 클리어");
            Console.ResetColor();
            if (dongeon.IsEasyClear)
            {
                Console.WriteLine($"{dongeon.Easy}을 클리어 하였습니다.");

                Console.WriteLine("\n[탐험 결과]");
                Random rnd = new Random();
                int rndHealth = Defense - dongeon.EasyReDef;
                int currentHealth = rnd.Next(20 - rndHealth, 36 - rndHealth);
                if (Health - currentHealth < 0)
                {
                    Console.WriteLine($"{Health} -> 0");
                    Health = 0;
                }
                else
                {
                    Console.WriteLine($"{Health} -> {Health - currentHealth}");
                    Health -= currentHealth;
                }
                double rndGold = rnd.NextDouble() * 0.1f + 0.1;
                double getGold = Attack * rndGold + 1000;
                Console.WriteLine($"Gold {Gold} G -> {Gold + getGold:F0} G");
                Gold += (int)getGold;
                dongeon.IsEasyClear = false;
            }
            else if (dongeon.IsNormalClear)
            {
                Console.WriteLine($"{dongeon.Normal}을 클리어 하였습니다.");

                Console.WriteLine("\n[탐험 결과]");
                Random rnd = new Random();
                int rndHealth = Defense - dongeon.EasyReDef;
                int currentHealth = rnd.Next(20 - rndHealth, 36 - rndHealth);
                if (Health - currentHealth < 0)
                {
                    Console.WriteLine($"{Health} -> 0");
                    Health = 0;
                }
                else
                {
                    Console.WriteLine($"{Health} -> {Health - currentHealth}");
                    Health -= currentHealth;
                }
                double rndGold = rnd.NextDouble() * 0.1f + 0.1;
                double getGold = Attack * rndGold + 1700;
                Console.WriteLine($"Gold {Gold} G -> {Gold + getGold:F0} G");
                Gold += (int)getGold;
                dongeon.IsNormalClear = false;
            }
            else
            {
                Console.WriteLine($"{dongeon.Difficult}을 클리어 하였습니다.");

                Console.WriteLine("\n[탐험 결과]");
                Random rnd = new Random();
                int rndHealth = Defense - dongeon.EasyReDef;
                int currentHealth = rnd.Next(20 - rndHealth, 36 - rndHealth);

                if (Health - currentHealth < 0)
                {
                    Console.WriteLine($"{Health} -> 0");
                    Health = 0;
                }
                else
                {
                    Console.WriteLine($"{Health} -> {Health - currentHealth}");
                    Health -= currentHealth;
                }

                double rndGold = rnd.NextDouble() * 0.1f + 0.1;
                double getGold = Attack * rndGold + 1700;
                Console.WriteLine($"Gold {Gold} G -> {Gold + getGold:F0} G");
                Gold += (int)getGold;
                dongeon.IsDifficultClear = false;
            }
            
        }

        public void DongeonFail()
        {
            Console.WriteLine("던전에서 쫒겨났습니다.");
            if (Health >= 0)
            {
                Console.WriteLine($"{Health} -> {Health / 2}");
                Health = Health / 2;
            }
               
        }
    }
}
