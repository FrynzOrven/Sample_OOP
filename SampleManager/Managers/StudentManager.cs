using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingListManager
{
    // Item class represents an item in the shopping list
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPurchased { get; set; }

        public Item(int id, string name, bool isPurchased)
        {
            Id = id;
            Name = name;
            IsPurchased = isPurchased;
        }
    }

    // ShoppingListManager class handles operations on the shopping list
    public class ShoppingListManager
    {
        private readonly List<Item> _items = new List<Item>();

        public IEnumerable<Item> GetAllItems()
        {
            return _items;
        }

        public Item GetItemById(int id)
        {
            return _items.FirstOrDefault(i => i.Id == id);
        }

        public void AddItem(Item newItem)
        {
            newItem.Id = _items.Any() ? _items.Max(i => i.Id) + 1 : 1; // Auto-increment ID
            newItem.IsPurchased = false; // Default to not purchased
            _items.Add(newItem);
            Console.WriteLine($"Item '{newItem.Name}' added to the shopping list.");
        }

        public void UpdateItem(int id, Item updatedItem)
        {
            var existingItem = _items.FirstOrDefault(i => i.Id == id);
            if (existingItem != null)
            {
                existingItem.Name = updatedItem.Name;
                existingItem.IsPurchased = updatedItem.IsPurchased;
                Console.WriteLine($"Item {id} updated.");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }

        public void MarkAsPurchased(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                item.IsPurchased = true;
                Console.WriteLine($"Item '{item.Name}' marked as purchased.");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }

        public void DeleteItem(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _items.Remove(item);
                Console.WriteLine($"Item '{item.Name}' deleted from the shopping list.");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }
    }

    // Program class to test the Shopping List Manager functionality
    class Program
    {
        static void Main(string[] args)
        {
            ShoppingListManager shoppingListManager = new ShoppingListManager();

            // Add items to the shopping list
            shoppingListManager.AddItem(new Item(0, "Milk", false));
            shoppingListManager.AddItem(new Item(0, "Bread", false));
            shoppingListManager.AddItem(new Item(0, "Eggs", false));

            // Display all items
            Console.WriteLine("\nAll Items in the Shopping List:");
            foreach (var item in shoppingListManager.GetAllItems())
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Purchased: {item.IsPurchased}");
            }

            // Update an item
            shoppingListManager.UpdateItem(2, new Item(2, "Whole Wheat Bread", false));

            // Mark an item as purchased
            shoppingListManager.MarkAsPurchased(3);

            // Display all items after updates
            Console.WriteLine("\nShopping List After Updates:");
            foreach (var item in shoppingListManager.GetAllItems())
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Purchased: {item.IsPurchased}");
            }

            // Delete an item
            shoppingListManager.DeleteItem(1);

            // Display all items after deletion
            Console.WriteLine("\nShopping List After Deletion:");
            foreach (var item in shoppingListManager.GetAllItems())
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Purchased: {item.IsPurchased}");
            }
        }
    }
}
