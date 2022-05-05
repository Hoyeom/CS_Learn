using System;
using System.Collections.Generic;

namespace CSharp_2
{
    enum ItemType
    {
        None,
        Weapon,
        Armor,
        Amulet,
        Ring,
    }

    enum Rarity
    {
        Normal,
        Uncommon,
        Rare
    }
    
    class Item
    {
        public ItemType ItemType;
        public Rarity Rarity;
    }
    
    internal class Program
    {
        static List<Item> _items = new List<Item>();
        
        static bool IsWeapon(Item item)
        {
            return item.ItemType == ItemType.Weapon;
        }

        static Item FindWeapon(Func<Item,bool> selector)
        {
            foreach (Item item in _items)
            {
                if (selector(item))
                    return item;
            }
            return null;
        }
        
        public static void Main(string[] args)
        {
            _items.Add(new Item() {ItemType = ItemType.Weapon, Rarity = Rarity.Normal});
            _items.Add(new Item() {ItemType = ItemType.Armor, Rarity = Rarity.Normal});
            _items.Add(new Item() {ItemType = ItemType.Ring, Rarity = Rarity.Rare});

            // delegate를 직접 선언하지 않아도, 이미 만들어진 얘들 존재한다.
            // -> 반환 타입 있을 경우 Func
            // -> 반환 타입 없을 경우 Action
            
            Func<Item, bool> selector = (item) => item.ItemType == ItemType.Weapon;

            Item item1 = FindWeapon(selector);

            // Lambda : 일회용 함수를 만드는데 사용하는 문법
            // Anonymous Function : 무명 함수 / 익명 함수
            // Item item = FindWeapon(delegate(Item item1)
            // {
            //     return item1.ItemType == ItemType.Weapon;
            // });
            // Item item1 = FindWeapon((Item item) => item.ItemType == ItemType.Weapon);

        }
    }
}

#region EVENT

/*static void OnInputTest()
{
    Console.WriteLine("Input Received");
}


public static void Main(string[] args)
{
    InputManager inputManager = new InputManager();
    inputManager.InputKey += OnInputTest;
    
    while (true)
    {
        inputManager.Update();
    }
}*/

#endregion