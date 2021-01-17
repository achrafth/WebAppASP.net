using GP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Service
{
    public static class ProductExtension
    {
        public static void UpperName(this ManageProduct MP, Product P)
        {
            P.Name = P.Name.ToUpper();
        }
        public static bool InCategory(this ManageProduct MP, Category Cat, Product P)
        {
            return (P.MyCategory.Equals(Cat));
        }
    }
}
