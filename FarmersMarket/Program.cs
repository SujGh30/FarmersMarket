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
                Console.WriteLine("1. Create an Order");
                Console.WriteLine("2. Selecte an OrderID");
                Console.WriteLine("3. OrderCount");
                Console.WriteLine("4. Vegetable Price");
                Console.WriteLine("5. TypeOfPayment");
                Console.WriteLine("6. Print Order");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        return;
                    case "1":

                        Console.WriteLine("Email Address:");
                        var emailAddress = Console.ReadLine();
                        Console.WriteLine("payment type: ");
                        var paymenttype = Enum.GetNames(typeof(TypeOfPayment));
                        for (var i = 0; i < paymenttype.Length; i++)
                        {
                            Console.WriteLine($"{i}. {paymenttype[i]}");
                        }
                        var payment = (TypeOfPayment)Enum.Parse(typeof(TypeOfPayment), Console.ReadLine());

                        Console.WriteLine("Vegetable Name: ");
                        var vegName = Console.ReadLine();
                        Console.WriteLine("Vegetable Price: ");
                        var vegePrice = Console.ReadLine();
                        Console.WriteLine("Vegetable Quantity in  Pounds: ");
                        var vegeQty = Console.ReadLine();
                        decimal vegPrice = Convert.ToDecimal(vegePrice);
                        decimal vegQty = Convert.ToDecimal(vegeQty);
                        var order = Order.OrderVegetables(emailAddress, vegPrice, payment, vegName, vegQty);
                        break;
                    case "2":
                        break;

                    case "3":
                        break;

                    case "4":
                        break;

                    case "5":
                        break;
                    case "6":
                       var vegelist = Order.GetOrderdetails();
                        foreach (var veggies in vegelist)
                        {
                            Console.WriteLine($"Vegetable Name:{veggies.Name}, Quantity in lbs: {veggies.Quantity},Price:{veggies.Price:C} ");
                        }
                        break;
                        
                    default:
                        break;
                }

            }
        }
    }
}
