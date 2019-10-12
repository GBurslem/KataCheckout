namespace Kata
{
    public class Checkout
    {

        public decimal GetTotal()
        {
            // Total up number of each item bought
            // Check for discounts (do this last)
            // Add up cost
            // Return total
            return 0m;
        }
 
        public void Scan(string item)
        {
            // Add item to scanned items
        }
    }

    static void Main()  
    {  
        Checkout checkout = new Checkout(); 
        checkout.Scan("A99");
        checkout.Scan("B15"); 
        checkout.Scan("A99"); 
        print("Total: " + checkout.GetTotal()); 
    }  

}   