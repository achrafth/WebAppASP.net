using GP.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Service
{
    public class ProductService : Service<Product>, IProductService
    {
        public IEnumerable<Product> FindMost5ExpensiveProds()
        {
            return GetMany().OrderByDescending(P => P.Price).Take(5); ;
        }

        public float UnavailableProductsPercentage()
        {
            int nbUnavailable = (from P in GetMany(P => P.Quantity == 0)
                                 select P).Count();
            int nbProds = GetMany().Count();
            return (nbUnavailable / nbProds) * 100;
        }

        public IEnumerable<Product> GetProdsByClient(Client C)
        {
            /*FactureService Fs1 = new FactureService();
            var Req = Fs1.GetMany(F => F.ClientFk == C.CIN).Select(F => F.Produit);
            return Req;*/

            /* Or
            FactureService Fs2 = new FactureService();
            return GetMany(P => P.Factures == Fs2.GetFacturesByClient(C));*/

            FactureService Fs3 = new FactureService();
            return Fs3.GetFacturesByClient(C).Select(F => F.Produit);
        }

        public void DeleteOldProducts()
        {
            var Req = GetMany(P => (DateTime.Now - P.DateProd).TotalDays > 365);
            foreach (Product P in Req)
                Delete(P);
        }
    }
}
