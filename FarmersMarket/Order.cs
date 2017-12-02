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


        public static TypeOfPayment Payment { get; set; }
        public static string EmailAddress { get; set; }
        public static DateTime OrderDate { get; private set; }
        public static OrderType TypeOfOrder { get; private set; }

        public static Vegetables AddVegetables(decimal vegprice, string vname)
        {
            var vegetables = new Vegetables();
            vegetables.Price = vegprice;
            vegetables.Name = vname;
           //Creating Vegetables list           
            db.Vegetables.Add(vegetables);
            
            db.SaveChanges();
            return vegetables;
        }

        //Method to print the Vegetable prices
        public static List<Vegetables> GetVegetablePricesList()
        {
            return db.Vegetables.ToList();
        }

        //Method to print the Vegetable prices by VegID
        public static Vegetables GetVegetablePricesByID(int vegID)
        {
            var vegs = db.Vegetables.Where(a => a.VegetableID == vegID).FirstOrDefault();
            if (vegs == null)
                throw new ArgumentOutOfRangeException("Invalid Vegetable Name.");
            return vegs;
        }

        public  static void OrderVegetables(int VegID, TypeOfPayment payment, decimal vegQty, string emailID, string address)
        {

            var vegbyID = GetVegetablePricesByID(VegID);
                
            var customerOrder  = new Customer
            {
                OrderDate = DateTime.UtcNow,
                TypeOfOrder = OrderType.Created,
                Quantity = vegQty,
                EmailAddress = emailID,
                AddressToDeliver = address,
                TotalAmount = vegbyID.Price * vegQty,
                VegetableID = vegbyID.VegetableID
            };

            db.Customers.Add(customerOrder);
            db.SaveChanges();
         }

           //Select all orders by email ID and deliver them. 
        public static void DeliverCustomerOrder(string emailID)
        {
            db.Customers.Where(c => c.EmailAddress == emailID).ToList().ForEach(c =>
            {
                c.OrderDate = DateTime.UtcNow;
                if (c.TypeOfOrder == OrderType.Created)
                    c.TypeOfOrder = OrderType.Delivered;
            });
            db.SaveChanges();
        }

        //Cancel order by eamild ID only if it is still not delivered. 
        public static void CancelCustomerOrder(string emailID)
        {
            db.Customers.Where(c => c.EmailAddress == emailID).ToList().ForEach(c =>
            {
                c.OrderDate = DateTime.UtcNow;
                if (c.TypeOfOrder == OrderType.Created)
                    c.TypeOfOrder = OrderType.OrderCancelled;
            });
            db.SaveChanges();
        }
        //Method to print the order details
        public static List<Customer> GetOrderdetails()
        {
            return db.Customers.ToList();


        }
        //Method to print the order details by customer Email
        public static List<Customer> GetOrderdetailsbyEmailID(string emailID)
        {
            return db.Customers.Where(c => c.EmailAddress == emailID).ToList();

        }
    }
   
}