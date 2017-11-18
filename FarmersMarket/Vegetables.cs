using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersMarket
{
    public class Vegetables

    {
        
        // Properties 
        [Key]
        public int VegetableID { get; set; }

        [Required]
        [StringLength(50,ErrorMessage = "Name cannot be more than 50 charecters in length")]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        
  
   //     public TypeOfPayment Payment { get; set; }
    //    public string EmailAddress { get; set; }
        //Constructor  

        public Vegetables()
        {
            
            //Itemscount += Vegetables.Itemscount;
            //Totalcost += Vegetables.Totalcost;

        }
            

    }
}
