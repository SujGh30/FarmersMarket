using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersMarket
{
    public static class Order
    {
        /// <summary>
        /// Order places an orders for the users.
        /// </summary>
        
       
        public static int OrderID { get; set; }
        public static int ItemsCount{ get; set; }
        public static decimal ItemsCost { get; set; }
   
        public static Vegetables OrderVegetables(string emailaddress, int orderID, int itemscount, decimal vegprice, TypeOfPayment typeofpayment, string vname, float quantity)
        {         
            var vegetables = new Vegetables();
            vegetables.EmailAddress = emailaddress;
            OrderID = orderID;
            ItemsCount = itemscount;
            vegetables.Price = vegprice;
            vegetables.Name = vname;
            vegetables.Payment = typeofpayment;
            if (quantity > 0)
            {
                vegetables.Quantity = quantity;

            }
            Console.WriteLine($"Order ID: {OrderID}, Email: {vegetables.EmailAddress}, VN: {vegetables.Name}, price:{ vegetables.Price:C}, pounds:{vegetables.Quantity},TypeOfPayment:{ vegetables.Payment}");
            return vegetables;
        }

    }

}