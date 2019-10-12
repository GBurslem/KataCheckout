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
            Console.WriteLine("Total: " + total);

            float discountAmount = GetDiscountAmount();
            Console.WriteLine("Amount saved: " + discountAmount + "\n");

            return total - discountAmount;
        }

        private float GetDiscountAmount()
        {
            float discountAmount = 0;
            int totalA99 = 0;
            int totalB15 = 0;

            for (int i = 0; i < scannedItems.Count; i++)
            {
                if (scannedItems[i].name == "A99")
                {
                    totalA99 += 1;
                }
                if (scannedItems[i].name == "B15")
                {
                    totalB15 += 1;
                }
            }

            Console.WriteLine("Total A99: " + totalA99 + " Total B15: " + totalB15);

            discountAmount = CalculateDiscounts(totalA99, totalB15);
            return discountAmount;
        }

        private float CalculateDiscounts(int totalA99, int totalB15)
        {
            int numberOfA99Deals = totalA99 / 3;
            float a99DiscountTotal = numberOfA99Deals * (1.5f - 1.3f);

            int numberOfB15Deals = totalB15 / 2;
            float b15DiscountTotal = numberOfB15Deals * (0.6f - 0.45f);

            return a99DiscountTotal + b15DiscountTotal;
        }

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
            Item item4 = new Item("A99", 0.5f, 3f, 1.30f);

            checkout.Scan(item1);
            checkout.Scan(item2);
            checkout.Scan(item3);
            checkout.Scan(item4);

            Console.WriteLine("Discounted total: " + checkout.GetTotal() + "\n");
        }
    }

    public class Item
    {
        public string name;
        public float price;
        public float discountAmount;
        public float discountPrice;

        public Item(string name, float price, float discountAmount, float discountPrice)
        {
            this.name = name;
            this.price = price;
            this.discountAmount = discountAmount;
            this.discountPrice = discountPrice;
        }

    }

}