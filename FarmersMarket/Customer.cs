using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersMarket
{
    public enum OrderType
    {
        Created,
        Delivered,
        OrderCancelled

    }
   public class Customer
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public String AddressToDeliver { get; set; }
        public String EmailAddress { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal TotalAmount { get; set; }
        public OrderType TypeOfOrder { get; set; }

        [ForeignKey("Vegetables")]
        public int VegetableID { get; set; }

        public virtual Vegetables Vegetables { get; set; }

        internal void VegetablesOrder(Customer customer)
        {
            throw new NotImplementedException();
        }

    }
}
