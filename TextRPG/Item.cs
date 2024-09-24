using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public enum ItemType
    {
        Weapon,
        Armor
    }

    public class Item
    {
        public string Name { get; set; }
        public string Information {  get; set; } 
        public string Description { get; set; }
        public int Price { get; set; }
        public int AttackBouns {  get; set; }
        public int DefenseBouns { get; set; }
        public bool IsEquipped { get; set; }
        public bool IsBuy { get; set; }
        
        public ItemType Type { get; set; }

        public Item(string name, string information, string description, int price, int attackBouns, int defenseBouns, ItemType type)
        {
            Name = name;
            Information = information;
            Description = description;
            Price = price;
            AttackBouns = attackBouns;
            DefenseBouns = defenseBouns;
            IsEquipped = false;
            IsBuy = false;
            Type = type;
        }

        public void ShowItemInfo()
        {
            string purchasedStatus = IsBuy ? " | 구매완료" : $" 가격 : {Price} G";
            Console.WriteLine($"- {Name}    | {Information} | {Description}{purchasedStatus}");
        }


        public string ShowInventory()
        {
           return $"- {Name}    | {Information} | {Description} | {Price * 0.85f} G";
        }

        public string GetItemInfo()
        {
            string equippedStatus = IsEquipped ? "[E]" : "";
            return $"- {equippedStatus}{Name}    | {Information} | {Description}";
        }
    }
}
