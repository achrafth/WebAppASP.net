using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Domain
{
    public class Product : Concept
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Name Required")]
        [StringLength(25, ErrorMessage = "Must be less than 25 characters")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Display(Name = "Production Date")]
        [DataType(DataType.DateTime)]
        public DateTime DateProd { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string ImageName { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId ")]
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
            System.Console.WriteLine(" Type: UNKNOWN ");
        }
    }
}
