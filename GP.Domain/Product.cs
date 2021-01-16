using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Domain
{
    public class Product : Concept
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public DateTime DateProd { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Category Category { get; set; }
        public List<Provider> Providers { get; set; }

        public override void GetDetails()
        {
            System.Console.WriteLine("Product Id: " + ProductId + " Name: " + Name +
            " Description: " + Description + " DateProd: " + DateProd + " Price: " + Price +
            " Quantity: " + Quantity);
        }
        public virtual void GetMyType()
        {
            System.Console.WriteLine(" Type: UNKNOWN ");
        }
    }
}
