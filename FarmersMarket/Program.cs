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
            var order = Order.OrderVegetables("test1@test.com", 1234, 2, 10, TypeOfPayment.CreditCard, "Beans",3);
            Console.WriteLine($"Order ID: {Order.OrderID}");
            var order2 = Order.OrderVegetables("test2@test.com", 12345, 3, 5, TypeOfPayment.Cash, "Carrot", 3);
            Console.WriteLine($"Order ID: {Order.OrderID}");
        }
    }
}
