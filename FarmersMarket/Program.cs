using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******************");
            Console.WriteLine("Welcome to Online Farmer's Market");
            Console.WriteLine("*********************");
            while (true)
            {
                Console.WriteLine("Order for Fresh Vegetables");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Add to Order");
                Console.WriteLine("2. Select Customer Order to Deliver");
                Console.WriteLine("3. Select the Order to Cancel");
                Console.WriteLine("4. Add New Vegetables");
                Console.WriteLine("5. Print Orders");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        return;
                    case "1":
                        PrintVegetablesPrices();
                        Console.WriteLine("Please enter the Vegetable ID from the list above:");
                        var VegeIDFromList = Console.ReadLine();
                        int VegID = Convert.ToInt32(VegeIDFromList);
                        Console.WriteLine("Please enter Email ID: ");
                        var EmailAddress = Console.ReadLine();

                        Console.WriteLine("payment type: ");
                        var paymenttype = Enum.GetNames(typeof(TypeOfPayment));
                        for (var i = 0; i < paymenttype.Length; i++)
                        {
                            Console.WriteLine($"{i}. {paymenttype[i]}");
                        }
                        var payment = (TypeOfPayment)Enum.Parse(typeof(TypeOfPayment), Console.ReadLine());

                        Console.WriteLine("Vegetable Quantity in  Pounds: ");
                        var vegeQty = Console.ReadLine();
                        decimal vegQty = Convert.ToDecimal(vegeQty);
                        Console.WriteLine("Please enter Address to Deliver: ");
                        var AddressToDeliver = Console.ReadLine();

                        Order.OrderVegetables(VegID, payment, vegQty, EmailAddress, AddressToDeliver);
                        break;
                    case "2":
                        Console.WriteLine("Please enter customer Email ID: ");
                        var emailID = Console.ReadLine();
                        Order.DeliverCustomerOrder(emailID);
                        PrintCustomerOrdersByEmailID(emailID);
                        break;

                    case "3":
                        Console.WriteLine("Please enter Email ID to cancel order: ");
                        var cancelemailID = Console.ReadLine();
                        Order.CancelCustomerOrder(cancelemailID);
                        PrintCustomerOrdersByEmailID(cancelemailID);
                        break;

                    case "4":
                        Console.WriteLine("Please enter Vegetable Name: ");
                        var vegName = Console.ReadLine();
                        Console.WriteLine("Please enter Vegetable Price: ");
                        var vegePrice = Console.ReadLine();
                        decimal vegPrice = Convert.ToDecimal(vegePrice);
                        var VegetableList= Order.AddVegetables(vegPrice,vegName);
                        break;
                    case "5":
                        PrintAllCustomerOrders();
                        break;

                    default:
                        break;
                }

            }
        }

        private static void PrintAllCustomerOrders()
        {
           
            var customerOrder = Order.GetOrderdetails();
            foreach (var orders in customerOrder)
            {
                Console.WriteLine($"Email ID: {orders.EmailAddress}, Order ID: {orders.OrderID}, Quantity in lbs: {orders.Quantity},Total Amount :{orders.TotalAmount:C},Order Type: {orders.TypeOfOrder}");
            }

            
        }

        private static void PrintCustomerOrdersByEmailID(string emailID)
        {

            var customerOrder = Order.GetOrderdetailsbyEmailID(emailID);
            foreach (var orders in customerOrder)
            {
                Console.WriteLine($"Email ID: {orders.EmailAddress}, Order Type: {orders.TypeOfOrder}, Quantity in lbs: {orders.Quantity},Total Amount :{orders.TotalAmount:C} ");
            }


        }

        private static void PrintVegetablesPrices()
        {

            var vegelist = Order.GetVegetablePricesList();
            foreach (var veggies in vegelist)
            {
                Console.WriteLine($"Vegetable ID: {veggies.VegetableID}, Vegetable Name:{veggies.Name}, Price:{veggies.Price:C} ");
            }


        }
    }
}
