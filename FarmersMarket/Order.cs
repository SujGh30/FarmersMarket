using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersMarket
{
    public enum TypeOfPayment
    {
        CreditCard,
        DebitCard,
        Cash
    }

    public static class Order
    {
        private static FarmerMarketModel db = new FarmerMarketModel();

        
        /// <summary>
        /// Order places an orders for the users.
        /// </summary>


        private static int OrderID = 1;
        private static int ItemsCount = 0;
        private static decimal ItemCost = 0;
        private static decimal TotalCost = 0;
        public static TypeOfPayment Payment { get; set; }
        public static string EmailAddress { get; set; }

        public static Vegetables OrderVegetables(string emailaddress, decimal vegprice, TypeOfPayment typeofpayment, string vname, decimal quantity)
        {

            EmailAddress = emailaddress;
            //OrderID      = OrderID + 1;
            ItemsCount   = ItemsCount + 1;
            var vegetables = new Vegetables();
            vegetables.Price = vegprice;
            vegetables.Name = vname;
            Payment = typeofpayment;
            if (quantity > 0)
            {
                vegetables.Quantity = quantity;

            }
            ItemCost = vegetables.Quantity * vegetables.Price;
            TotalCost = TotalCost + ItemCost;
            //Creating Vegetables list           
            db.Vegetables.Add(vegetables);
            
            db.SaveChanges();
            return vegetables;

        }
        //Method to print the order details
        public static List<Vegetables> GetOrderdetails()
        {
            Console.WriteLine($"Order ID: {OrderID}, No of items: {ItemsCount}, Total Cost:{TotalCost:C}");
            return db.Vegetables.ToList();

        }

    }

}