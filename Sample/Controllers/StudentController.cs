using System;
using System.Collections.Generic;

namespace ShoppingList
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool IsPurchased { get; set; }

        public Item(int id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            IsPurchased = false;
        }
    }

    public class ShoppingListManager
    {
        private static int _nextItemId = 1;
        private readonly List<Item> _items = new List<Item>();

        public void AddItem(string name, int quantity)
        {
            var newItem = new Item(_nextItemId++, name, quantity);
            _items.Add(newItem);
            Console.WriteLine($"Item '{newItem.Name}' (x{newItem.Quantity}) has been added to the shopping list.");
        }

        public IEnumerable<Item> GetItems()
        {
            return _items;
        }

        public Item GetItemById(int id)
        {
            return _items.Find(item => item.Id == id);
        }

        public void UpdateItem(int id, string name, int quantity)
        {
            var item = GetItemById(id);
            if (item != null)
            {
                item.Name = name;
                item.Quantity = quantity;
                Console.WriteLine($"Item ID {id} has been updated.");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }

        public void MarkItemPurchased(int id)
        {
            var item = GetItemById(id);
            if (item != null)
            {
                item.IsPurchased = true;
                Console.WriteLine($"Item ID {id} has been marked as purchased.");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }

        public void RemoveItem(int id)
        {
            int removedCount = _items.RemoveAll(item => item.Id == id);
            if (removedCount > 0)
            {
                Console.WriteLine($"Item ID {id} has been removed from the shopping list.");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }
    }

    // Program class with the single Main method
    class Program
    {
        static void Main(string[] args)
        {
            var shoppingListManager = new ShoppingListManager();

            // Add items to the shopping list
            shoppingListManager.AddItem("Milk", 2); // ID 1
            shoppingListManager.AddItem("Pan de Sal", 1); // ID 2
            shoppingListManager.AddItem("Eggs", 12); // ID 3

            Console.WriteLine("\nShopping List:");
            foreach (var item in shoppingListManager.GetItems())
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}, Purchased: {item.IsPurchased}");
            }

            // Mark item as purchased
            shoppingListManager.MarkItemPurchased(1);

            // Update an item
            shoppingListManager.UpdateItem(2, "Whole Wheat Bread", 2);

            // Remove an item
            shoppingListManager.RemoveItem(3); // Remove eggs

            Console.WriteLine("\nUpdated Shopping List:");
            foreach (var item in shoppingListManager.GetItems())
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}, Purchased: {item.IsPurchased}");
            }

            Console.ReadKey();
        }
    }
}
