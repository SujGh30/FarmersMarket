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
            //Instantiate an object
            var vegetable = new Vegetables();

            vegetable.Name = "Beans";
            vegetable.Price = 2;
            vegetable.Quantity = 1;

            Console.WriteLine($"VN: {vegetable.Name}, price:{ vegetable.Price:C}, pounds:{vegetable.Quantity}" );

            var vegetable2 = new Vegetables();
            Console.WriteLine($"VN: {vegetable2.Name}, price:{ vegetable2.Price:C}, pounds:{vegetable2.Quantity}");






















        }
    }
}
