using System;
using System.Collections;
using System.Collections.Generic;

namespace Kata
{
    public class Checkout
    {
        List<Item> scannedItems = new List<Item>();

        public float GetTotal()
        {
            float total = 0;

            // Get total of items pre discounts
            for (int i = 0; i < scannedItems.Count; i++)
            {
                total += scannedItems[i].price;
            }

            // Check for discounts (do this last)
            // CalculateDiscounts();
            // Add up cost
            // Return total
            return total;
        }

        // private float CalculateDiscounts(string itemID, int quantity)
        // {
        //     // Search data file and calculate discount
        //     // Return amount to be taken off the total
        // }

        public void Scan(Item item)
        {
            // Add item to scanned items
            scannedItems.Add(item);
        }

        static void Main(string[] args)
        {
            Checkout checkout = new Checkout();
            
            Item item1 = new Item("A99", 0.5f, 3f, 1.30f);
            Item item2 = new Item("B15", 0.3f, 2f, 0.45f);
            Item item3 = new Item("A99", 0.5f, 3f, 1.30f);

            checkout.Scan(item1);
            checkout.Scan(item2);
            checkout.Scan(item3);

            Console.WriteLine("Total: " + checkout.GetTotal());
        }
    }

    public class Item
    {
        public string name;
        public float price;
        public float discountAmount;
        public float discountPrice;

        public Item(string name, float price, float discountAmount, float discountPrice){
            this.name = name;
            this.price = price; 
            this.discountAmount = discountAmount;
            this.discountPrice = discountPrice;
        }

    }

}