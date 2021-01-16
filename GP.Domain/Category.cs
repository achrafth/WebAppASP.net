using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Domain
{
    public class Category : Concept
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public override void GetDetails()
        {
            System.Console.WriteLine("Category Id: " + CategoryId +
                " Name: " + Name); ;
        }
    }
}
