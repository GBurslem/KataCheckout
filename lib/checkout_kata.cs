using System;
using System.Collections;
using System.Collections.Generic;

namespace Kata
{
    public class Checkout
    {
        List<ScannedItem> scannedItems = new List<ScannedItem>();
        List<BasketItem> basket = new List<BasketItem>();

        /*
        *   Returns the discounted total of the scanned items. Also prints the non discounted 
        *   total and the total amount saved from discounts. 
         */
        public float GetDiscountedTotal()
        {
            float total = 0;

            // Get total of items pre discounts
            for (int i = 0; i < scannedItems.Count; i++)
            {
                total += scannedItems[i].price;
            }
            Console.WriteLine("Non Discounted Total: " + total);

            float discountAmount = GetDiscountAmount();
            Console.WriteLine("Amount saved: " + discountAmount + "\n");

            return total - discountAmount;
        }

        /*
        *   Returns the total amount saved from discounts. First needs to create a basket
        *   from scanned items, and then calculates discounts based on the quantities of 
        *   items. 
         */
        private float GetDiscountAmount()
        {

            CreateBasket();
            PrintBasket();

            float discount = CalculateDiscount();
            return discount;
        }

        /*
        * Uses the scanned items to create a basket with item quantities. 
         */
        private void CreateBasket()
        {
            for (int i = 0; i < scannedItems.Count; i++)
            {
                if (basket.Count != 0)
                {
                    AddItemToBasket(i);
                }
                else
                {
                    BasketItem basketItem = new BasketItem(scannedItems[i].getName(),
                                                    scannedItems[i].getPrice(),
                                                    scannedItems[i].getDiscountAmount(),
                                                    scannedItems[i].getDiscountPrice());
                    basket.Add(basketItem);
                }
            }
        }

        /*
        * Adds a scanned item to the basket. Will check if an item of the same type has been added,
        * and if so, will just increase the quantity of that item. 
         */
        private void AddItemToBasket(int scannedItemIndex)
        {
            bool found = false;
            for (int j = 0; j < basket.Count; j++)
            {
                if (basket[j].name == scannedItems[scannedItemIndex].name)
                {
                    basket[j].addOne();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                BasketItem basketItem = new BasketItem(scannedItems[scannedItemIndex].getName(),
                                                    scannedItems[scannedItemIndex].getPrice(),
                                                    scannedItems[scannedItemIndex].getDiscountAmount(),
                                                    scannedItems[scannedItemIndex].getDiscountPrice());
                basket.Add(basketItem);
            }
        }

        /*
        *   Prints the content of a basket.
         */
        public void PrintBasket()
        {
            for (int i = 0; i < basket.Count; i++)
            {
                Console.WriteLine("Basket Name: " + basket[i].name);
                Console.WriteLine("Basket Quantity: " + basket[i].quantity);
            }
        }

        /*
        *   Returns the total amount saved with the discounts on the items in the basket.
         */
        private float CalculateDiscount()
        {
            float totalDiscount = 0;
            for (int i = 0; i < basket.Count; i++)
            {
                int numberOfDeals = basket[i].quantity / basket[i].discountAmount;
                float savingPerDeal = (basket[i].price * basket[i].discountAmount) - basket[i].discountPrice;
                totalDiscount += numberOfDeals * savingPerDeal;
            }
            return totalDiscount;
        }

        /*
        *   Adds item to scanned items list.
         */
        public void Scan(ScannedItem item)
        {
            // Add item to scanned items
            scannedItems.Add(item);
        }

        /*
        *   Main method where some example scanned items are added and the discounted
        *   total is calculated and displayed.
         */
        static void Main(string[] args)
        {
            Checkout checkout = new Checkout();

            ScannedItem item1 = new ScannedItem("A99", 0.5f, 3, 1.30f);
            ScannedItem item2 = new ScannedItem("B15", 0.3f, 2, 0.45f);
            ScannedItem item3 = new ScannedItem("A99", 0.5f, 3, 1.30f);
            ScannedItem item4 = new ScannedItem("A99", 0.5f, 3, 1.30f);
            ScannedItem item5 = new ScannedItem("B15", 0.3f, 2, 0.45f);

            checkout.Scan(item1);
            checkout.Scan(item2);
            checkout.Scan(item3);
            checkout.Scan(item4);
            checkout.Scan(item5);

            Console.WriteLine("Discounted total: " + checkout.GetDiscountedTotal() + "\n");
        }
    }

    /*
    *   Class for scanned items. 
     */
    public class ScannedItem
    {
        public string name;
        public float price;
        public int discountAmount;
        public float discountPrice;

        public ScannedItem(string name, float price, int discountAmount, float discountPrice)
        {
            this.name = name;
            this.price = price;
            this.discountAmount = discountAmount;
            this.discountPrice = discountPrice;
        }

        public string getName()
        {
            return this.name;
        }

        public float getPrice()
        {
            return this.price;
        }

        public int getDiscountAmount()
        {
            return this.discountAmount;
        }

        public float getDiscountPrice()
        {
            return this.discountPrice;
        }

    }

    /*
    * Class for basket items. These items have quantites. 
     */
    public class BasketItem
    {
        public string name;
        public float price;
        public int quantity;
        public int discountAmount;
        public float discountPrice;

        public BasketItem(string name, float price, int discountAmount, float discountPrice)
        {
            this.name = name;
            this.price = price;
            this.discountAmount = discountAmount;
            this.discountPrice = discountPrice;
            this.quantity = 1;
        }

        public void addOne()
        {
            this.quantity += 1;
        }
    }

}