using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Domain
{
    public class Biological : Product
    {
        public string Herbs { get; set; }
        public override void GetMyType()
        {
            System.Console.WriteLine(" Type: BIOLOGICAL ");
        }
        public override void GetDetails()
        {
            base.GetDetails();
            System.Console.WriteLine(" Herbs: " + Herbs);
        }
    }
}
